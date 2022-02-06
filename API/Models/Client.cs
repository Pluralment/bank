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

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(80, ErrorMessage = "Name should contain less than 80 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required")]
        [MaxLength(80, ErrorMessage = "Surname name should contain less than 80 characters")] 
        public string Surname { get; set; }

        [Required(ErrorMessage = "Father's name is required")]
        [MaxLength(80, ErrorMessage = "Father's name should contain less than 80 characters")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "Date of birth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public bool Gender { get; set; }

        [Required(ErrorMessage = "Passport serial is required")]
        [MaxLength(80, ErrorMessage = "Passport serial should contain less than 80 characters")]
        public string PassportSerial { get; set; }

        [Required(ErrorMessage = "Passport number is required")]
        [MaxLength(80, ErrorMessage = "Passport number should contain less than 80 characters")]
        [RegularExpression("^[0-9]{7}", ErrorMessage = "Incorrect passport number")]
        public string PassportNumber { get; set; }

        [Required(ErrorMessage = "Issued by is required")]
        [MaxLength(80, ErrorMessage = "Issued by should contain less than 80 characters")]
        public string IssuedBy { get; set; }

        [Required(ErrorMessage = "Issued date is required")]
        public DateTime IssuedDate { get; set; }

        [Required(ErrorMessage = "Identify number is required")]
        [MaxLength(80, ErrorMessage = "Identify number should contain less than 80 characters")]
        [RegularExpression(@"^[1-6][0-3]\d[0-1][1-9]\d{2}[ABCHKEM]\d{3}(PB|BA|BI)\d", ErrorMessage = "Incorrect identify number")]
        public string IdentifyNumber { get; set; }

        public City CityOfResidence { get; set; }

        [Required(ErrorMessage = "Address of residance is required")]
        [MaxLength(80, ErrorMessage = "Address of residence should contain less than 80 characters")]
        public string AddressOfResidence { get; set; }

        [MaxLength(80, ErrorMessage = "Home phone should contain less than 80 characters")]
        [RegularExpression(@"^[1-9]\d{2}-?\d{2}-?\d{2}", ErrorMessage = "Incorrect home phone number")]
        public string HomePhone { get; set; }

        [MaxLength(80, ErrorMessage = "Cell phone should contain less than 80 characters")]
        [RegularExpression(@"^\\+375[1-9]{2}\s?[1-9]\d{2}-?\d{2}-?\d{2}", ErrorMessage = "Incorrect Cell phone number")]
        public string CellPhone { get; set; }

        [MaxLength(80, ErrorMessage = "Email should contain less than 80 characters")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Incorrect email")]
        public string Email { get; set; }

        [MaxLength(80, ErrorMessage = "Place of work should contain less than 80 characters")]
        public string PlaceOfWork { get; set; }

        [MaxLength(80, ErrorMessage = "Position should contain less than 80 characters")]
        public string Position { get; set; }
        
        public City LivingCity { get; set; }

        [Required(ErrorMessage = "Living address is required")]
        [MaxLength(80, ErrorMessage = "Living address should contain less than 80 characters")]
        public string LivingAddress { get; set; }
 

        public FamilyPosition FamilyPosition { get; set; }
        public Country Citizen { get; set; }
        public Invalidity Invalidity { get; set; }

        [Required(ErrorMessage = "Retired is required")]
        public bool Retired { get; set; }

        public decimal MonthlyIncome { get; set; }
        
        [Required(ErrorMessage = "Military is required")]
        public bool Military { get; set; }
    }
}
