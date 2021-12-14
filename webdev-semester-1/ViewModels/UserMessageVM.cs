using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webdev_semester_1.ViewModels
{
    public class UserMessageVM
    {
        // User
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Message
        public int MessageId { get; set; }
        public string MessageText { get; set; }
        public bool? Read { get; set; }
        public int ReceiverUserId { get; set; }
        public int SenderUserId { get; set; }
    }
}
