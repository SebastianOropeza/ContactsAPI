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

        public ContactsController(
            IGetAllContactsCommand getAllContactsCommand, 
            IGetContactByIdCommand getContactByIdCommand,
            ICreateContactCommand createContactCommand)
        {
            _getAllContactsCommand = getAllContactsCommand;
            _getContactByIdCommand = getContactByIdCommand;
            _createContactCommand = createContactCommand;
        }

        // GET /api/<controller>
        [HttpGet]
        public IActionResult GetAllContacts() => _getAllContactsCommand.Execute();

        // GET /api/<controller>/id
        [HttpGet("{id}")]
        public IActionResult GetContactById([FromRoute]int id) => _getContactByIdCommand.Execute(id);

        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody]SaveContact newContact) => 
            await _createContactCommand.ExecuteAsync(newContact);
    }
}
