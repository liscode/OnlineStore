using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class UploadFileController : Controller
    {
        //
        // GET: /UploadFile/

        //פונקציה שבודקת האם יש יוזר בסיג'יון, במידה ואין- מחזירה את דף הבית
        //במידה ויש מאפשרת למשתמש להעלות קובץ כלשהו
        public ActionResult Index()
        {
            if(Session["CurrentUser"] == null)
                return RedirectToAction(String.Empty, "Home");
            
            string connectionString = ConfigurationManager.ConnectionStrings["FilesCS"].ConnectionString;
            BL.BL bl = new BL.BL(connectionString);
            DataTable dt = bl.SelectUserFiles(Session["Id"].ToString());
            // להמיר דאטהטייבל לליסט
            UploadFile modelUploadFile = new UploadFile();
            modelUploadFile.Files = new List<FileUploadResponse>();
 
            //read data from DataTable 
            //using lamdaexpression
            foreach (DataRow row in dt.Rows)
            {
                FileUploadResponse fur = new FileUploadResponse();
                fur.Name = row["Name"].ToString();
                fur.Size = row["Size"].ToString();
                modelUploadFile.Files.Add(fur);
            }
            
            // להכניס את הליסט לליסט בתוך המודל
            return View("UploadFileView", modelUploadFile);
        }

        //פונקציה המאפשרת העלאת קובץ
        public ActionResult Upload()
        {
            if (Session["CurrentUser"] == null)
                return RedirectToAction(String.Empty, "Home");

            List<FileUploadResponse> listFileUploadResponse = new List<FileUploadResponse>();

            foreach (string fileName in Request.Files)
            {
                HttpPostedFileBase file = Request.Files[fileName];
                //Save file content goes here
                if (file != null && file.ContentLength > 0)
                {
                    FileUploadResponse fileUpload = new FileUploadResponse();
                    fileUpload.Name = Path.GetFileName(file.FileName);
                    fileUpload.Size = this.ConvertSize(file.ContentLength);

                    try
                    {
                        string originalDirectory = @"c:\temp\" + Session["Id"];

                        bool isExists = System.IO.Directory.Exists(originalDirectory);

                        if (!isExists)
                            System.IO.Directory.CreateDirectory(originalDirectory);

                        var path = string.Format("{0}\\{1}", originalDirectory, file.FileName);
                        file.SaveAs(path);

                        this.Insert(fileUpload.Name, fileUpload.Size, originalDirectory, Convert.ToInt32(Session["Id"]));
                        fileUpload.Message = "Success";
                    }
                    catch (Exception e)
                    {
                        fileUpload.Message = "Error";
                    }
                      
                    listFileUploadResponse.Add(fileUpload);
                }
            }

            string strJson = Newtonsoft.Json.JsonConvert.SerializeObject(listFileUploadResponse);
            return Json(strJson);
        }

        //פונקציה שמטרתה לקבל את הפרמטרים של הקובץ שהעלנו ולהכניס אותם לתוך הsql
        //בשדות המתאימים לפי הפרוצדורה הרלוונטית
        public void Insert(string name, string size, string path, int userID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FilesCS"].ConnectionString;
            BL.BL bl = new BL.BL(connectionString);
            DataTable dt = bl.InsertMetaDataUser(name, size, path, userID);
        }

        //פונקציה שמקבלת גודל של קובץ שהעלנו
        //וממירה אותו מיחידת מידה דאבל
        //לסטרינג
        public string ConvertSize(double bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            int order = 0;
            while (bytes >= 1024 && order + 1 < sizes.Length)
            {
                order++;
                bytes = bytes / 1024;
            }

            // Adjust the format string to your preferences. For example "{0:0.#}{1}" would
            // show a single decimal place, and no space.
            string result = String.Format("{0:0.##}{1}", Math.Round(bytes), sizes[order]);
            return result;
        }
    }
}
