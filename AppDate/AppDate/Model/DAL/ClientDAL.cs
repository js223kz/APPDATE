using AppDate.Model.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppDate.Model.DAL
{
    public class ClientDAL : BaseDAL
    {

        //Gets client by primary key from database
        public Client GetClientById(int clientId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_GetClientById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@Clientid", clientId);

                    conn.Open();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            int clientIndex = reader.GetOrdinal("Clientid");
                            int nameIndex = reader.GetOrdinal("Name");
                            int addressIndex = reader.GetOrdinal("Address");
                            int zipcodeIndex = reader.GetOrdinal("Zipcode");
                            int cityIndex = reader.GetOrdinal("City");
                            int userNameIndex = reader.GetOrdinal("Username");
                            int passwordIndex = reader.GetOrdinal("Password");
                            int contactPersonIndex = reader.GetOrdinal("Contactperson");
                            int phoneIndex = reader.GetOrdinal("Phone");
                            int emailIndex = reader.GetOrdinal("Email");
                            int vatIndex = reader.GetOrdinal("Vatnumber");

                            // Returnerar referensen till de skapade Client-objektet.
                            return new Client
                            {
                                ClientId = reader.GetInt32(clientIndex),
                                Name = reader.GetString(nameIndex),
                                Address = reader.GetString(addressIndex),
                                Zipcode = reader.GetInt32(zipcodeIndex),
                                City = reader.GetString(cityIndex),
                                UserName = reader.GetString(userNameIndex),
                                PassWord = reader.GetString(passwordIndex),
                                ContactPerson = reader.GetString(contactPersonIndex),
                                Phone = reader.GetString(phoneIndex),
                                EmailAddress = reader.GetString(emailIndex),
                                Vatnumber = reader.GetString(vatIndex)
                            };
                        }
                    }

                    return null;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("Ett fel inträffade vid hämtning av kund från databas");
                }
            }
        }

        //Gets clients and lists them 5 at a time
        public IEnumerable<Client> GetClientsPageWise(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            var clients = new List<Client>(100);

            try
            {
                using (var connection = CreateConnection())
                {
                    var cmd = new SqlCommand("appSchema.usp_GetClientsPageWise", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PageSize", SqlDbType.Int, 4).Value = maximumRows;
                    cmd.Parameters.Add("@PageIndex", SqlDbType.Int, 4).Value = startRowIndex / maximumRows + 1;
                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    connection.Open();


                    using (var reader = cmd.ExecuteReader())
                    {
                        var clientIDIndex = reader.GetOrdinal("Clientid");
                        var nameIndex = reader.GetOrdinal("Name");
                        var addressIndex = reader.GetOrdinal("Address");
                        var zipCodeIndex = reader.GetOrdinal("Zipcode");
                        var cityIndex = reader.GetOrdinal("City");

                        while (reader.Read())
                        {
                            clients.Add(new Client
                            {
                                ClientId = reader.GetInt32(clientIDIndex),
                                Name = reader.GetString(nameIndex),
                                Address = reader.GetString(addressIndex),
                                Zipcode = reader.GetInt32(zipCodeIndex),
                                City = reader.GetString(cityIndex)
                            });
                        }

                    }
                    totalRowCount = (int)cmd.Parameters["@RecordCount"].Value;
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("Kundlistan kunde inte hämtas från databasen.");
            }
            clients.TrimExcess();
            return clients;
        }

        //Adds a new client to database
        public void InsertClient(Client client)
        {

            try
            {
                using (var connection = CreateConnection())
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_InsertClient", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Add parameters that the stored procedure requests
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = client.Name;
                    cmd.Parameters.Add("@Address", SqlDbType.VarChar, 30).Value = client.Address;
                    cmd.Parameters.Add("@Zipcode", SqlDbType.Int, 4).Value = client.Zipcode;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar, 25).Value = client.City;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 15).Value = client.UserName;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 10).Value = client.PassWord;
                    cmd.Parameters.Add("@Contactperson", SqlDbType.VarChar, 40).Value = client.ContactPerson;
                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 11).Value = client.Phone;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = client.EmailAddress;
                    cmd.Parameters.Add("@Vatnumber", SqlDbType.Char, 11).Value = client.Vatnumber;

                    //ContactID is primarykey, set direction to output
                    cmd.Parameters.Add("@Clientid", SqlDbType.Int, 4).Direction = ParameterDirection.Output;

                    connection.Open();
                    cmd.ExecuteNonQuery();

                    client.ClientId = (int)cmd.Parameters["@Clientid"].Value;
                }
            }
            catch
            {

                throw new ApplicationException("Ett fel inträffade när kunden skulle läggas till i databasen.");
            }

        }

        //Edits client information in database
        public void UpdateClient(Client client)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_UpdateClient", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Clientid", SqlDbType.Int, 4).Value = client.ClientId;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar, 50).Value = client.Name;
                    cmd.Parameters.Add("@Address", SqlDbType.VarChar, 30).Value = client.Address;
                    cmd.Parameters.Add("@Zipcode", SqlDbType.Int, 4).Value = client.Zipcode;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar, 25).Value = client.City;
                    cmd.Parameters.Add("@Username", SqlDbType.VarChar, 15).Value = client.UserName;
                    cmd.Parameters.Add("@Password", SqlDbType.VarChar, 10).Value = client.PassWord;
                    cmd.Parameters.Add("@Contactperson", SqlDbType.VarChar, 40).Value = client.ContactPerson;
                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar, 11).Value = client.Phone;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar, 50).Value = client.EmailAddress;
                    cmd.Parameters.Add("@Vatnumber", SqlDbType.Char, 11).Value = client.Vatnumber;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {

                    throw new ApplicationException("Ett fel inträffade i databasen när kunden skulle uppdateras.");
                }
            }
        }

        //Deletes client from database
        public void DeleteClient(int clientId)
        {

            using (var connection = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.usp_DeleteClient", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ClientID", SqlDbType.Int, 4).Value = clientId;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch
                {

                    throw new ApplicationException("Ett fel inträffade när kunden skulle raderas från databasen.");
                }
            }
        }
    }
}
