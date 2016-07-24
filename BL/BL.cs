using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class BL
    {
        //ניצור משתנה פרטי מטיפוס דיביקונקשיין בשם דיביקון
        private DAL.DbConnection dbConn;

        //קונסטרקטור המקבל את הקונקשיין סטרינג 
        //יוצרים מופע של דיביקונקשיין, שולחים לקונסטרקטור שלו את הקונקשיין סטרינג
        //וחוזר מופע שנכנס לדיביקון
        public BL(string connectionString)
        {
            this.dbConn = new DAL.DbConnection(connectionString);
        }

        //function- get name, size, path, and userid 
        //and active procedure in sql
        public DataTable InsertMetaDataUser(string name, string size, string path, int userID)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter paramName = new SqlParameter();
            paramName.ParameterName = "Name";
            paramName.Value = name;
            //כיוון הפרמטר שנשלח לפרוצדורה
            paramName.Direction = ParameterDirection.Input;

            SqlParameter paramSize = new SqlParameter();
            paramSize.ParameterName = "Size";
            paramSize.Value = size;
            paramSize.Direction = ParameterDirection.Input;

            SqlParameter paramPath = new SqlParameter();
            paramPath.ParameterName = "Path";
            paramPath.Value = path;
            paramPath.Direction = ParameterDirection.Input;

            SqlParameter paramUserID = new SqlParameter();
            paramUserID.ParameterName = "UserID";
            paramUserID.Value = userID;
            paramUserID.Direction = ParameterDirection.Input;

            parameters.Add(paramName);
            parameters.Add(paramSize);
            parameters.Add(paramPath);
            parameters.Add(paramUserID);

            DataTable dt = this.dbConn.ExecSP("dbo.InsertMetaDataUser",parameters);

            return dt;
        }

        //like last function, gets parameters and add them to sql
       // this function create new user
        //get all parmeter and return the userid that create
        public long InsertUser(string firstname, string lastname, string email, string role, string loginSalt, string loginHash)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter paramFirstName = new SqlParameter();
            paramFirstName.ParameterName = "FirstName";
            paramFirstName.Value = firstname;
            paramFirstName.Direction = ParameterDirection.Input;

            SqlParameter paramLastName = new SqlParameter();
            paramLastName.ParameterName = "LastName";
            paramLastName.Value = lastname;
            paramLastName.Direction = ParameterDirection.Input;

            SqlParameter paramEmail = new SqlParameter();
            paramEmail.ParameterName = "Email";
            paramEmail.Value = email;
            paramEmail.Direction = ParameterDirection.Input;

            SqlParameter paramRole = new SqlParameter();
            paramRole.ParameterName = "Role";
            this.SetSqlParameterValue(paramRole, role);
            paramRole.Direction = ParameterDirection.Input;

            SqlParameter paramLoginSalt = new SqlParameter();
            paramLoginSalt.ParameterName = "LoginSalt";
            paramLoginSalt.Value = loginSalt;
            paramLoginSalt.Direction = ParameterDirection.Input;

            SqlParameter paramLoginHash = new SqlParameter();
            paramLoginHash.ParameterName = "LoginHash";
            paramLoginHash.Value = loginHash;
            paramLoginHash.Direction = ParameterDirection.Input;

            SqlParameter paramID = new SqlParameter();
            paramID.ParameterName = "ID";
            paramID.Value = DBNull.Value;
            paramID.Direction = ParameterDirection.Output;
            paramID.Size = 50;

            parameters.Add(paramFirstName);
            parameters.Add(paramLastName);
            parameters.Add(paramEmail);
            parameters.Add(paramRole);
            parameters.Add(paramLoginSalt);
            parameters.Add(paramLoginHash);
            parameters.Add(paramID);

            DataTable dt = this.dbConn.ExecSP("dbo.InsertUser", parameters);

            long id = Convert.ToInt64(paramID.Value);
            return id;
        }

        public DataTable SelectProduct(string categoryName, string subCategoryName, int minRow, int maxRow)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter paramCategoryName = new SqlParameter();
            paramCategoryName.ParameterName = "CategoryName";
            paramCategoryName.Value = categoryName;
            paramCategoryName.Direction = ParameterDirection.Input;

            SqlParameter paramSubCategoryName = new SqlParameter();
            paramSubCategoryName.ParameterName = "SubCategoryName";
            paramSubCategoryName.Value = subCategoryName;
            paramSubCategoryName.Direction = ParameterDirection.Input;

            SqlParameter paramMinRow = new SqlParameter();
            paramMinRow.ParameterName = "MinRow";
            paramMinRow.Value = minRow;
            paramMinRow.Direction = ParameterDirection.Input;

            SqlParameter paramMaxRow = new SqlParameter();
            paramMaxRow.ParameterName = "MaxRow";
            paramMaxRow.Value = maxRow;
            paramMaxRow.Direction = ParameterDirection.Input;

            parameters.Add(paramCategoryName);
            parameters.Add(paramSubCategoryName);
            parameters.Add(paramMinRow);
            parameters.Add(paramMaxRow);

            DataTable dt = this.dbConn.ExecSP("SelectProduct", parameters);
            return dt;
        }

        public DataTable SelectUser(string email)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter paramEmail = new SqlParameter();
            paramEmail.ParameterName = "Email";
            paramEmail.Value = email;
            paramEmail.Direction = ParameterDirection.Input;

            parameters.Add(paramEmail);

            DataTable dt = this.dbConn.ExecSP("dbo.SelectUser", parameters);

            return dt;
        }

        private void SetSqlParameterValue(SqlParameter param, string value)
        {
            if (String.IsNullOrEmpty(value))
                param.Value = DBNull.Value;
            else
            {
                param.Value = value;
            }
        }

        //function- get userid 
        //and active procedure in sql
        public DataTable SelectUserFiles(string userID)
        {
            //Create list-sqlparameter to add the parameter teth we want
            //from here- list moved to dal, dal move to move to sql whit the parmeter that we want
            List<SqlParameter> parameters = new List<SqlParameter>();

            SqlParameter paramUserID = new SqlParameter("UserID", userID);
            //direction parameter that send to procidure
            paramUserID.Direction = ParameterDirection.Input;

            //הוספת הפרמטר לרשימה
            parameters.Add(paramUserID);

            DataTable dt = this.dbConn.ExecSP("dbo.SelectUserFiles", parameters);

            return dt;
        }
       
    }
}
