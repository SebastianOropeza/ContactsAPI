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
    public class UpdateContactCommand : IUpdateContactCommand
    {
        private readonly IContactRepository _contactRepository;

        public UpdateContactCommand(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IActionResult> Execute(int id, Contact contact)
        {
            var existingContact = _contactRepository.Find(id);

            if (contact == null)
            {
                return new NotFoundResult();
            }

            contact.ID = existingContact.ID;
            contact = await _contactRepository.UpdateContact(contact);

            return new OkObjectResult(contact);
        }
    }
}
