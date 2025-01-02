using Business.Interfaces;
using Business.Models;

namespace Business.Services;

public class ContactService : IContactService
{
    private readonly List<Contact> _contacts;
    private readonly IFileService _fileService;
    public void AddContact(Contact contact)
    {
        try
        {
            _contacts.Add(contact);
            _fileService.SaveToFile(_contacts);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to add contact: {ex.Message}");
        }
    }

    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
        _contacts = _fileService.LoadFromFile();
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        return _contacts;
    }

    public bool DeleteContact(Guid id)
    {
        try
        {
            var contact = _contacts.Find(c => c.Id == id);
            if (contact != null)
            {
                _contacts.Remove(contact);
                _fileService.SaveToFile(_contacts);
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting contact with ID {id}: {ex.Message}");
            return false;
        }
    }
}
