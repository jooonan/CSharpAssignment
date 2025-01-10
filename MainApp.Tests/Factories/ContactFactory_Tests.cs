using Business.Factories;

namespace MainApp.Tests.Factories;

/* Test to make sure a contat object is correctly created with the designated data */
public class ContactFactory_Tests
{
    [Fact]
    public void CreateContact_ShouldReturnValidContact()
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
        var contact = ContactFactory.CreateContact(firstName, lastName, email, phone, address, postalCode, city);

        // Assert
        Assert.Equal(firstName, contact.FirstName);
        Assert.Equal(lastName, contact.LastName);
        Assert.Equal(email, contact.Email);
        Assert.Equal(phone, contact.Phone);
        Assert.Equal(address, contact.Address);
        Assert.Equal(postalCode, contact.PostalCode);
        Assert.Equal(city, contact.City);
    }
}
