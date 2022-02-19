using System.IO;
using System.Web;

namespace AGCSECON.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;


    // TODO: Create methods containing your application logic.
    [EnableClientAccess()]
    public class MSP2007Service : DomainService
    {
        private string mp_GetPath()
        {
            return HttpContext.Current.Request.MapPath(HttpContext.Current.Request.ApplicationPath) + "\\MSP2007\\";
        }

        [Invoke()]
        public string GetXML(string sFileName)
        {
            string sReturn = Globals.g_ReadFile(mp_GetPath() + sFileName);
            return sReturn;
        }

        [Invoke()]
        public string GetFileList()
        {
            DirectoryInfo oDirectory = new DirectoryInfo(mp_GetPath());
            FileInfo oFile = null;
            string sReturn = "";
            foreach (FileInfo oFile_loopVariable in oDirectory.GetFiles("*.xml"))
            {
                oFile = oFile_loopVariable;
                sReturn = sReturn + oFile.Name + "|";
            }
            if (sReturn.Length > 0)
            {
                sReturn = sReturn.Substring(0, sReturn.Length - 1);
            }
            return sReturn;
        }
    }
}


