using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        //actionresult האבא של
        //ViewResult

        //פונקציה אשר מציגה/מחזירה את דף יצירת משתמש חדש לצורך הרשמה
        public ViewResult SignUp()
        {
            SignUp modelSignUp = new SignUp();
            return View("SignUpView", modelSignUp);
        }

        //פונקציה אשר מסירה את המשתמש הנוכחי שנמצא- עם המייל, השם שלו והאיידי, ומבצעת "התנתקות"
        //למשתמש ומחזירה את דף הבית עם אפשרות להתחברות מחדש
        public ActionResult SignOut()
        {
            Session.Remove("CurrentUser");
            Session.Remove("FirstName");
            Session.Remove("Id");

            return RedirectToAction(String.Empty, "Home");
        }

        //פונקציה שנועדה לבדוק האם המשתמש שהכניס פרטים קיים,
        //במידה וכן- מאפשרת לו התחברות שם הפרטים שלו לאתר
        //הפונקציה מקבלת אמייל וסיסמא מהמשתמש
        //אנחנו יוצרים משתנה -ביאל ולתוכו נכניס את הקונקשיין סטרינג
        //עושים בדיקה האם האימייל שהכנסנו קיים ב-דיטי
        //במידה ולא קיים יוזר כזה נחזור לדף הבית
        //
        [HttpPost]//נשלח בבקשה מאחורי הקלעים
        public ActionResult SignIn(string email, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FilesCS"].ConnectionString;
            BL.BL bl = new BL.BL(connectionString);
            DataTable dt = bl.SelectUser(email);

            if (dt.Rows.Count == 0)
                return RedirectToAction(String.Empty, "Home");

            //במידה והמשתמש קיים הולכים לשורה שמצאנו מsql
            //ומביאים את הפרטים של המשתמש
            //מבצעים בדיקה האם הסיסמא, הסאלט ומפתח יחד יוצרים את האש ריזאלט,
            //במידה ולא- חוזרים לדף הבית ללא התחברות, במידה וכן חוזרים חדף הבית עם התחברות
            DataRow row = dt.Rows[0];
            string id = row["ID"].ToString();
            string firstName = row["FirstName"].ToString();
            string loginSaltFromDB = row["LoginSalt"].ToString();
            string loginHashFromDB = row["LoginHash"].ToString();

            string hashResult = Authentication.sha256(password + loginSaltFromDB + Authentication.SECRET_KEY);

            if (loginHashFromDB != hashResult)
                return RedirectToAction(String.Empty, "Home");

            //משתנה session
            // נועד על מנת לאכסן מידע על המחשב הנוכחי שבאמצעותו הוא מופעל
            SetSessionValues(id.ToString(), email, firstName);

            return RedirectToAction("Index", "Home");
        }

        //פונקציה המקבלת את המייל/שם המשתמש ומחזיר סטרינג האם המייל קיים ונמצא או שלא
        [HttpPost]
        public string IsEmailExists(string email)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["FilesCS"].ConnectionString;
            BL.BL bl = new BL.BL(connectionString);
            DataTable dt = bl.SelectUser(email);

            string result;

            if (dt.Rows.Count == 0)
                result = "{ \"found\" : \"false\" }";                   
            else
                result = "{ \"found\" : \"true\" }";

            return result;
        }

        //פונקציה המאפשרת למשתמש חדש להירשם
        //הפונקציה מקבלת את הפרטים הרצויים, מבצעת ולידציה שהפרטים תקינים
        //במידה ואחד מהם לא תקין חוזרים למסך ההרשמה
        [HttpPost]
        public ActionResult Submit(string firstName, string lastName, string email, string password)
        {
            bool isFirstNameValid = !string.IsNullOrEmpty(firstName) && firstName.Length >= 2;
            bool isLastNameValid = !string.IsNullOrEmpty(lastName) && lastName.Length >= 2;
            bool isEmailValid = !string.IsNullOrEmpty(email) && this.IsValidEmail(email);
            bool isPasswordValid= !string.IsNullOrEmpty(password) && password.Length >= 6;

            if (!isFirstNameValid || !isLastNameValid|| !isEmailValid || !isPasswordValid)
            {
                SignUp modelSignUp = new SignUp();
                return View("SignUpView", modelSignUp);
            }

            //במידה והערכים תקינים
            //יוצרים הצפנה של הכל
            string loginSalt = Guid.NewGuid().ToString();
            string hashResult = Authentication.sha256(password + loginSalt + Authentication.SECRET_KEY);

            //שולחים למאגר את הפרמטרים הרצויים של המשתמש שיצרנו
            string connectionString = ConfigurationManager.ConnectionStrings["FilesCS"].ConnectionString;
            BL.BL bl = new BL.BL(connectionString);
            long id = bl.InsertUser(firstName, lastName, email, null, loginSalt, hashResult);
            if (id == -1)
            {
                SignUp modelSignUp = new SignUp();
                return View("SignUpView", modelSignUp);
            }

            SetSessionValues(id.ToString(), email, firstName);

            return RedirectToAction(String.Empty, "Home");
        }

        //פונקציה שמקבלת את האידי, האימייל והשם
        //ומעבירה את הערכים הללו לסאזיון
        private void SetSessionValues(string id, string email, string firstName)
        {
            Session["Id"] = id;
            Session["CurrentUser"] = email;
            Session["FirstName"] = firstName;            
        }

        //פונקציה שמוודא שהמייל שהמשתמש מכניס חוקי
        private bool IsValidEmail(string email)
        {
            string validEmailPattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
       + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
       + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

           Regex regEmail = new Regex(validEmailPattern, RegexOptions.IgnoreCase);

           bool isValid = regEmail.IsMatch(email);

           return isValid;
        }

    }
}
