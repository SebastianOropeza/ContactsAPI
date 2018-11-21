using ContactsAPI.Commands.ContactsCommands.Interfaces;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsAPI.DbContexts;
using ContactsAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace ContactsAPI.Commands.ContactsCommands
{
    public class CreateContactCommand : ICreateContactCommand
    {
        private readonly IContactRepository _contactRepository;
        private IMapper _contactMapper;

        public CreateContactCommand(IContactRepository contactRepository, IMapper contactmapper)
        {
            _contactRepository = contactRepository;
            _contactMapper = contactmapper;
        }

        public async Task<IActionResult> ExecuteAsync(SaveContact saveContact)
        {
            var newContact = _contactMapper.Map<Contact>(saveContact);

            int newContactID = await _contactRepository.AddContact(newContact);

            return new CreatedAtActionResult("GetContactById", "Contacts", new {id = newContactID }, newContact);
        }
    }
}
