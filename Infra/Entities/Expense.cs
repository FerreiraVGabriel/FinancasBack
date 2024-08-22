using Infra.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Entities
{
    public class Expense : Base
    {
        public int UserID { get; set; }

        public DateTime ExpenseDate { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }

        public int TypeID { get; set; }
        public TypeExpense TypeExpense { get; set; }
    }

}
