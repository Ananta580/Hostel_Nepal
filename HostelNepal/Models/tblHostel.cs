//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HostelNepal.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblHostel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblHostel()
        {
            this.tblBanners = new HashSet<tblBanner>();
            this.tblChoices = new HashSet<tblChoice>();
            this.tblPhotoes = new HashSet<tblPhoto>();
            this.tblRooms = new HashSet<tblRoom>();
        }
    
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
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblBanner> tblBanners { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblChoice> tblChoices { get; set; }
        public virtual tblWarden tblWarden { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblPhoto> tblPhotoes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblRoom> tblRooms { get; set; }
    }
}
