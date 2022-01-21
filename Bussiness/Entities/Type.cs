﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Entities
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<Subtype> Subtypes { get; set; }
    }
}
