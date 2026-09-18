using Domains.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domains.Entities
{
    public class PhoneBook : Base
    {
        public ContactType Type { get; set; }
    }
}
