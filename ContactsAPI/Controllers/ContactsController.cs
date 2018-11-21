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
        private IGetAllContactsCommand _getAllContactsCommand;
        private IGetContactByIdCommand _getContactByIdCommand;
        private ICreateContactCommand _createContactCommand;
        private IDeleteContactCommand _deleteContactCommand;

        public ContactsController(
            IGetAllContactsCommand getAllContactsCommand, 
            IGetContactByIdCommand getContactByIdCommand,
            ICreateContactCommand createContactCommand,
            IDeleteContactCommand deleteContactCommand
            )
        {
            _getAllContactsCommand = getAllContactsCommand;
            _getContactByIdCommand = getContactByIdCommand;
            _createContactCommand = createContactCommand;
            _deleteContactCommand = deleteContactCommand;
        }

        // GET /api/<controller>
        [HttpGet]
        public IActionResult GetAllContacts() => _getAllContactsCommand.Execute();

        // GET /api/<controller>/id
        [HttpGet("{id}")]
        public IActionResult GetContactById([FromRoute]int id) => _getContactByIdCommand.Execute(id);

        // POST /api/<controller>/
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody]SaveContact newContact) => 
            await _createContactCommand.ExecuteAsync(newContact);

        // DELETE /api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult DeleteContact([FromRoute]int id) => _deleteContactCommand.Execute(id);
    }
}
