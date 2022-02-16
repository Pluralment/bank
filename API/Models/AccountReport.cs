using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class AccountReport
    {
        public int AccountingRecord { get; set; }

        public double Debt { get; set; }

        public double Credit { get; set; }

        public double Saldo { get; set; }
    }
}
