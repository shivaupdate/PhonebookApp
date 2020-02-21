using System.Collections.Generic;

namespace PhoneBookTestApp
{
    public class PhoneBook : IPhoneBook
    {
        public List<Person> personList = new List<Person>();

        public void addPerson(Person person)
        {
            personList.Add(person);
        }

        public Person findPerson(string firstName, string lastName)
        {

            return personList.Find(x => x.name == firstName + " " + lastName);
        }
    }
}