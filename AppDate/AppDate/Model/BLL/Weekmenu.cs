using AppDate.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDate.Model.BLL
{
    //Class that represents Weekmenu table in database
    public class WeekMenu: BaseDAL
    {

        public int ClientId { get; set; }

        public int WeekId { get; set; }

        public int Weeknumber { get; set; }

        public DateTime Startdate { get; set; }

        public DateTime Enddate { get; set; }

        [Required(ErrorMessage = "Dagens saknas: måndag")]
        [StringLength(150, ErrorMessage = "Dagens rätt kan bestå av max 150 tecken.")]
        public string Monday { get; set; }

        [Required(ErrorMessage = "Dagens saknas: tisdag")]
        [StringLength(150, ErrorMessage = "Dagens rätt kan bestå av max 150 tecken.")]
        public string Tuesday { get; set; }

        [Required(ErrorMessage = "Dagens saknas: onsdag")]
        [StringLength(150, ErrorMessage = "Dagens rätt kan bestå av max 150 tecken.")]
        public string Wednesday { get; set; }

        [Required(ErrorMessage = "Dagens saknas: torsdag")]
        [StringLength(150, ErrorMessage = "Dagens rätt kan bestå av max 150 tecken.")]
        public string Thursday { get; set; }

        [Required(ErrorMessage = "Dagens saknas: fredag")]
        [StringLength(150, ErrorMessage = "Dagens rätt kan bestå av max 150 tecken.")]
        public string Friday { get; set; }


    }
}