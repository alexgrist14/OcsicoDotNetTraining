using System;
using System.Collections.Generic;
using System.Text;
using Kawaii.Domain.Contracts;
using Kawaii.Domain.Identity;

namespace Kawaii.Domain
{
    public class Comment : IEntityModel<Guid>
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Text { get; set; }

        public Guid PostId { get; set; }

        public virtual User User { get; set; }

        public virtual Post Post { get; set; }
    }
}
