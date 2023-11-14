namespace HostelNepal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class tblMessage
    {
        [Key]
        public int MessageId { get; set; }
        public string SenderName { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Tag { get; set; }
    }
}
