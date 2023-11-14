namespace HostelNepal.Models
{
    using System;
    using System.Collections.Generic;

    public partial class tblWarden
    {
        public tblWarden()
        {
            this.tblHostels = new HashSet<tblHostel>();
        }

        public int WardenId { get; set; }
        public string WardenName { get; set; }
        public string WardenQuotes { get; set; }
        public string WardenPhone { get; set; }
        public string WardenAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string Best { get; set; }

        public virtual ICollection<tblHostel> tblHostels { get; set; }
    }
}
