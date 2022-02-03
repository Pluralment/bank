using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(80)]
        public string Name { get; set; }
    }
}
