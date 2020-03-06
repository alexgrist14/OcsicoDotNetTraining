using System;
using System.Collections.Generic;
using Kawaii.Domain;
using Kawaii.Domain.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Kawaii.Domain.Identity
{
    public class User : IdentityUser<Guid>, IEntityModel<Guid>
    {
        public string Name { get; set; }

        public int Year { get; set; }

        public virtual ICollection<UserSubscription> Subscriptions { get; set; }

        public virtual ICollection<UserSubscription> Followers { get; set; }

        //public virtual ICollection<Message> Messages { get; set; }

        //public virtual ICollection<Post> Posts { get; set; }

        //public virtual ICollection<Like> Likes { get; set; }
    }
}
