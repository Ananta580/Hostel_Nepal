namespace HostelNepal.Models
{
    using System;
    using System.Collections.Generic;

    public partial class tblChoice
    {
        public int ChoiceId { get; set; }
        public Nullable<int> StudentId { get; set; }
        public Nullable<int> HostelId { get; set; }

        public virtual tblHostel tblHostel { get; set; }
        public virtual tblStudent tblStudent { get; set; }
    }
}
