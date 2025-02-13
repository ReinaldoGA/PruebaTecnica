using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Core.Model.Book
{
    public class Book
    {
        public int id { get; set; }
        public string title { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
        public int pageCount { get; set; }
        public string excerpt { get; set; } = string.Empty;
        public DateTime publishDate { get; set; } = DateTime.Now;

    }
}
