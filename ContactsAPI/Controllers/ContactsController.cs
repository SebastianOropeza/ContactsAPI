using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactsAPI.Commands.ContactsCommands.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactsAPI.Controllers
{
    [Route("api/[controller]")]
    public class ContactsController : Controller
    {
        private IGetAllContactsCommand _getAllContactsCommand;

        public ContactsController(IGetAllContactsCommand getAllContactsCommand)
        {
            _getAllContactsCommand = getAllContactsCommand;
        }

        // GET /api/<controller>
        [HttpGet]
        public IActionResult GetAllContacts() => _getAllContactsCommand.Execute();
    }
}
