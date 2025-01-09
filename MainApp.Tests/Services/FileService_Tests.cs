using Business.Models;
using Business.Services;

namespace MainApp.Tests.Services;

/* Test for saving and loading contacts to and from file */
public class FileService_Tests
{
    private const string TestFilePath = "test_contacts.json";

    [Fact]
    public void SaveAndLoadContacts_ShouldWorkCorrectly()
    {
        // Arrange
        var fileService = new FileService(TestFilePath);
        var contacts = new List<Contact>
        {
            new Contact { FirstName = "Johan", LastName = "An", Email = "johan@domain.com" },
            new Contact { FirstName = "Nils", LastName = "Hansson", Email = "nils@domain.com" }
        };

        // Act
        fileService.SaveToFile(contacts);
        var loadedContacts = fileService.LoadFromFile();

        // Assert
        Assert.Equal(contacts.Count, loadedContacts.Count);
        Assert.Equal(contacts[0].FirstName, loadedContacts[0].FirstName);
        Assert.Equal(contacts[1].Email, loadedContacts[1].Email);

        // ChatGPT recommended to delete the test file after the test
        if (File.Exists(TestFilePath))
        {
            File.Delete(TestFilePath);
        }
    }
}
