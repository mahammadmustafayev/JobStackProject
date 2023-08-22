namespace JobStack.WebUI.DTOs.AuthDTOs
{
    public class RegiserCandidateDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int CountryId { get; set; }
        public int CityId { get; set; }
        public IFormFile? CandidateProfileUrl { get; set; }

    }
}
