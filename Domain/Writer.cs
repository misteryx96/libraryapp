using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Writer : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
