

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


        public DbSet<tblAdmin> tblAdmins { get; set; }
        public DbSet<tblBanner> tblBanners { get; set; }
        public DbSet<tblChoice> tblChoices { get; set; }
        public DbSet<tblHostel> tblHostels { get; set; }
        public DbSet<tblMessage> tblMessages { get; set; }
        public DbSet<tblNew> tblNews { get; set; }
        public DbSet<tblPhoto> tblPhotoes { get; set; }
        public DbSet<tblPrice> tblPrices { get; set; }
        public DbSet<tblRole> tblRoles { get; set; }
        public DbSet<tblRoom> tblRooms { get; set; }
        public DbSet<tblStudent> tblStudents { get; set; }
        public DbSet<tbluser> tblusers { get; set; }
        public DbSet<tblUserRole> tblUserRoles { get; set; }
        public DbSet<tblWarden> tblWardens { get; set; }
    }
}
