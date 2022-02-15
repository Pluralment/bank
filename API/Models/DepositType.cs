using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class DepositType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Interest { get; set; }

        [Required]
        public bool IsFixedInterest { get; set; }

        [Required]
        public double MinContribution { get; set; }

        [Required]
        public double MaxContribution { get; set; }
    }
}
