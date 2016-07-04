using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace AppDate.Model.DAL
{
    public class BaseDAL
    {

        private static string _connectionsString;

        //Constructor get connections string from web config
        static BaseDAL()
        {
            _connectionsString = WebConfigurationManager.ConnectionStrings["WP14_js223kz_IA_AppdateConnectionString"].ConnectionString;
        }

        //Instansiates new sqlconnection
        protected static SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionsString);
        }

        //Method that validates and lists dataannotatios in classes client and Weekmenu
        public bool Validate(out ICollection<ValidationResult> validationResults)
        {
            var validationContext = new ValidationContext(this);
            validationResults = new List<ValidationResult>();
            return Validator.TryValidateObject(this, validationContext, validationResults, true);
        }
    }
}