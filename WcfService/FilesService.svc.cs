using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
   
    public class FilesService : IFilesService
    {
        public string InsertMetaDataJson(string name, string size, string path)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Files"].ConnectionString;
            BL.BL bl = new BL.BL(connectionString);
            string metaDataJson = bl.InsertMetaDataJson(name, size, path);
            return metaDataJson;
        }
    }
}
