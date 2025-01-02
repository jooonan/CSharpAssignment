using Business.Models;

namespace Business.Interfaces;

public interface IFileService
{
    void SaveToFile(List<Contact> contacts);
    List<Contact> LoadFromFile();
}