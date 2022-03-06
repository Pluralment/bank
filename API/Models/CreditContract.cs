using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class CreditContract
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Number { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Required]
        public Currency Currency { get; set; }

        [Required]
        public bool IsClosed { get; set; }

        [Required]
        public double Amount { get; set; }

        [Required]
        public CreditType CreditType { get; set; }

        [Required]
        public Client Client { get; set; }

        public List<CreditRecord> CreditRecords { get; set; } = new List<CreditRecord>();
    }
}
