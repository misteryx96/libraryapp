﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Genre : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<BookGenre> BookGenres { get; set; }
    }
}
