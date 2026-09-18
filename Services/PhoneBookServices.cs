using Domains.Entities;
using Domains.Enums;
using Domains.Interfaces;

namespace Services
{
    public class PhoneBookServices: IPhoneBookService
    {

        #region here is where the logic of the project done


        private List<PhoneBook> _phonebook;

        // Constructor
        public PhoneBookServices()
        {
            if (_phonebook == null)
            {
                _phonebook = new List<PhoneBook>();
            }
        }

        // this method handle the choice of the user
        public void MainChoices()
        {
            try
            {
                int answer = 0;

                while (answer != -1)
                {
                    Console.WriteLine("1- Enter New Phonebook");
                    Console.WriteLine("2- Search by Phone Number");
                    Console.WriteLine("3- Search by Name");
                    Console.WriteLine("4- Delete Phonebook");
                    Console.WriteLine("5- Enter -1 to exit");

                    answer = int.Parse(Console.ReadLine());

                    if (answer == 1)
                    {
                        AddNewContact();
                    }
                    else if (answer == 2)
                    {
                        SearchByPhoneNumber();
                    }
                    else if (answer == 3)
                    {
                        SearchByName();
                    }
                    else if (answer == 4)
                    {
                        DeleteContact();
                    }
                    else if (answer == -1)
                    {
                        Console.WriteLine("Exiting...");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid choice. Please try again.");
                    }
                }
            }
            catch (Exception)
            {

                Console.WriteLine("An error occurred while processing your choice. Please try again.");
            }
        }


        //this is a method to add new phonebook
        public void AddNewContact()
        {
            try
            {
                Console.WriteLine("Enter Name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter Phone Number (Phone Number should be valid in Jordan):");
                string phoneNumber = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Name is required.");
                }
                else if (phoneNumber.Length != 10 ||
                         (!phoneNumber.StartsWith("077") &&
                          !phoneNumber.StartsWith("078") &&
                          !phoneNumber.StartsWith("079")))
                {
                    Console.WriteLine("Invalid phone number.");
                }
                else if (_phonebook.Any(p => p.PhoneNumber == phoneNumber))
                {
                    Console.WriteLine("This phone number already exists.");
                }
                else
                {
                    var newPhoneBook = new PhoneBook();

                    newPhoneBook.FullName = name;
                    newPhoneBook.PhoneNumber = phoneNumber;
                    //this is type of enum we can use it to categorize the contacts
                    //by default we set it to family but we can add a method to choose the type of contact
                    newPhoneBook.Type = ContactType.Family;

                    _phonebook.Add(newPhoneBook);

                    Console.WriteLine("Contact added successfully.");
                }
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred while adding a new phonebook entry.");
            }
        }




        //this is a search by phone number method
        public void SearchByPhoneNumber()
        {
            try
            {
                Console.WriteLine("Enter the Phone Number:");
                string phoneNumber = Console.ReadLine();

                var contact = _phonebook.FirstOrDefault(p => p.PhoneNumber == phoneNumber);

                if (contact != null)
                {

                    // here we used DTO to transfer data from the entity to the presentation layer
                    var dto = new PhoneBookDTO();
                    dto.FullName = contact.FullName;
                    dto.PhoneNumber = contact.PhoneNumber;

                    Console.Write($"Name: {dto.FullName}"+"    ");
                    Console.WriteLine($"Phone: {dto.PhoneNumber}");
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred while searching the contact");
            }
        }





        //this is a search by name method
        public void SearchByName()
        {
            try
            {
                Console.WriteLine("Enter the Name:");
                string name = Console.ReadLine();

                var contacts = _phonebook.Where(q => q.FullName.Contains(name,
                    StringComparison.OrdinalIgnoreCase)).ToList();

                if (contacts.Count > 0)
                {
                    foreach (var contact in contacts)
                    {
                        var dto = new PhoneBookDTO();

                        dto.FullName = contact.FullName;
                        dto.PhoneNumber = contact.PhoneNumber;

                        Console.Write($"Name: {dto.FullName}"+"    ");
                        Console.WriteLine($"Phone: {dto.PhoneNumber}");
                    }
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred while searching the contact");

            }
        }






        //this is a delete contact method
        public void DeleteContact()
        {
            try
            {
                Console.WriteLine("Enter the Phone Number of the contact to delete:");
                string deletedContact = Console.ReadLine();

                var contact = _phonebook.FirstOrDefault(p => p.PhoneNumber == deletedContact);

                if (contact != null)
                {
                    _phonebook.Remove(contact);
                    Console.WriteLine("Contact deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Contact not found.");
                }

            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred while deleting the contact");
            }


        }
    }
}
    #endregion