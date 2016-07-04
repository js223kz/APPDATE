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
    public partial class ClientDetails : System.Web.UI.Page
    {
        //Create new Service object if it doesn´t already exists. 
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        //Create new WeekMenuService object if it doesn´t already exists. 
        private WeekMenuService _weekMenuService;

        private WeekMenuService WeekMenuService
        {
            get { return _weekMenuService ?? (_weekMenuService = new WeekMenuService()); }
        }
        
        //Display different kind of successmessages depending of object and action
        protected void Page_Load(object sender, EventArgs e)
        {
            PlaceHolder successMessage = Page.Master.FindControl("SuccessPlaceHolder") as PlaceHolder;
            Label successLabel = Page.Master.FindControl("SuccessLabel") as Label;
           
            if (Session["clientName"] != null)
            {
                successLabel.Text = Session["clientName"] as String;
                successMessage.Visible = true;
                Session.Remove("clientName");
            }
            else if (Session["weekMenuInsert"] != null)
            {
                successLabel.Text = Session["weekMenuInsert"] as String;
                successMessage.Visible = true;
                Session.Remove("weekMenuInsert");
            }
            else if (Session["weekNumber"] != null)
            {
                successLabel.Text = Session["weekNumber"] as String;
                successMessage.Visible = true;
                Session.Remove("weekNumber");
            }
            else
            {

            }
        }

        //Get specific client information
        public Client CustomerFormView_GetItem([RouteData] int id)
        {
            try
            {
                return Service.GetClientById(id);
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då kunden hämtades.");
                return null;
            }
        }

        //Get all weekmenues listed on client
        public IEnumerable<WeekMenu> WeekMenuListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount, [RouteData] int id)
        {
            
                return WeekMenuService.GetWeekMenuByClientId(maximumRows, startRowIndex, out totalRowCount, id);
         }
    }
}