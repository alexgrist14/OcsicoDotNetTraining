using System;
using System.Collections.Generic;
using Kawaii.Domain.Contracts;
using Kawaii.Domain.Identity;

namespace Kawaii.Domain
{
    public class Post : IEntityModel<Guid>
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<UserLike> Likes { get; set; }
    }
}
