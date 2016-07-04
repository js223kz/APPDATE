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
    public partial class DeleteClient : System.Web.UI.Page
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
        
        //get specific client
        public Client CustomerFormView_GetItem([RouteData]int id)
        {
            try
            {
                return Service.GetClientById(id); 

            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Fel inträffade då kunden skulle hämtas.");
                return null;
            }
            
        }

        //Delete client from database
        protected void DeleteButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var id = int.Parse(e.CommandArgument.ToString());
                var client = Service.GetClientById((int)id);
       
                Service.DeleteClient(id);

                //Save client name in session to be displayed in successmessage
                Session["clientName"] = String.Format("{0}{1}{2}", "Kunden ", client.Name, " raderades.");
                Response.RedirectToRoute("Default", null);
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då kunden skulle tas bort.");
            }
        }
    }
}