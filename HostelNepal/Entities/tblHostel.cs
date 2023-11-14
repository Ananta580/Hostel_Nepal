namespace HostelNepal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblHostel
    {
        public tblHostel()
        {
            this.tblBanners = new HashSet<tblBanner>();
            this.tblChoices = new HashSet<tblChoice>();
            this.tblPhotoes = new HashSet<tblPhoto>();
            this.tblRooms = new HashSet<tblRoom>();
        }

        [Key]
        public int HostelId { get; set; }
        public string HostelName { get; set; }
        public string Description { get; set; }
        public Nullable<int> Star { get; set; }
        public string Address { get; set; }
        public Nullable<int> Capacity { get; set; }
        public string MapLocation { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public Nullable<int> WardenId { get; set; }
        public string Latest { get; set; }
        public string DescriptionNext { get; set; }
        public string Facilites { get; set; }

        public virtual ICollection<tblBanner> tblBanners { get; set; }
        public virtual ICollection<tblChoice> tblChoices { get; set; }
        public virtual tblWarden tblWarden { get; set; }
        public virtual ICollection<tblPhoto> tblPhotoes { get; set; }
        public virtual ICollection<tblRoom> tblRooms { get; set; }
    }
}
