using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsAPI.Commands.ContactsCommands.Interfaces;
using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactsAPI.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private readonly IGetAllContactsCommand _getAllContactsCommand;
        private readonly IGetContactByIdCommand _getContactByIdCommand;
        private readonly ICreateContactCommand _createContactCommand;
        private readonly IDeleteContactCommand _deleteContactCommand;
        private readonly IUpdateContactCommand _updateContactCommand;

        public ContactsController(
            IGetAllContactsCommand getAllContactsCommand, 
            IGetContactByIdCommand getContactByIdCommand,
            ICreateContactCommand createContactCommand,
            IDeleteContactCommand deleteContactCommand,
            IUpdateContactCommand updateContactCommand
            )
        {
            _getAllContactsCommand = getAllContactsCommand;
            _getContactByIdCommand = getContactByIdCommand;
            _createContactCommand = createContactCommand;
            _deleteContactCommand = deleteContactCommand;
            _updateContactCommand = updateContactCommand;
        }

        // GET /api/<controller>
        [HttpGet]
        public IActionResult GetAllContacts() => 
            _getAllContactsCommand.Execute();

        // GET /api/<controller>/id
        [HttpGet("{id}")]
        public IActionResult GetContactById([FromRoute]int id) => 
            _getContactByIdCommand.Execute(id);

        // POST /api/<controller>/
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody]SaveContact newContact) => 
            await _createContactCommand.ExecuteAsync(newContact);

        // DELETE /api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteContact([FromRoute]int id) => 
            _deleteContactCommand.Execute(id);

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateContact([FromRoute]int id, [FromBody]Contact contact) => 
            await _updateContactCommand.Execute(id, contact);
    }
}
