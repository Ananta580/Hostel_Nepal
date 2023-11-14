namespace HostelNepal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblBanner
    {
        [Key]
        public int BannerId { get; set; }
        public Nullable<int> HostelId { get; set; }
        public string Activated { get; set; }
        public string Photo { get; set; }

        public tblHostel tblHostel { get; set; }
    }
}
