using Business.Models;
using Business.Services;

namespace MainApp.Tests.Services;

public class ContactServiceTests
{
    [Fact]
    public void AddContact_ShouldAddContactToList()
    {
        // Arrange
        var fileService = new FileService();
        var contactService = new ContactService(fileService);
        var newContact = new Contact { FirstName = "Johan", LastName = "An" };

        // Act
        contactService.AddContact(newContact);

        // Assert
        var allContacts = contactService.GetAllContacts();
        Assert.Contains(newContact, allContacts);
    }

    [Fact]
    public void DeleteContact_ShouldRemoveContactFromList()
    {
        // Arrange
        var fileService = new FileService();
        var contactService = new ContactService(fileService);
        var newContact = new Contact { FirstName = "Johan", LastName = "An" };
        contactService.AddContact(newContact);

        // Act
        var result = contactService.DeleteContact(newContact.Id);

        // Assert
        Assert.True(result);
        Assert.DoesNotContain(newContact, contactService.GetAllContacts());
    }

    [Fact]
    public void GetAllContacts_ShouldReturnAllContacts()
    {
        // Arrange
        var fileService = new FileService();
        var contactService = new ContactService(fileService);
        var contacts = new[]
        {
            new Contact { FirstName = "Nils" },
            new Contact { FirstName = "Hansson" }
        };
        foreach (var contact in contacts)
        {
            contactService.AddContact(contact);
        }

        // Act
        var allContacts = contactService.GetAllContacts();

        // Assert
        Assert.Equal(contacts.Length, allContacts.Count());
    }
}
