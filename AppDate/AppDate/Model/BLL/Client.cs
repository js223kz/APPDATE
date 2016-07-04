using AppDate.Model.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppDate.Model.BLL
{
    //Class that represent the Client table in database
    public class Client : BaseDAL
    {
        public int ClientId { get; set; }

        [Required(ErrorMessage = "Namn måste anges.")]
        [StringLength(50, ErrorMessage = "Namnet kan bestå av maximalt 50 tecken.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Adress måste anges")]
        [StringLength(30, ErrorMessage = "Adressen kan bestå av maximalt 30 tecken.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Postnummer måste anges")]
        [RegularExpression(@"^[1-9]\d{2} ?\d{2}", ErrorMessage = "Postnumret verkar inte vara korrekt.")]
        public int Zipcode { get; set; }

        [Required(ErrorMessage = "Stad måste anges")]
        [StringLength(25, ErrorMessage = "Stad kan bestå av maximalt 25 tecken.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Användarnamn måste anges")]
        [StringLength(15, ErrorMessage = "Användarnamnet kan bestå av maximalt 15 tecken.")]
        [MinLength(6, ErrorMessage = "Användarnamnet måste innehålla minst 6 tecken")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Lösenord måste anges")]
        [StringLength(10, ErrorMessage = "Lösenordet kan bestå av maximalt 10 tecken.")]
        [MinLength(6, ErrorMessage = "Lösenordet måste innehålla minst 6 tecken")]
        public string PassWord { get; set; }

        [Required(ErrorMessage = "Kontaktperson måste anges.")]
        [StringLength(40, ErrorMessage = "Kontaktperson kan bestå av maximalt 40 tecken.")]
        public string ContactPerson { get; set; }

        [Required(ErrorMessage = "Telefon måste anges.")]
        [StringLength(11, ErrorMessage = "Telefon kan bestå av maximalt 11 tecken.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "En e-postadress måste anges")]
        [EmailAddress(ErrorMessage = "E-post är inte en giltig e-postadress")]
        [StringLength(50, ErrorMessage = "E-postadressen kan bestå av maximalt 50 tecken.")]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Organisationsnummer måste anges")]
        [RegularExpression(@"^(\d{1})(\d{5})\-(\d{4})$", ErrorMessage = "Organisationsnumret verkar inte vara korrekt.")]
        public string Vatnumber { get; set; }

       

    }
}