﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class BankDateTime
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }
}
