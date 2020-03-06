using System;
using Kawaii.Domain.Contracts;
using Kawaii.Domain.Identity;

namespace Kawaii.Domain
{
    public class Message : IEntityModel<Guid>
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
