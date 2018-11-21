using ContactsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Commands.ContactsCommands.Interfaces
{
    public interface IUpdateContactCommand
    {
        Task<IActionResult> Execute(int id, Contact contact);
    }
}
