
using Services;

namespace PhoneBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phoneBookServices = new PhoneBookServices();
            phoneBookServices.MainChoices();
        }
    }
}