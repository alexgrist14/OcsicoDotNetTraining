using System;
using System.Collections.Generic;
using System.Text;

namespace EntityModels
{
    public class Post
    {
        public Guid Id { get; set; }

        public string Image { get; set; }

        public int Like { get; set; }
    }
}
