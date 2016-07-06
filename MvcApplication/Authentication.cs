using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

namespace MvcApplication
{
    public class Authentication
    {
        public const string SECRET_KEY = "25f2cd55-496b-4e2a-9e64-7f110fae3378";

        public static string sha256(string text)
        {            
            System.Security.Cryptography.SHA256Managed crypt = new System.Security.Cryptography.SHA256Managed();
            System.Text.StringBuilder hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(text), 0, Encoding.UTF8.GetByteCount(text));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }

        public static bool SignIn(string email, string password)
        {
            BL.BL bl = new BL.BL("dasdada");
            DataTable dt = bl.GetSaltAndHashResult(email);
            //יצור salt
            string salt = dt.Rows[0]["salt"].ToString();
            string hashResultFromDB = dt.Rows[0]["hashResult"].ToString();
            string hashResultFromCSharp = sha256(password + salt + SECRET_KEY);
            bool isAuthenticate = hashResultFromDB == hashResultFromCSharp;

            return isAuthenticate;
        }
    }
}