using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HostelNepal.Models.ViewModel
{
    public class StudentRegistrationViewModel
    {
        public int StudentId { get; set; }

        [Required(ErrorMessage = "*This Field is Required")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public string StudentSurName { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public string StudentUserName { get; set; }
        public string TemporaryAddress { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public string PermanentAddress { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public string Education { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public string StudentPhone { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public DateTime? DOB { get; set; }
        public int? Age { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        [RegularExpression("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$",ErrorMessage ="Invalid Email ID")]
        public string StudentEmail { get; set; }
        public string Testomonial { get; set; }
        public string StudentPhoto { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public string StudentPassword { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        [Compare("StudentPassword",ErrorMessage ="Password Didn't Match!")]
        public string ComfirmPassword { get; set; }
        public string AvatarPhoto { get; set; }
    }
}