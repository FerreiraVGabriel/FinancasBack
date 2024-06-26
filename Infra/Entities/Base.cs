﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Entidades
{
    public abstract class Base
    {
        public int Id { get; set; }
        public DateTime DateCreated{ get; set; }
        public DateTime? DateUpdated { get; set; }
    }
}
