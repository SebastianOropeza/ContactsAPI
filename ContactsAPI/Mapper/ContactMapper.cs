using AutoMapper;
using ContactsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Mapper
{
    public class ContactMapper : Profile
    {
        public ContactMapper()
        {
            CreateMap<SaveContact, Contact>();
        }
    }
}
