using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook
{
    public class PhoneBookItem
    {
        string firstName;
        public string lastName { get; set; }

        public int Number { get; set; }

        public override string ToString()
        {
            return $"Абонент по имени: {firstName} {lastName},зарегистрирован за номером: {Number}";
        }
        public PhoneBookItem(int number, string firstName, string lastName)
        {
            this.Number = number;
            this.firstName = firstName;
            this.lastName = lastName;
        }
        // determines whether the item is part of the list
        public bool Findname(PhoneBookItem sp)
        {
            return sp.lastName.Contains(lastName);
        }
        // determines if the number matches
        public bool Findnumber(PhoneBookItem sp)
        {
            return sp.Number == Number;
        }
    }
}
