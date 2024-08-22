using Infra.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Entities
{
    public class ActualExpenses : Base
    {
        public int UserID { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }
        public decimal RealExpenses { get; set; }
        public decimal RealInvestments { get; set; }
    }

}
