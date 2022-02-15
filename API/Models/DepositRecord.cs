using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class DepositRecord
    {
        [Key, Column(Order = 0)]
        public DepositContract DepositContract { get; set; }

        [Key, Column(Order = 1)]
        public AccountingRecord Record { get; set; }
    }
}
