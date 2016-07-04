using AppDate.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AppDate.Pages.ClientPages
{
    public partial class AddClient : System.Web.UI.Page
    {
        //Create new Service object if it doesn´t already exists. 
        private Service _service;

        private Service Service
        {
            get { return _service ?? (_service = new Service()); }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Add a new client if success show a successmessage
        public void ClientFormView_InsertItem(Client client)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    Service.SaveClient(client);
                    PlaceHolder successMessage = Page.Master.FindControl("SuccessPlaceHolder") as PlaceHolder;
                    Label successLabel = Page.Master.FindControl("SuccessLabel") as Label;
                    successLabel.Text = String.Format("{0}{1}{2}", "Kunden ", client.Name, " sparades.");
                    successMessage.Visible = true;

                    Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "resetFields()", true);
                }
                catch (Exception)
                {

                    ModelState.AddModelError(String.Empty, "Fel inträffade då kunden skulle läggas till.");
                }
            }
        }
    }
}