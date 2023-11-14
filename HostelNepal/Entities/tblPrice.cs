namespace HostelNepal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblPrice
    {
        public tblPrice()
        {
            this.tblRooms = new HashSet<tblRoom>();
        }

        [Key]
        public int PriceId { get; set; }
        public Nullable<decimal> Price { get; set; }

        public virtual ICollection<tblRoom> tblRooms { get; set; }
    }
}
