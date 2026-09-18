
using Services;

namespace PhoneBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //here we only call phonebookservices class and its method
            var phoneBookServices = new PhoneBookServices();
            phoneBookServices.MainChoices();
        }
    }
}