using System;
using AppDate.Model.BLL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace AppDate.Model.DAL
{
    public class WeekMenuDAL : BaseDAL
    {
        //Gets all weekmenues from database and displays them one week/page
        public IEnumerable<WeekMenu> GetWeekMenuByClientId(int maximumRows, int startRowIndex, out int totalRowCount, int clientId)
        {
            var weekMenues = new List<WeekMenu>(32);

            using (var connection = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.usp_GetWeekMenuByClientId", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@PageSize", SqlDbType.Int, 4).Value = maximumRows;
                    cmd.Parameters.Add("@PageIndex", SqlDbType.Int, 4).Value = startRowIndex / maximumRows + 1;
                    cmd.Parameters.Add("@RecordCount", SqlDbType.Int, 4).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@ClientId", SqlDbType.Int, 4).Value = clientId;
                    connection.Open();


                    using (var reader = cmd.ExecuteReader())
                    {
                        var clientIDIndex = reader.GetOrdinal("Clientid");
                        var weekIDIndex = reader.GetOrdinal("Weekid");
                        var mondayIndex = reader.GetOrdinal("Monday");
                        var tuesdayIndex = reader.GetOrdinal("Tuesday");
                        var wednesdayIndex = reader.GetOrdinal("Wednesday");
                        var thursdayIndex = reader.GetOrdinal("Thursday");
                        var fridayIndex = reader.GetOrdinal("Friday");
                        var weekNumberIndex = reader.GetOrdinal("Weeknumber");
                        var startdateIndex = reader.GetOrdinal("Startdate");
                        var endDateIndex = reader.GetOrdinal("Enddate");

                        while (reader.Read())
                        {
                            weekMenues.Add(new WeekMenu
                            {
                                ClientId = reader.GetInt32(clientIDIndex),
                                WeekId = reader.GetInt32(weekIDIndex),
                                Monday = reader.GetString(mondayIndex),
                                Tuesday = reader.GetString(tuesdayIndex),
                                Wednesday = reader.GetString(wednesdayIndex),
                                Thursday = reader.GetString(thursdayIndex),
                                Friday = reader.GetString(fridayIndex),
                                Weeknumber = reader.GetInt32(weekNumberIndex),
                                Startdate = reader.GetDateTime(startdateIndex),
                                Enddate = reader.GetDateTime(endDateIndex)
                            });
                        }

                    }
                    totalRowCount = (int)cmd.Parameters["@RecordCount"].Value;

                    weekMenues.TrimExcess();
                    return weekMenues;
                }
                catch
                {

                    throw new ApplicationException("Ett fel inträffade när kundens veckomenyer skulle hämtas från databasen.");
                }
            }

        }

        //Get only actual week that is clicked
        public WeekMenu GetWeekMenuById(int clientId, int weekId)
        {
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_GetWeekMenuById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@Clientid", clientId);
                    cmd.Parameters.AddWithValue("@Weekid", weekId);

                    conn.Open();


                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {

                        if (reader.Read())
                        {

                            int clientIndex = reader.GetOrdinal("Clientid");
                            int weekIndex = reader.GetOrdinal("Weekid");
                            int weekNumberIndex = reader.GetOrdinal("Weeknumber");
                            int mondayIndex = reader.GetOrdinal("Monday");
                            int tuesdayIndex = reader.GetOrdinal("Tuesday");
                            int wednesdayIndex = reader.GetOrdinal("Wednesday");
                            int thursdayIndex = reader.GetOrdinal("Thursday");
                            int fridayIndex = reader.GetOrdinal("Friday");


                            // Returnerar referensen till de skapade Contact-objektet.
                            return new WeekMenu
                            {
                                ClientId = reader.GetInt32(clientIndex),
                                WeekId = reader.GetInt32(weekIndex),
                                Weeknumber = reader.GetInt32(weekNumberIndex),
                                Monday = reader.GetString(mondayIndex),
                                Tuesday = reader.GetString(tuesdayIndex),
                                Wednesday = reader.GetString(wednesdayIndex),
                                Thursday = reader.GetString(thursdayIndex),
                                Friday = reader.GetString(fridayIndex)

                            };
                        }
                    }

                    return null;
                }
                catch
                {
                    // Kastar ett eget undantag om ett undantag kastas.
                    throw new ApplicationException("Ett fel inträffade när aktuell veckomeny skulle hämtas från databasen.");
                }
            }
        }

        //Add new weekmenu to database
        public void InsertWeekMenu(WeekMenu weekMenu, int id)
        {

            using (var connection = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_InsertWeekMenu", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    //Add parameters that the stored procedure requests
                    cmd.Parameters.Add("@Clientid", SqlDbType.Int, 4).Value = id;
                    cmd.Parameters.Add("@Weekid", SqlDbType.Int, 4).Value = weekMenu.WeekId;
                    cmd.Parameters.Add("@Monday", SqlDbType.VarChar, 150).Value = weekMenu.Monday;
                    cmd.Parameters.Add("@Tuesday", SqlDbType.VarChar, 150).Value = weekMenu.Tuesday;
                    cmd.Parameters.Add("@Wednesday", SqlDbType.VarChar, 150).Value = weekMenu.Wednesday;
                    cmd.Parameters.Add("@Thursday", SqlDbType.VarChar, 150).Value = weekMenu.Thursday;
                    cmd.Parameters.Add("@Friday", SqlDbType.VarChar, 150).Value = weekMenu.Friday;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch
                {

                    throw new ApplicationException("Ett fel inträffade när veckomeny skulle läggas till i databasen.");
                }
            }
        }

        //Edit information in actual weekmenu
        public void UpdateWeekMenu(WeekMenu weekMenu)
        {
            // Skapar och initierar ett anslutningsobjekt.
            using (SqlConnection conn = CreateConnection())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("appSchema.usp_UpdateWeekMenu", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Clientid", SqlDbType.Int, 4).Value = weekMenu.ClientId;
                    cmd.Parameters.Add("@Weekid", SqlDbType.Int, 4).Value = weekMenu.WeekId;
                    cmd.Parameters.Add("@Monday", SqlDbType.VarChar, 150).Value = weekMenu.Monday;
                    cmd.Parameters.Add("@Tuesday", SqlDbType.VarChar, 150).Value = weekMenu.Tuesday;
                    cmd.Parameters.Add("@Wednesday", SqlDbType.VarChar, 150).Value = weekMenu.Wednesday;
                    cmd.Parameters.Add("@Thursday", SqlDbType.VarChar, 150).Value = weekMenu.Thursday;
                    cmd.Parameters.Add("@Friday", SqlDbType.VarChar, 150).Value = weekMenu.Friday;

                    conn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch
                {

                    throw new ApplicationException("Ett fel inträffade när veckomenyn skulle uppdateras i databasen.");
                }
            }
        }

        //Deletes actual weekmenu from database
        public void DeleteWeekMenu(int clientId, int weekId)
        {

            using (var connection = CreateConnection())
            {
                try
                {
                    var cmd = new SqlCommand("appSchema.usp_DeleteWeekMenu", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Weekid", SqlDbType.Int, 4).Value = weekId;
                    cmd.Parameters.Add("@Clientid", SqlDbType.Int, 4).Value = clientId;

                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
                catch
                {

                    throw new ApplicationException("Ett fel inträffade när veckomenyn skulle raderas från databasen.");
                }
            }
        }

    }
}