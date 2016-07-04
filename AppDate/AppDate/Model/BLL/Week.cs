using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDate.Model.BLL
{
    //Class that represents Week table in database
    public class Week
    {
        public int WeekId { get; set; }

        public int WeekNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}