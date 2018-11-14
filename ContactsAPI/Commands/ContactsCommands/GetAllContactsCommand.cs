using ContactsAPI.Commands.ContactsCommands.Interfaces;
using ContactsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Commands.ContactsCommands
{
    public class GetAllContactsCommand : IGetAllContactsCommand
    {
        private IContactRepository _contactRepository;

        public GetAllContactsCommand(
            IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }

        public IActionResult Execute()
        {
            var contacts = _contactRepository.GetContacts().OrderBy(p => p.ID);

            if (contacts == null)
            {
                return new NotFoundResult();
            }

            return new OkObjectResult(contacts);
        }
    }
}
