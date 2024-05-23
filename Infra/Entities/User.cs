using Infra.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Entities
{
    public class User: Base
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? UserName { get; set; }
    }
}
