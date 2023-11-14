namespace HostelNepal.Models
{
    using System;
    using System.Collections.Generic;

    public partial class tblPrice
    {
        public tblPrice()
        {
            this.tblRooms = new HashSet<tblRoom>();
        }

        public int PriceId { get; set; }
        public Nullable<decimal> Price { get; set; }

        public virtual ICollection<tblRoom> tblRooms { get; set; }
    }
}
