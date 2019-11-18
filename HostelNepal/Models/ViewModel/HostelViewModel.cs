using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HostelNepal.Models.ViewModel
{
    public class HostelViewModel
    {
        public int HostelId { get; set; }
        [Required(ErrorMessage = "Hostel Name is Required")]
        public string HostelName { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public int? Star { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public string Address { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public int? Capacity { get; set; }
        public string MapLocation { get; set; }
        public string Photo { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        [RegularExpression("^\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*$", ErrorMessage = "Invalid Email ID")]
        public string Email { get; set; }
        public int? WardenId { get; set; }
        public string Latest { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public string DescriptionNext { get; set; }
        public string Photo1 { get; set; }
        public string Photo2 { get; set; }
        public string Photo3 { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public string Facilites { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public decimal? OnesitterPrice { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public decimal? TwositterPrice { get; set; }
        [Required(ErrorMessage = "*This Field is Required")]
        public decimal? ThreesitterPrice { get; set; }

    }
}