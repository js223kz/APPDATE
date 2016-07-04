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
    public partial class WeekMenuDetails : System.Web.UI.Page
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

        //Get specific weekmenu
        public AppDate.Model.BLL.WeekMenu WeekMenuFormView_GetItem([RouteData]int id, [RouteData]int weekid)
        {
            try
            {
                return WeekMenuService.GetWeekMenuById(id, weekid);
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då veckodetaljer skulle läsas in.");
                return null;
            }
        }

    }
}