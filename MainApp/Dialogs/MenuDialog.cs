using System.ComponentModel.DataAnnotations;
using Business.Factories;
using Business.Interfaces;
using Business.Models;

namespace MainApp.Dialogs;

public class MenuDialog(IContactService contactService)
{
    private readonly IContactService _contactService = contactService;

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("######  MAIN MENU ######");
            Console.WriteLine(new string('-', 24));
            Console.WriteLine("1. Add New Contact");
            Console.WriteLine("2. View All Contacts");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    AddContact();
                    break;
                case "2":
                    ViewContacts();
                    break;
                case "3":
                    RemoveContact();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option. Try again.");
                    break;
            }
            Console.WriteLine("Press any key to return to the menu...");
            Console.ReadKey();
        }
    }

    private void AddContact()
    {
        try
        {
            Console.Clear();
            Console.WriteLine("###### ADD CONTACT ######");

            string firstName = PromptAndValidate("Enter your first name: ", nameof(Contact.FirstName));
            string lastName = PromptAndValidate("Enter your last name: ", nameof(Contact.LastName));
            string email = PromptAndValidate("Enter your email: ", nameof(Contact.Email));
            string phone = PromptAndValidate("Enter your phone number: ", nameof(Contact.Phone));
            string address = PromptAndValidate("Enter your address: ", nameof(Contact.Address));
            string postalCode = PromptAndValidate("Enter your postal code: ", nameof(Contact.PostalCode));
            string city = PromptAndValidate("Enter your city: ", nameof(Contact.City));

            var newContact = ContactFactory.CreateContact(
                firstName,
                lastName,
                email,
                phone,
                address,
                postalCode,
                city
            );

            _contactService.AddContact(newContact);

            Console.WriteLine("Contact added successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while adding the contact: {ex.Message}");
        }
    }

    private void ViewContacts()
    {
        try
        {
            Console.Clear();
            var contacts = _contactService.GetAllContacts();

            if (!contacts.Any())
            {
                Console.WriteLine("No contacts found.");
            }
            else
            {
                Console.WriteLine("################## ALL CONTACTS ##################");
                Console.WriteLine(new string('-', 30));
                foreach (var contact in contacts)
                {
                    Console.WriteLine();
                    Console.WriteLine($"ID: {contact.Id}");
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine($"Phone: {contact.Phone}");
                    Console.WriteLine($"Address: {contact.Address}, {contact.PostalCode} {contact.City}");
                    Console.WriteLine();
                    Console.WriteLine(new string('-', 50));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while viewing contacts: {ex.Message}");
        }
    }

    private void RemoveContact()
    {
        try
        {
            var contacts = _contactService.GetAllContacts();
            if (!contacts.Any())
            {
                Console.Clear();
                Console.WriteLine("No contacts to delete.");
                return;
            }

            ViewContacts();

            Console.Write("Enter the ID of the contact to delete: ");
            if (Guid.TryParse(Console.ReadLine(), out var id))
            {
                if (_contactService.DeleteContact(id))
                {
                    Console.WriteLine("Contact deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID format. Please enter a valid ID format");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while deleting contacts: {ex.Message}");
        }
    }

    public static string PromptAndValidate(string prompt, string propertyName)
    {
        while (true)
        {
            try
            {
                Console.WriteLine();
                Console.Write(prompt);
                var input = Console.ReadLine() ?? string.Empty;

                var results = new List<ValidationResult>();
                var context = new ValidationContext(new Contact()) { MemberName = propertyName };

                if (Validator.TryValidateProperty(input, context, results))
                    return input;

                Console.WriteLine($"{results[0].ErrorMessage}. Please try again.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during validation: {ex.Message}");
            }
        }
    }
}
