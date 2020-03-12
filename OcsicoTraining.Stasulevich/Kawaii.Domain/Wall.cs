using System;
using System.Collections.Generic;
using System.Text;
using Kawaii.Domain.Contracts;
using Kawaii.Domain.Identity;

namespace Kawaii.Domain
{
    public class Wall : IEntityModel<Guid>
    {
        public Wall()
        {
            Posts = new HashSet<Post>();
        }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
