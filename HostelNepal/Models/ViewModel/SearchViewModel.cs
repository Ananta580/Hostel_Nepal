using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HostelNepal.Models.ViewModel
{
    public class SearchViewModel
    {
        public string Keyword { get; set; }
        public int star { get; set; }
        public int Sitter { get; set; }
        public string Address { get; set; }
        public decimal? MinPrice { get; set; }

        public decimal? MaxPrice { get; set; }
    }
}