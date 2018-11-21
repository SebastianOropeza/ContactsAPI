using ContactsAPI.Commands.ContactsCommands.Interfaces;
using ContactsAPI.Models;
using ContactsAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Commands.ContactsCommands
{
    public class DeleteContactCommand : IDeleteContactCommand
    {
        private readonly IContactRepository _contactRepository;

        public DeleteContactCommand(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Execute(int id)
        {
            var contact = _contactRepository.GetContacts().Single(p => p.ID == id);

            if (contact == null)
            {
                return new NotFoundResult();
            }

            _contactRepository.DeleteContact(contact);

            return new OkObjectResult(contact);
        }
    }
}
