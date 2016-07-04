using AppDate.Model.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppDate.Model.DAL
{
    public class WeekDAL : BaseDAL
    {

        //Get all weeks that doesn´t already exist in clients weekmenu table from database to display in dropdownlist
        public IEnumerable<Week> GetWeeks(int id)
        {

            using (var conn = CreateConnection())
            {

                try
                {
                    var weeks = new List<Week>(60);
                    var cmd = new SqlCommand("appSchema.usp_GetWeeks", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@Clientid", SqlDbType.Int, 4).Value = id;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {

                        var weekIdIndex = reader.GetOrdinal("Weekid");
                        var weekNumberIndex = reader.GetOrdinal("Weeknumber");
                        var startDateIndex = reader.GetOrdinal("Startdate");
                        var endDateIndex = reader.GetOrdinal("Enddate");


                        while (reader.Read())
                        {
                            weeks.Add(new Week
                            {
                                WeekId = reader.GetInt32(weekIdIndex),
                                WeekNumber = reader.GetInt32(weekNumberIndex),
                                StartDate = reader.GetDateTime(startDateIndex),
                                EndDate = reader.GetDateTime(endDateIndex)
                            });
                        }
                    }
                    weeks.TrimExcess();
                    return weeks;
                }
                catch
                {

                    throw new ApplicationException("Ett fel inträffade när veckolistan skulle hämtas från databasen.");
                }
            }

        }

    }
}