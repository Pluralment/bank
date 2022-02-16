using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class AccountingRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        public string Name { get; set; }

        [Required]
        public AccountingRecordType RecordType { get; set; }

        public List<DepositRecord> DepositRecords { get; set; } = new List<DepositRecord>();

    }
}
