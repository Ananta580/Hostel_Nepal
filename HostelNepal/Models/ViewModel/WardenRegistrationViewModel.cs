using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HostelNepal.Models.ViewModel
{
    public class WardenRegistrationViewModel
    {
        public int WardenId { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public string WardenName { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public string WardenSurName { get; set; }
        [Display(Name = "Your Quotaion about Hostel")]
        public string WardenQuotes { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public string WardenPhone { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public string WardenAddress { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Password Didn't Match!")]
        [Required(ErrorMessage = "*This Field is Required")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        [RegularExpression("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$",ErrorMessage ="Invalid Email Address")]
        public string Email { get; set; }
        public string Photo { get; set; }

    }
}