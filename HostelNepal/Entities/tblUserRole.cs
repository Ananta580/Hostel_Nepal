namespace HostelNepal.Models
{
    using System;
    using System.Collections.Generic;

    public partial class tblUserRole
    {
        public int UserRoleId { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<int> UserId { get; set; }

        public virtual tblRole tblRole { get; set; }
        public virtual tbluser tbluser { get; set; }
    }
}
