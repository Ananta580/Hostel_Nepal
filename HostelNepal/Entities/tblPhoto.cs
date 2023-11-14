namespace HostelNepal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblPhoto
    {
        [Key]
        public int PhotoId { get; set; }
        public string Photo { get; set; }
        public Nullable<int> HostelId { get; set; }

        public virtual tblHostel tblHostel { get; set; }
    }
}
