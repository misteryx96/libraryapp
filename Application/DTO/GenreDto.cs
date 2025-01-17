﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
    public class GenreDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<int> Books { get; set; }
    }
}
