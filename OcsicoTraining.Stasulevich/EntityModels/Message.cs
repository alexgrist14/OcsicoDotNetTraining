using System;
using System.Collections.Generic;
using System.Text;

namespace EntityModels
{
    public class Message
    {
        public Guid Id { get; set; }

        public Guid SenderId { get; set; }

        public Guid RecieverId { get; set; }

        public string Content { get; set; }

        public DateTime SendDate { get; set; }

        public virtual User Sender { get; set; }

        public virtual User Reciever { get; set; }
    }
}
