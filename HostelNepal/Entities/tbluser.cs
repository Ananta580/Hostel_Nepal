namespace HostelNepal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tbluser
    {
        public tbluser()
        {
            this.tblUserRoles = new HashSet<tblUserRole>();
        }

        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public virtual ICollection<tblUserRole> tblUserRoles { get; set; }
    }
}
