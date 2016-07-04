using AppDate.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppDate.Pages
{
    public partial class DeleteWeekMenu : System.Web.UI.Page
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

        //Get specific weekmenu to delete
        public AppDate.Model.BLL.WeekMenu DeleteWeekMenuFormView_GetItem([RouteData]int id, [RouteData]int weekid)
        {
            try
            {
                return WeekMenuService.GetWeekMenuById(id, weekid); 
        
            }
            catch (Exception)
            {
                
               ModelState.AddModelError(String.Empty, "Fel inträffade då veckomenyn skulle tas hämtas.");
               return null;
            }
        }   

        //Delete specific weekmenu
        protected void DeleteButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                string[] arguments = e.CommandArgument.ToString().Split(new char[] { ',' });
                int clientId = int.Parse(arguments[0]);
                int weekId = int.Parse(arguments[1]);

                var week = WeekMenuService.GetWeekMenuById(clientId, weekId);
                WeekMenuService.DeleteWeekMenu(clientId, weekId);

                //Keep successmessage in session to display when weekmenu is usccessfully deleted
                Session["weekNumber"] = String.Format("{0}{1}{2}", "Veckomeny vecka ", week.Weeknumber, " raderades.");
                Response.RedirectToRoute("ClientDetails", clientId);
            }
            catch (Exception)
            {
                
                ModelState.AddModelError(String.Empty, "Fel inträffade då veckomenyn skulle tas bort.");
            }
        }
    }
}