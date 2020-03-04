using System;
using System.Collections.Generic;
using System.Text;

namespace EntityModels
{
    public class Subscriptions
    {
        public Guid UserId { get; set; }

        public Guid FriendId { get; set; }

        public virtual User User { get; set; }

        public virtual User Friend { get; set; }
    }
}
