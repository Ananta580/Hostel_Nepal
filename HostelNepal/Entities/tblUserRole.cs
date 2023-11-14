namespace HostelNepal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblUserRole
    {
        [Key]
        public int UserRoleId { get; set; }
        public int? RoleId { get; set; }
        public int? UserId { get; set; }
        public virtual tblRole tblRole { get; set; }
        public virtual tbluser tbluser { get; set; }
    }
}
