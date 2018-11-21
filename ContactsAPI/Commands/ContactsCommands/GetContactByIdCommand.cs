using ContactsAPI.Commands.ContactsCommands.Interfaces;
using ContactsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Commands.ContactsCommands
{
    public class GetContactByIdCommand : IGetContactByIdCommand
    {
        private IContactRepository _contactRepository;

        public GetContactByIdCommand(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Execute(int id)
        {
            var contact = _contactRepository.GetContacts().SingleOrDefault(p => p.ID == id);

            if (contact == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(contact);
        }
    }
}
