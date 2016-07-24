using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index(string cat, string subcat)
        {
            Product modelProduct = new Product();
            modelProduct.Cat = cat;
            modelProduct.SubCat = subcat;
            return View("ProductView", modelProduct);
        }

        [HttpPost]
        public string SelectProduct(string categoryName, string subCategoryName, int minRow, int maxRow)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FilesCS"].ConnectionString;
            BL.BL bl = new BL.BL(connectionString);
            DataTable dt = bl.SelectProduct(categoryName, subCategoryName, minRow, maxRow);
            // DataTable to Json
            string strJson = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
            return strJson;
        }
    }
}


