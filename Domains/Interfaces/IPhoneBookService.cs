using System;
using System.Collections.Generic;
using System.Text;

namespace Domains.Interfaces
{
    public interface IPhoneBookService
    {
        void AddNewContact();
        void SearchByPhoneNumber();
        void SearchByName();
        void DeleteContact();
    }
}
