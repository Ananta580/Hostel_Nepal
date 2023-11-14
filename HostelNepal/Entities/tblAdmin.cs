namespace HostelNepal.Models
{
    using System;
    using System.Collections.Generic;

    public partial class tblAdmin
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
