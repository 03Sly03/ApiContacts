namespace ExerciceContactApi.DTO
{
    public class CreateContactRequest
    {
        public string? Lastname { get; set; }
        public string? Firstname { get; set; }
        public string? Fullname { get; set; }
        public DateTime Birthdate { get; set; }
        public string? Sexe { get; set; }
        public string? Avatar { get; set; }
    }
}
