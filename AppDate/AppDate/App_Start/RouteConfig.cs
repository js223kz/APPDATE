using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace AppDate
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute("Default", 
                "Kundlista/Alla", 
                "~/Pages/ClientPages/Listing.aspx");
            
            routes.MapPageRoute("AddClient", 
                "Ny/kund", 
                "~/Pages/ClientPages/AddClient.aspx");

            routes.MapPageRoute("ClientDetails",
                "Kund/{id}",
                "~/Pages/ClientPages/ClientDetails.aspx");
            
            routes.MapPageRoute("DeleteClient",
                "Radera kund/{id}",
                "~/Pages/ClientPages/DeleteClient.aspx");
            
            routes.MapPageRoute("AddWeekMenu",
                "Ny/veckomeny/{id}", 
                "~/Pages/ClientPages/AddWeekMenu.aspx");

            routes.MapPageRoute("WeekMenuDetails",
                "Veckomeny/Vecka {weekid}/{id}",
                "~/Pages/ClientPages/WeekMenuDetails.aspx");

            routes.MapPageRoute("DeleteWeekMenu",
                "Radera veckomeny/{weekid}/{id}",
                "~/Pages/ClientPages/DeleteWeekMenu.aspx");
            
            routes.MapPageRoute("EditClient",
                "Redigera/kund/{id}", 
                "~/Pages/ClientPages/EditClient.aspx");
            
            routes.MapPageRoute("EditWeekMenu",
                "Redigera/veckomeny/{id}/{weekid}", 
                "~/Pages/ClientPages/EditWeekMenu.aspx");
        }
    }
}