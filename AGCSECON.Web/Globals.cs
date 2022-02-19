using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace AGCSECON.Web
{
    public static class Globals
    {

        public static string g_ReadFile(string sFullPath, bool bDetectEncoding = false, System.Text.Encoding oEncoding = null)
        {
            StreamReader oReader = null;
            if (bDetectEncoding == false)
            {
                if (oEncoding == null)
                {
                    oReader = new StreamReader(sFullPath);
                }
                else
                {
                    oReader = new StreamReader(sFullPath, oEncoding);
                }
            }
            else
            {
                oReader = new StreamReader(sFullPath, true);
            }
            string sReturn = oReader.ReadToEnd();
            oReader.Close();
            return sReturn;
        }

        public static void g_WriteFile(string sFullPath, string sFileContents, System.Text.Encoding oEncoding = null)
        {
            StreamWriter oWriter = null;
            if (oEncoding == null)
            {
                oWriter = new StreamWriter(sFullPath);
            }
            else
            {
                oWriter = new StreamWriter(sFullPath, false, oEncoding);
            }
            oWriter.Write(sFileContents);
            oWriter.Close();
        }

    }
}