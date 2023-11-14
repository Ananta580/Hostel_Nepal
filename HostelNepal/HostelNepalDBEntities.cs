

namespace HostelNepal.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public partial class HostelNepalDBEntities : DbContext
    {
        public HostelNepalDBEntities()
            : base("name=HostelNepalDBEntities")
        {
        }


        public virtual DbSet<tblAdmin> tblAdmins { get; set; }
        public virtual DbSet<tblBanner> tblBanners { get; set; }
        public virtual DbSet<tblChoice> tblChoices { get; set; }
        public virtual DbSet<tblHostel> tblHostels { get; set; }
        public virtual DbSet<tblMessage> tblMessages { get; set; }
        public virtual DbSet<tblNew> tblNews { get; set; }
        public virtual DbSet<tblPhoto> tblPhotoes { get; set; }
        public virtual DbSet<tblPrice> tblPrices { get; set; }
        public virtual DbSet<tblRole> tblRoles { get; set; }
        public virtual DbSet<tblRoom> tblRooms { get; set; }
        public virtual DbSet<tblStudent> tblStudents { get; set; }
        public virtual DbSet<tbluser> tblusers { get; set; }
        public virtual DbSet<tblUserRole> tblUserRoles { get; set; }
        public virtual DbSet<tblWarden> tblWardens { get; set; }
    }
}
