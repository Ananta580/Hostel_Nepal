namespace HostelNepal.Models
{
    using System;
    using System.Collections.Generic;

    public partial class tblMessage
    {
        public int MessageId { get; set; }
        public string SenderName { get; set; }
        public string Subject { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string Tag { get; set; }
    }
}
