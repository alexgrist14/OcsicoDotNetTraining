using System;
using System.Collections.Generic;
using System.Text;
using Kawaii.Domain.Contracts;
using Kawaii.Domain.Identity;

namespace Kawaii.Domain
{
    public class ProfileImage : IEntityModel<Guid>
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string FileName { get; set; }

        public virtual User User { get; set; }
    }
}
