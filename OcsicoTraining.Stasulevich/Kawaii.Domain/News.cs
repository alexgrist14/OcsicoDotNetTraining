using System;
using Kawaii.Domain.Contracts;

namespace Kawaii.Domain
{
    public class News : IEntityModel<Guid>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public bool IsSuccess { get; set; }
    }
}
