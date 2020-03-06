using System;
using Kawaii.Domain.Contracts;
using Kawaii.Domain.Identity;

namespace Kawaii.Domain
{
    public class UserSubscription : IEntityModel<Guid>
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid FollowerId { get; set; }

        public virtual User User { get; set; }

        public virtual User Follower { get; set; }
    }
}
