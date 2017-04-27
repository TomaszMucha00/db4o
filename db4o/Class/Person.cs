using System.Collections.Generic;

namespace ObjectDataBase
{
    class Person
    {

        public string Name { get; set; }
        public string SureName { get; set; }
        public List<Address> PersonAddresses = new List<Address>();
        public List<Phone> PersonPhones = new List<Phone>();

        public Person(string Name, string SureName, Address PersonAddress, Phone PersonPhone)
        {
            this.Name = Name;
            this.SureName = SureName;
            this.PersonAddresses.Add(PersonAddress);
            this.PersonPhones.Add(PersonPhone);
        }

        override public string ToString()
        {
            string temp = "-------------------------------------------------------------------\n";

            temp = temp + "**********************************************************\n******************Person Name and Surname*****************\n**********************************************************" + 
                "\n\n" + Name + " " + SureName + "\n"  + 
                "\n**********************************************************\n*********************Person Adresses**********************\n**********************************************************";

            foreach (var item in PersonAddresses)
            {
                temp = temp + "\n" + item.Street + " " + item.PostalCode + " " + item.City;
            }

            foreach (var item in PersonPhones)
            {
                temp = temp + "\n" + item.Number + " " + item.Operator + " " + item.PhoneType;
            }

            temp += "\n-------------------------------------------------------------------";

            return temp;
        }


    }
}
