using ContactsWebAPI.Data;
using ContactsWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ContactsWebAPI.Services.ContactService
{
    public class ContactService : IContactService
    {
        public readonly ContactAPIDbContext _context;

        public ContactService(ContactAPIDbContext context)
        {
            _context = context;
        }
        public async Task<List<Contact>> GetAllContacts()
        {
            return await _context.Contacts.ToListAsync();
        }

        public async Task<List<Contact>> AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return await _context.Contacts.ToListAsync();

        }

        public async Task<List<Contact>> DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return null;
            } else
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
                return await _context.Contacts.ToListAsync();
            }
        }

        public async Task<List<Contact>> UpdateContact(Contact contact)
        {
            var con = await _context.Contacts.FindAsync(contact.Id);

            if(con == null)
            {
                return null;
            } else
            {
                con.Name = contact.Name;
                con.Surname = contact.Surname;
                con.Email = contact.Email;
                con.Phone = contact.Phone;
                con.Address = contact.Address;

               await _context.SaveChangesAsync();
               return await _context.Contacts.ToListAsync();
            }

        }
    }
}