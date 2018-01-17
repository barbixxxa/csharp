

using System.ComponentModel.DataAnnotations;

namespace WebSystem.Models
{
    public class User
    {
        [Display(Name = "ID")]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "Login")]
        public string UserLogin { get; set; }
        [Required]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "E-mail")]
        public string UserEmail { get; set; }

    }
}