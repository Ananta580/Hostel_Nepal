using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HostelNepal.Models.ViewModel
{
    public class BannerViewModel
    {
        public int BannerId { get; set; }
        public int? HostelId { get; set; }
        public bool Activated { get; set; }
        public string Photo { get; set; }
        public string HostelName { get; set; }
    }
}