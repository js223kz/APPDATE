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
    public partial class EditWeekMenu : System.Web.UI.Page
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

        //Get specific weekmenu to edit
        public AppDate.Model.BLL.WeekMenu EditWeekMenuFormView_GetItem([RouteData]int id, [RouteData]int weekid)
        {
            try
            {
                return WeekMenuService.GetWeekMenuById(id, weekid);
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då veckomenyn hämtades för redigering");
                return null;
            }

        }

        //Update weekmenu if it exists
        public void EditWeekMenuFormView_UpdateItem(WeekMenu weekMenu)
        {
            try
            {
                var week = WeekMenuService.GetWeekMenuById(weekMenu.ClientId, weekMenu.WeekId);
                if (week == null)
                {

                    ModelState.AddModelError(String.Empty,
                        String.Format("Veckomeny med veckonummer {0} hittades inte.", weekMenu.Weeknumber));
                    return;
                }

                if (TryUpdateModel(week))
                {
                    WeekMenuService.UpdateWeekMenu(week);

                    //Save successmessage in session to be displayed when weekmenu updated
                    Session["weekNumber"] = String.Format("{0}{1}{2}", "Vecka: ", week.Weeknumber, " uppdaterades");

                    Response.RedirectToRoute("ClientDetails", new { id = weekMenu.ClientId });
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Fel inträffade då veckomenyn skulle uppdateras.");
            }
        }
    }
}