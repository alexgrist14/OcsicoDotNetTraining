using System;
using System.Collections.Generic;
using System.Text;

namespace EntityModels
{
    public class Like
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid PostId { get; set; }

        public virtual User User { get; set; }
    }
}
