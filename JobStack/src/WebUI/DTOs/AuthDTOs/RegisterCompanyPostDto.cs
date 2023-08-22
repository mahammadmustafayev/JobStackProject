namespace JobStack.WebUI.DTOs.AuthDTOs;

public class RegisterCompanyPostDto
{
    public string CompanyName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public int CountryId { get; set; }
    public int CityId { get; set; }
    public string? CompanyLogo { get; set; }
}
