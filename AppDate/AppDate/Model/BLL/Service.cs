using AppDate.Model.DAL;
using AppDate.Model.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AppDate.Model.BLL
{
    //Class that handles communication between code behind and Client DAL
    public class Service
    {
       
        //Instansiate an object of type ClientDAL if it doesn´t exist otherwise use the that exits.
        private ClientDAL _clientDAL;

        private ClientDAL ClientDAL
        {
            get { return _clientDAL ?? (_clientDAL = new ClientDAL()); }
        }


        //Get specific client
        public Client GetClientById(int id)
        {
            return ClientDAL.GetClientById(id);
        }

        public void DeleteClient(int id)
        {
            ClientDAL.DeleteClient(id);
        }

        //Get all clients
        public IEnumerable<Client> GetClientsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            
            return ClientDAL.GetClientsPageWise(maximumRows, startRowIndex, out totalRowCount);
        }

        //Add or update a client. If client has id of 0 it's new and 
        //therefore do an insert else update existing client 
        //based on clientid
        public void SaveClient(Client client)
        {
            ICollection<ValidationResult> validationResults;
            if (!client.Validate(out validationResults)) 
            {                                              
                var ex = new ValidationException("Objektet klarade inte valideringen.");
                ex.Data.Add("ValidationResults", validationResults);
                throw ex;
            }

            if (client.ClientId == 0)
            {
                ClientDAL.InsertClient(client);
            }
            else
            {
                ClientDAL.UpdateClient(client);
            }
        }


    }
}