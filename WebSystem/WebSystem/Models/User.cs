

using System.ComponentModel.DataAnnotations;

namespace WebSystem.Models
{
    public class User
    {
        [Display(Name = "ID")]
        public int UserId { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Login")]
        public string UserLogin { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Password")]
        public string UserPassword { get; set; }
        [Required]
        [StringLength(30)]
        [Display(Name = "Name")]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "E-mail")]
        public string UserEmail { get; set; }

        public bool isChecked { get; set; }

    }
}