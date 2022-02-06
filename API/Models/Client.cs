using API.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    [ClientEntityValidation]
    public class Client
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(80)]
        public string Name { get; set; }

        [Required]
        [MaxLength(80)]
        public string Surname { get; set; }

        [Required]
        [MaxLength(80)]
        public string FatherName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public bool Gender { get; set; }

        [Required]
        [MaxLength(80)]
        public string PassportSerial { get; set; }

        [Required]
        [MaxLength(80)]
        public string PassportNumber { get; set; }

        [Required]
        [MaxLength(80)]
        public string IssuedBy { get; set; }

        [Required]
        public DateTime IssuedDate { get; set; }

        [Required]
        [MaxLength(80)]
        public string IdentifyNumber { get; set; }

        public City CityOfResidence { get; set; }

        [Required]
        [MaxLength(80)]
        public string AddressOfResidence { get; set; }

        [MaxLength(80)]
        public string HomePhone { get; set; }

        [MaxLength(80)]
        public string CellPhone { get; set; }

        [MaxLength(80)]
        public string Email { get; set; }

        [MaxLength(80)]
        public string PlaceOfWork { get; set; }
       
        [MaxLength(80)]
        public string Position { get; set; }
        
        public City LivingCity { get; set; }

        [Required]
        [MaxLength(80)]
        public string LivingAddress { get; set; }
 
        public FamilyPosition FamilyPosition { get; set; }
        public Country Citizen { get; set; }
        public Invalidity Invalidity { get; set; }

        [Required]
        public bool Retired { get; set; }

        public decimal MonthlyIncome { get; set; }
        
        [Required]
        public bool Military { get; set; }
    }
}
