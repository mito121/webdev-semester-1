using System;
using System.Collections.Generic;

#nullable disable

namespace aao_api.Models
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public string MessageText { get; set; }
        public bool? Read { get; set; }
        public int ReceiverUserId { get; set; }
        public int SenderUserId { get; set; }

        public virtual User ReceiverUser { get; set; }
        public virtual User SenderUser { get; set; }
    }
}
