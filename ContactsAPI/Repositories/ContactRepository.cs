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
    }
}
