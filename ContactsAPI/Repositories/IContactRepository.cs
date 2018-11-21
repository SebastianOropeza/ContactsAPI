using ContactsAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ContactsAPI.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetContacts();
        Task<int> AddContact(Contact newContact);
        Contact Find(int id);
    }
}