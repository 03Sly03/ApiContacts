using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ExerciceContactApi.DTO
{
    public class CreateContactRequest
    {
        [Required]
        [RegularExpression(@"^[A-Z][A-Za-z\- ]*", ErrorMessage = "FirstName must start with an uppercase letter !")]
        public string? Lastname { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z\- ]*", ErrorMessage = "LastName must be in uppercase !")]
        public string? Firstname { get; set; }
        public string? Fullname => Firstname + " " + Lastname;
        [Required]
        [JsonIgnore]
        public DateTime Birthdate { get; set; }
        public int Age
        {
            get
            {
                int age = DateTime.Now.Year - Birthdate.Year;
                if (Birthdate > DateTime.Now.AddYears(age - age))
                    age--;
                return age;
            }
        }
        public string? Gender { get; set; }
        public string? Avatar { get; set; }

    }
}
