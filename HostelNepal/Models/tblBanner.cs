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
    
    public partial class tblBanner
    {
        public int BannerId { get; set; }
        public Nullable<int> HostelId { get; set; }
        public string Activated { get; set; }
        public string Photo { get; set; }
    
        public virtual tblHostel tblHostel { get; set; }
    }
}
