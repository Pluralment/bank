using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class EntryReport
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string FromAccountName { get; set; }
        public string ToAccountName { get; set; }
        public double FromDebt { get; set; }
        public double FromCredit { get; set; }
        public double ToDebt { get; set; }
        public double ToCredit { get; set; }
    }
}
