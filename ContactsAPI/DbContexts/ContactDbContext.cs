using ContactsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.DbContexts
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
    }
}
