using AppDate.Model.DAL;
using AppDate.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppDate.Model.BLL
{
    //Class that handles all communication between code behind and WeekmenuDAL and WeekDAL
    public class WeekMenuService
    {
        //Instansiate an object of type WeekmenuDAL if it doesn´t exist otherwise use the that exits.
        private WeekMenuDAL _weekMenuDAL;

        private WeekMenuDAL WeekMenuDAL
        {
            get { return _weekMenuDAL ?? (_weekMenuDAL = new WeekMenuDAL()); }
        }

        //Instansiate an object of type and WeekDAL if it doesn´t exist otherwise use the that exits.
        private WeekDAL _weekDAL;

        private WeekDAL WeekDAL
        {
            get { return _weekDAL ?? (_weekDAL = new WeekDAL()); }
        }

        //Get all weekmenues from specific client
        public IEnumerable<WeekMenu> GetWeekMenuByClientId(int maximumRows, int startRowIndex, out int totalRowCount, int clientId)
        {
            return WeekMenuDAL.GetWeekMenuByClientId(maximumRows, startRowIndex, out totalRowCount, clientId);
        }

        //Get specific weekmenu
        public WeekMenu GetWeekMenuById(int clientId, int weekId)
        {
            return WeekMenuDAL.GetWeekMenuById(clientId, weekId);
        }

        //Get all weeks that exists in database if today is later than week enddate
        public IEnumerable<Week> GetWeeks(int id)
        {
            return WeekDAL.GetWeeks(id);
        }

        ICollection<ValidationResult> validationResults;

        //Add weekmenu
        public void InsertWeekMenu(WeekMenu weekMenu, int id)
        {
            //Validate incoming object
            if (!weekMenu.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            WeekMenuDAL.InsertWeekMenu(weekMenu, id);
        }

        //Edit weekmenu information 
        public void UpdateWeekMenu(WeekMenu weekMenu)
        {
            //Validate incoming object
            if (!weekMenu.Validate(out validationResults))
            {
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }
            WeekMenuDAL.UpdateWeekMenu(weekMenu);
        }

        //Delete actual weekmenu from database.
        public void DeleteWeekMenu(int clientId, int weekId)
        {
            WeekMenuDAL.DeleteWeekMenu(clientId, weekId);
        }
    }
}