namespace HostelNepal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblRole
    {
        public tblRole()
        {
            this.tblUserRoles = new HashSet<tblUserRole>();
        }

        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }

        public virtual ICollection<tblUserRole> tblUserRoles { get; set; }
    }
}
