using ContactsAPI.Models;
using System.Collections.Generic;

namespace ContactsAPI.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetContacts();
    }
}