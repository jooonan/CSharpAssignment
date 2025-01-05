using Business.Services;
using MainApp.Dialogs;

/* CHATGPT RECOMMENDING USING A TRY CATCH HERE TO HANDLE UNEXPECTED ERRORS GLOBALLY*/
try
{
    var fileService = new FileService();
    var contactService = new ContactService(fileService);
    var menu = new MenuDialog(contactService);
    menu.Run();
}
catch (Exception ex)
{
    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
}