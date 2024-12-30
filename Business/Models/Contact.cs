using System.ComponentModel.DataAnnotations;

namespace Business.Models;

public class Contact
{
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "First name is required")]
    [MinLength(2, ErrorMessage = "First name must contain at least two characters")]
    public string FirstName { get; set; } = null!;

    [Required(ErrorMessage = "Last name is required")]
    [MinLength(2, ErrorMessage = "Last name must contain at least two characters")]
    public string LastName { get; set; } = null!;

    [Required(ErrorMessage = "Email is required")]
    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Enter a valid email")]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Phone number is required")]
    [RegularExpression(@"^0\d{9,14}$|^\+?[1-9]\d{1,14}$", ErrorMessage = "Enter a valid phone number")]
    public string Phone { get; set; } = null!;

    [Required(ErrorMessage = "Enter a valid address")]
    public string Address { get; set; } = null!;

    [Required(ErrorMessage = "Enter a valid postal code")]
    public string PostalCode { get; set; } = null!;

    [Required(ErrorMessage = "Enter a valid city")]
    public string City { get; set; } = null!;
}

