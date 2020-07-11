using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Data.OracleClient;
using libzkfpcsharp;
using System.Data;

namespace TTManagementSystem
{
    public class connectDevice
    {
         public static int DeviceConnected = 0;
         static public int FingerTap = 0; // 0 for Searching and 1 for Registering.
         static public int foundUserid = 2; // 0 means not found and 1 means found and 2 is initial stage 
         static public string userid; // will store username if found
         
         static int REGISTER_FINGER_COUNT = 3;
         public static int RegisterCount = 0;
         static int regTempLen = 0;
         static int iFid = 1;
         static zkfp fpInstance = new zkfp();
         static byte[][] RegTmps = new byte[3][];
         static private int mfpWidth = 0;
         static private int mfpHeight = 0;
         static byte[] FPBuffer;
         static public bool bIsTimeToDie = false;
         static int cbCapTmp = 2048;
         static byte[] CapTmp = new byte[2048];
         static byte[] RegTmp = new byte[2048];
         public static string fingerPrintTemplate = string.Empty;
         static int size;
         static byte[] paramValue = new byte[4];
         static int openDeviceCallBackCode;

         static public void connect()
         {
             if (zkfp.ZKFP_ERR_OK == fpInstance.Initialize()) // Device Connect
             {
                 if (FingerTap == 0)
                 {
                     REGISTER_FINGER_COUNT = 1;
                 }
                 else
                 {
                     REGISTER_FINGER_COUNT = 3;
                 }
                 DeviceConnected = 1;
                 openDeviceCallBackCode = fpInstance.OpenDevice(0); // Open Device
                 if (zkfp.ZKFP_ERR_OK != openDeviceCallBackCode) // In Build error code
                 {
                     return;
                 }
                 for (int i = 0; i < 3; i++)
                 {
                     RegTmps[i] = new byte[2048];
                 }
                 size = 4;
                 fpInstance.GetParameters(1, paramValue, ref size);
                 zkfp2.ByteArray2Int(paramValue, ref mfpWidth);

                 size = 4;
                 fpInstance.GetParameters(2, paramValue, ref size);
                 zkfp2.ByteArray2Int(paramValue, ref mfpHeight);

                 FPBuffer = new byte[mfpWidth * mfpHeight];
             }
             else
             {
                 DeviceConnected = 0;
             }
         }
         static public void DoCapture()
         {
             try
             {
                 while (!bIsTimeToDie)
                 {
                     int ret = fpInstance.AcquireFingerprint(FPBuffer, CapTmp, ref cbCapTmp);

                     if (ret == zkfp.ZKFP_ERR_OK)
                     {
                        
                         Array.Copy(CapTmp, RegTmps[RegisterCount], cbCapTmp);
                         RegisterCount++;

                         if (RegisterCount >= REGISTER_FINGER_COUNT)
                         {
                             RegisterCount = 0;
                             ret = GenerateRegisteredFingerPrint();
                             if (zkfp.ZKFP_ERR_OK == ret)
                             {
                                 ret = fpInstance.AddRegTemplate(iFid, RegTmp);
                                 if (zkfp.ZKFP_ERR_OK == ret)         
                                 {
                                     string sql;
                                     zkfp.Blob2Base64String(RegTmp, regTempLen, ref fingerPrintTemplate);

                                     OracleConnection conn = new OracleConnection(String.Format("Data Source=Neptune; User Id={0}; Password={1}", TestConnection.oracelUser, TestConnection.oracelPass));
                                     conn.Open();

                                     if (FingerTap == 0)
                                     {
                                         OracleCommand cmd = new OracleCommand("SELECT f_id, u_id FROM user_t", conn);
                                         OracleDataAdapter da = new OracleDataAdapter(cmd);
                                         DataTable dt = new DataTable();
                                         string text1 = string.Empty;
                                         da.Fill(dt);
                                         conn.Close();
                                         foundUserid = 0;
                                         foreach (DataRow dr in dt.Rows)
                                         {
                                             text1 = Convert.ToString(dr["f_id"]);
                                             CapTmp = new byte[2048];
                                             CapTmp = zkfp.Base64String2Blob(text1);

                                             ret = fpInstance.Match(RegTmp, CapTmp);
                                             if (0 < ret)
                                             {
                                                 userid = Convert.ToString(dr["u_id"]);
                                                 foundUserid = 1;

                                             }
                                         }
                                         if (foundUserid == 0)
                                         {
                                             DisconnectDevice();
                                             connect();
                                         }
                                         
                                     }
                                    
                                 }
                             }
                         }

                     }
                 }
             }
             catch (Exception ex) {
                 DeviceConnected = 0;
             }
         }


        static private int GenerateRegisteredFingerPrint()
        {
            if(FingerTap == 0)
            {
             return fpInstance.GenerateRegTemplate(RegTmps[0], RegTmps[0], RegTmps[0], RegTmp, ref regTempLen);
        
            }
            else
            {
               return fpInstance.GenerateRegTemplate(RegTmps[0], RegTmps[1], RegTmps[2], RegTmp, ref regTempLen);
            }
        }
        static private void reset()
        {
            RegisterCount = 0;
            regTempLen = 0;
            iFid = 1;
            fpInstance = new zkfp();
            RegTmps = new byte[3][];
            mfpWidth = 0;
            mfpHeight = 0;
            bIsTimeToDie = false;
            cbCapTmp = 2048;
            CapTmp = new byte[2048];
            RegTmp = new byte[2048];
            fingerPrintTemplate = string.Empty;
            paramValue = new byte[4];
        }
        static public void DisconnectDevice()
        {
            int result = fpInstance.CloseDevice();  // Close the connection
            
            if (result == zkfp.ZKFP_ERR_OK)
            {
                result = fpInstance.Finalize();   // Clear the resources
                if (result == zkfp.ZKFP_ERR_OK)
                {
                    reset();
                }
            }
        }

    }
}