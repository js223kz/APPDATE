using AppDate.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppDate.Pages.ClientPages
{
    public partial class AddWeekMenu : System.Web.UI.Page
    {

        //Create new WeekMenuService object if it doesn´t already exists. 
       private WeekMenuService _weekMenuService;

        private WeekMenuService WeekMenuService
        {
            get { return _weekMenuService ?? (_weekMenuService = new WeekMenuService()); }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        //Display weeks by weeknumber in dropdown list if it doesn´t already exist i client weekmenutable
        public IEnumerable<Week> WeeksDropDownList_GetData([RouteData]int id)
        {
           
            try
            {
                return WeekMenuService.GetWeeks(id); 
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Fel inträffade då veckolistan hämtades.");
                return null;
            }
        }

        //Add new weekmenu to client in weekmenu table. Send in two clientid and weekid as primary key
        public void AddWeekMenuFormView_InsertItem(WeekMenu weekMenu, [RouteData]int id)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    WeekMenuService.InsertWeekMenu(weekMenu, id);

                    DropDownList dropDownListValue = (DropDownList)AddWeekMenuFormView.FindControl("WeeksDropDownList");

                    //Save sucessmessage in session to be displayed in clientdetails page
                    Session["weekMenuInsert"] = "Veckomenyn sparades.";

                    Response.RedirectToRoute("ClientDetails", id);
                }
                catch (Exception)
                {
                    
                     ModelState.AddModelError(String.Empty, "Fel inträffade då veckomenyn skulle läggas till.");
                }
            }
           
        }
    }
}