using Business.Models;

namespace Business.Factories;

public static class ContactFactory
{
    public static Contact CreateContact(
        string firstName,
        string lastName,
        string email,
        string phone,
        string address,
        string postalCode,
        string city)
    {
        return new Contact
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Phone = phone,
            Address = address,
            PostalCode = postalCode,
            City = city
        };
    }
}
