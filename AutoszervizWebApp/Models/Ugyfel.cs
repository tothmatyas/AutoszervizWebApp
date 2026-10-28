using System.ComponentModel.DataAnnotations;

namespace AutoszervizWebApp.Models
{
    public class Ugyfel
    {

        public int Id { get; set; }
        
        [Required]
        public string Nev { get; set; }
        [StringLength(20)]
        public string Telefon { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        //navigacios tulajdonsag

    }
}
