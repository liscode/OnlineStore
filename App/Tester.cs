using MvcApplication.Controllers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Tester
    {
        //קלאס טסטר נועד על מנת לבצע בדיקות של הפונקציות והמשתנים השונים שכתבנו בפרוייקט
        static void Main(string[] args)
        {
            //connect to bl and send the connectionString to bl
            //Through the connectionString the project know what we want to run
            string connectionString = ConfigurationManager.ConnectionStrings["FilesCS"].ConnectionString;
            BL.BL bl = new BL.BL(connectionString);

            //string str = bl.InsertMetaDataJson("lll", "10m", "sss");
            //long id = bl.InsertUserLogin("yoram", "ab", "yoram12@gmail.com", null, "aa", "kk");

            //string hash = MvcApplication.Authentication.sha256("1");
            //string hash2 = MvcApplication.Authentication.sha256("1");            

            ProductController pc = new ProductController();
            pc.SelectProduct("Flowers", "Bouquets", 1, 3);
            
        }
    }
}
