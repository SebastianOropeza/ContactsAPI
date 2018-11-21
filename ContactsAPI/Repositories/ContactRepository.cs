using ContactsAPI.Commands.ContactsCommands;
using ContactsAPI.DbContexts;
using ContactsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Repositories
{
    public class ContactRepository : IContactRepository
    {
        ContactDbContext context;

        public ContactRepository(ContactDbContext ctx)
        {
            context = ctx;
        }

        public IEnumerable<Contact> GetContacts()
        {
            return context.Contacts;
        }

        public Contact Find(int id)
        {
            return context.Contacts.Single(p => p.ID == id );
        }

        public async Task<int> AddContact(Contact newContact)
        {
            context.Contacts.AddRange(newContact);
            await context.SaveChangesAsync();

            return newContact.ID;
        }

        public void DeleteContact(Contact contact)
        {
            context.Remove(contact);
            context.SaveChanges();
        }
    }
}
