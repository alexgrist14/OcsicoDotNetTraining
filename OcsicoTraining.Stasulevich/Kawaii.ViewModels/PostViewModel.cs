using System;
using Kawaii.Domain.Identity;

namespace Kawaii.ViewModels
{
    public class PostViewModel
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public User User;
    }
}
