using Business.Models;

namespace MainApp.Tests.Models;

/* Test to make sure class initializes and stores the different data for a contact */
public class Contact_Tests
{
    [Fact]
    public void Contact_ShouldInitializeCorrectly()
    {
        // Arrange
        var firstName = "Johan";
        var lastName = "An";
        var email = "johan@domain.com";
        var phone = "1234567890";
        var address = "Solvik 42";
        var postalCode = "12345";
        var city = "Hässleholm";

        // Act
        var contact = new Contact
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Phone = phone,
            Address = address,
            PostalCode = postalCode,
            City = city
        };

        // Assert
        Assert.Equal(firstName, contact.FirstName);
        Assert.Equal(lastName, contact.LastName);
        Assert.Equal(email, contact.Email);
        Assert.Equal(phone, contact.Phone);
        Assert.Equal(address, contact.Address);
        Assert.Equal(postalCode, contact.PostalCode);
        Assert.Equal(city, contact.City);
        Assert.NotEqual(Guid.Empty, contact.Id);
    }
}
