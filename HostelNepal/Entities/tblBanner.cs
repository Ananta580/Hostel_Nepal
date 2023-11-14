namespace HostelNepal.Models
{
    using System;
    using System.Collections.Generic;

    public partial class tblBanner
    {
        public int BannerId { get; set; }
        public Nullable<int> HostelId { get; set; }
        public string Activated { get; set; }
        public string Photo { get; set; }

        public virtual tblHostel tblHostel { get; set; }
    }
}
