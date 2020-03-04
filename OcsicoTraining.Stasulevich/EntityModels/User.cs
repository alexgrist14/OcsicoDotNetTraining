using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace EntityModels
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        public int Year { get; set; }

        public virtual ICollection<Subscriptions> Subscriptions { get; set; }

        public virtual ICollection<Message> Messages { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
