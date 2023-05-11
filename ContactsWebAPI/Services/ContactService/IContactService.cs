using ContactsWebAPI.Models;

namespace ContactsWebAPI.Services.ContactService
{
    public interface IContactService
    {
        Task<List<Contact>> GetAllContacts();

        Task<List<Contact>> AddContact(Contact contact);

        Task<List<Contact>> DeleteContact(int id);

        Task<List<Contact>> UpdateContact(Contact contact);
    }
}
