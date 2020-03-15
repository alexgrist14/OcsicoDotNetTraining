using System;

namespace Kawaii.ViewModels
{
    public class NewsViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public bool IsSuccess { get; set; }
    }
}
