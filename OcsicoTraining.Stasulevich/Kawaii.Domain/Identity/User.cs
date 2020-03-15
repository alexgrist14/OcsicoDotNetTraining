using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Kawaii.Domain;
using Kawaii.Domain.Contracts;
using Microsoft.AspNetCore.Identity;

namespace Kawaii.Domain.Identity
{
    public class User : IdentityUser<Guid>, IEntityModel<Guid>
    {
        public string Name { get; set; }

        public int Year { get; set; }

        public Guid? ProfileImageId { get; set; }

        public virtual ProfileImage ProfileImage { get; set; }

        public virtual ICollection<UserFollow> Followings { get; set; }

        public virtual ICollection<UserFollow> Followers { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
