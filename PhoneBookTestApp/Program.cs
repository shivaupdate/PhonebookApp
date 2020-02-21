using System;
using System.Collections.Generic;

namespace PhoneBookTestApp
{
    class Program
    {
        private PhoneBook phonebook = new PhoneBook();
        static void Main(string[] args)
        {
            try
            {


                DatabaseUtil.initializeDatabase();
                //create person objects and put them in the PhoneBook
                PhoneBook objPhonebook = new PhoneBook();
                objPhonebook.addPerson(new Person { name = "John Smith", address = "1234 Sand Hill Dr, Royal Oak, MI", phoneNumber = "(248) 123-4567" });
                objPhonebook.addPerson(new Person { name = "Cynthia Smith", address = "875 Main St, Ann Arbor, MI", phoneNumber = "(824) 128-8758" });
                //create person objects and put them in the Database
                DatabaseUtil.Savecontacts(objPhonebook.personList);

                // print the phone book out to System.out
                Console.Write("********** List of Contact details ************");
                foreach (var item in objPhonebook.personList)
                {
                    Console.WriteLine("Name:{0}, PhoneNumber: {1}, Address : {2}", item.name, item.phoneNumber, item.address);
                }
                // find Cynthia Smith and print out just her entry
                var foundPerson = objPhonebook.findPerson("Cynthia", "Smith");
                Console.WriteLine(foundPerson.name);
                //insert the new person objects into the database

                Console.Write("********** To Store a Person details in phonebook and Database************");
                bool confirmed = false;
                Person objPerson;
                List<Person> ObjpersonToAdd = new List<Person>();
                while (!confirmed)
                {
                    objPerson = new Person();

                    Console.Write("\n Enter Name: ");
                    objPerson.name = Console.ReadLine();
                    Console.Write("Enter Address: ");
                    objPerson.address = Console.ReadLine();
                    Console.Write("Enter Mobile Number: ");
                    objPerson.phoneNumber = Console.ReadLine();
                    objPhonebook.addPerson(objPerson);
                    ObjpersonToAdd.Add(objPerson);
                    Console.WriteLine("Do you want to add more contact? [yes/no]");

                    string option = Console.ReadLine();

                    if (option == "no")
                    {
                        confirmed = true;
                    }

                }
                DatabaseUtil.Savecontacts(ObjpersonToAdd);



                // TODO: print the phone book out to System.out
                // TODO: find Cynthia Smith and print out just her entry
                // TODO: insert the new person objects into the database

            }
            finally
            {
                DatabaseUtil.CleanUp();
            }
        }
    }
}
