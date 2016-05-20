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
            return String.Format("Абонент по имени: {0} {1},зарегистрирован за номером: {2}", firstName, lastName, Number);
        }
        public PhoneBookItem(int number, string firstName, string lastName)
        {
            this.Number = number;
            this.firstName = firstName;
            this.lastName = lastName;
        }
        public bool Findname(PhoneBookItem sp)
        {
            return sp.lastName.Contains(lastName);
        }
        public bool Findnumber(PhoneBookItem sp)
        {
            return sp.Number == Number;
        }
    }
}
