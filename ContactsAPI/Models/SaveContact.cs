﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsAPI.Models
{
    public class SaveContact
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public DateTime BirthDay { get; set; }
        public string PhoneNumberWork { get; set; }
        public string PhoneNumberHome { get; set; }
        public string Address { get; set; }
    }
}
