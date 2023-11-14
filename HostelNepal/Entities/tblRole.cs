namespace HostelNepal.Models
{
    using System;
    using System.Collections.Generic;

    public partial class tblRole
    {
        public tblRole()
        {
            this.tblUserRoles = new HashSet<tblUserRole>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<tblUserRole> tblUserRoles { get; set; }
    }
}
