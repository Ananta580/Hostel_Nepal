namespace HostelNepal.Models
{
    using System;
    using System.Collections.Generic;

    public partial class tblStudent
    {
        public tblStudent()
        {
            this.tblChoices = new HashSet<tblChoice>();
        }

        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string UserName { get; set; }
        public string TemporaryAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string Education { get; set; }
        public string Phone { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<int> Age { get; set; }
        public string Email { get; set; }
        public string Testomonial { get; set; }
        public string Photo { get; set; }
        public string AvatarPhoto { get; set; }
        public string Password { get; set; }

        public virtual ICollection<tblChoice> tblChoices { get; set; }
    }
}
