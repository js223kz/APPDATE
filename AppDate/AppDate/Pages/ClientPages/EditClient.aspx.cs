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
    public partial class EditClient : System.Web.UI.Page
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

        //Get specific client to edit
        public Client ClientFormView_GetItem([RouteData]int id)
        {
            try
            {
                return Service.GetClientById(id);
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Fel inträffade då kunden hämtades för redigering");
                return null;
            }
        }

        //Update client if exists
        public void ClientFormView_UpdateItem(int ClientId)
        {
            try
            {
                var client = Service.GetClientById(ClientId);
                if (client == null)
                {
                    // Hittade inte kunden.
                    ModelState.AddModelError(String.Empty,
                        String.Format("Kunden med kundnummer {0} hittades inte.", ClientId));
                    return;
                }


                if (TryUpdateModel(client))
                {
                    Service.SaveClient(client);
                    Session["clientName"] = String.Format("{0}{1}{2}", "Kunden ", client.Name, " uppdaterades.");

                    Response.RedirectToRoute("ClientDetails", new { id = client.ClientId });
                }
            }
            catch (Exception)
            {

                ModelState.AddModelError(String.Empty, "Fel inträffade då kunden skulle uppdateras.");
            }
        }
    }
}