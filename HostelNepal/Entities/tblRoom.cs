namespace HostelNepal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblRoom
    {
        [Key]
        public int RoomId { get; set; }
        public string RoomName { get; set; }
        public Nullable<int> PriceId { get; set; }
        public Nullable<int> HostelId { get; set; }

        public virtual tblHostel tblHostel { get; set; }
        public virtual tblPrice tblPrice { get; set; }
    }
}
