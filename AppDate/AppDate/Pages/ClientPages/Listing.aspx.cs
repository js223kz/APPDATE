using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppDate.Model.BLL;

namespace AppDate.Pages.ClientPages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //Create new Service object if it doesn´t already exists. 
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["clientName"] != null)
            {
                //Display message if client is deleted
                PlaceHolder successMessage = Page.Master.FindControl("SuccessPlaceHolder") as PlaceHolder;
                Label successLabel = Page.Master.FindControl("SuccessLabel") as Label;
                successLabel.Text = Session["clientName"] as String;

                successMessage.Visible = true;
                Session.Remove("clientName");
            }
            
        }
       
        //get all clients in database
        public IEnumerable<Client> ClientListView_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
           
                return Service.GetClientsPageWise(maximumRows, startRowIndex, out totalRowCount);
        }

    }
}