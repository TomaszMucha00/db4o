using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using ObjectDataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace db4o
{
    class Operation

    {

        
        public static void AddUser()
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile(@"C:\DBO\ODB.yap"))
            {
                Person p = new Person(null, null, new Address(null, null, null), new Phone(null, null, null));
                Address a = new ObjectDataBase.Address(null, null, null);
                Phone ph = new ObjectDataBase.Phone(null, null, null);

                Console.Write("Name: ");
                p.Name = Console.ReadLine().ToString();

                Console.Write("Surename: ");
                p.SureName = Console.ReadLine().ToString();

                Console.Write("Person address - Street: ");
                a.Street = Console.ReadLine().ToString();

                Console.Write("Person address - City: ");
                a.City = Console.ReadLine().ToString();

                Console.Write("Person address - Postal code: ");
                a.PostalCode = Console.ReadLine().ToString();

                Console.Write("Person phone - Number: ");
                ph.Number = Console.ReadLine().ToString();

                Console.Write("Person phone - Operator: ");
                ph.Operator = Console.ReadLine().ToString();

                Console.Write("Persone phone - Phone type: ");
                ph.PhoneType = Console.ReadLine().ToString();

                p.PersonAddresses.Add(a);
                p.PersonPhones.Add(ph);
                //p.PersonAddresses.Sort();
                //p.PersonPhones.Sort();

                db.Store(p);

                Console.WriteLine("\nPerson is added to database\n");
            }
        }

        public static void AddAddress()
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile(@"C:\DBO\ODB.yap"))
            {

                Console.WriteLine("\nInsert person surename who address you want modificate: \n");

                string userSurename = Console.ReadLine();

                IObjectSet result = db.QueryByExample(new Person(null, userSurename, new Address(null, null, null), new Phone(null, null, null)));
                Person found;

                if (result.HasNext())
                {
                    found = (Person)result.Next();

                    Address TempAddress = new Address(null, null, null);

                    Console.Write("person address - street: ");
                    TempAddress.Street = Console.ReadLine().ToString();

                    Console.Write("Person address - City: ");
                    TempAddress.City = Console.ReadLine().ToString();

                    Console.Write("Person address - Postal code: ");
                    TempAddress.PostalCode = Console.ReadLine().ToString();

                    found.PersonAddresses.Add(TempAddress);

                    db.Store(found.PersonAddresses);
                    //found.PersonAddresses.Sort();
                }
            }
        }

        public static void AddPhones()
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile(@"C:\DBO\ODB.yap"))
            {

                Console.WriteLine("\nInsert person surename who address you want modificate: \n");

                string userSurename = Console.ReadLine();

                IObjectSet result = db.QueryByExample(new Person(null, userSurename, new Address(null, null, null), new Phone(null, null, null)));
                Person found;

                if (result.HasNext())
                {
                    found = (Person)result.Next();

                    Phone TempPhone = new Phone(null, null, null);

                    Console.Write("person phone - Number: ");
                    TempPhone.Number = Console.ReadLine().ToString();

                    Console.Write("Person phone - Operator: ");
                    TempPhone.Operator = Console.ReadLine().ToString();

                    Console.Write("Person phone - Phone type: ");
                    TempPhone.PhoneType = Console.ReadLine().ToString();

                    found.PersonPhones.Add(TempPhone);

                    db.Store(found.PersonPhones);
                    //found.PersonAddresses.Sort();
                }
            }
        }

        public static void UpdateAddress()
        {

            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();
            config.Common.ObjectClass(typeof(Person)).CascadeOnUpdate(true);
            using (IObjectContainer db = Db4oEmbedded.OpenFile(config, @"C:\DBO\ODB.yap"))
            {
                string userSurename;

                Console.WriteLine("\nInsert person surename who address You want modificate: \n");

                userSurename = Console.ReadLine(); 

                string TempAddressCity;
                string TempAddressStreet;

                Console.WriteLine("\nSelect address witch You want modificate by city and street: \n");

                Console.WriteLine("Street: \n");
                TempAddressStreet = Console.ReadLine();
                Console.WriteLine("City: \n");
                TempAddressCity = Console.ReadLine();

                string forStoreStreet = "";
                string forStoreCity = "";

                IObjectSet result = db.QueryByExample(new Person(null, userSurename, new Address(null, null, null), new Phone(null, null, null)));
                Person found;

                if (result.HasNext())
                {
                    found = (Person)result.Next();

                    foreach (Address address in found.PersonAddresses.Where((x => x.City==TempAddressCity)).Where((x => x.Street == TempAddressStreet)))
                    {
                        Console.Write("Person address - Street: ");
                        address.Street = Console.ReadLine().ToString();
                        forStoreStreet = address.Street;

                        Console.Write("Person address - City: ");
                        address.City = Console.ReadLine().ToString();
                        forStoreCity = address.City;

                        Console.Write("Person address - Postal code: ");
                        address.PostalCode = Console.ReadLine().ToString();
                    }

                    foreach (var item in found.PersonAddresses)
                    {
                        Console.WriteLine(item.City);
                    }

                  

                    db.Activate(found, 100);

                    

                    db.Store(found.PersonAddresses.Find(x=>(x.City == forStoreCity)&&(x.Street==forStoreStreet)));
                }
                else
                {
                    Console.WriteLine("\nThis peron don't exist in database");
                }

            }
        }

        public static void UpdatePhone()
        {

            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();
            config.Common.ObjectClass(typeof(Person)).CascadeOnUpdate(true);
            using (IObjectContainer db = Db4oEmbedded.OpenFile(config, @"C:\DBO\ODB.yap"))
            {
                string userSurename;

                Console.WriteLine("\nInsert person surename who phone You want modificate: \n");

                userSurename = Console.ReadLine();

                string TempPhoneNumber;

                Console.WriteLine("\nSelect phone witch You want modificate by number: \n");

                Console.WriteLine("Number: \n");
                TempPhoneNumber = Console.ReadLine();
                
                string forStoreNumber = "";
                

                IObjectSet result = db.QueryByExample(new Person(null, userSurename, new Address(null, null, null), new Phone(null, null, null)));
                Person found;

                if (result.HasNext())
                {
                    found = (Person)result.Next();

                    foreach (Phone phones in found.PersonPhones.Where(x => x.Number == TempPhoneNumber))
                    {
                        Console.Write("Person phone - Number: ");
                        phones.Number = Console.ReadLine().ToString();
                        forStoreNumber = phones.Number;

                        Console.Write("Person phone - Operator: ");
                        phones.Operator = Console.ReadLine().ToString();

                        Console.Write("Person phone - Phone type: ");
                        phones.PhoneType = Console.ReadLine().ToString();
                    }

                    foreach (var item in found.PersonPhones)
                    {
                        Console.WriteLine(item.Number);
                    }



                    db.Activate(found, 100);



                    db.Store(found.PersonPhones.Find(x => x.Number == forStoreNumber));
                }
                else
                {
                    Console.WriteLine("\nThis peron don't exist in database");
                }

            }
        }

        #region OperationOnPersonAddressPrototype
        //public static void OperationOnPersonAddress()
        //{
        //    using (IObjectContainer db = Db4oEmbedded.OpenFile(@"C:\DBO\ODB.yap"))
        //    {

        //        string userSurename;

        //        Console.WriteLine("\nInsert person surename who address you want modificate: \n");

        //        userSurename = Console.ReadLine();

        //        IObjectSet result = db.QueryByExample(new Person(null, userSurename, new Address(null, null, null), new Phone(null, null, null)));
        //        Person found;

        //        if (result.HasNext())
        //        {
        //            found = (Person)result.Next();

        //            Console.WriteLine("\n 1) Add address \n 2) Modyficate address \n 3) Delete address \n \n 0 to exit address operation");

        //            int chooseOption = -1;

        //            do
        //            {

        //                Console.WriteLine("\nSelect: ");
        //                chooseOption = Int32.Parse(Console.ReadLine());

        //                switch (chooseOption)
        //                {
        //                    case 1:
        //                        Address TempAddress = new Address(null, null, null);

        //                        Console.Write("Person address - Street: ");
        //                        TempAddress.Street = Console.ReadLine().ToString();

        //                        Console.Write("Person address - City: ");
        //                        TempAddress.City = Console.ReadLine().ToString();

        //                        Console.Write("Person address - Postal code: ");
        //                        TempAddress.PostalCode = Console.ReadLine().ToString();

        //                        found.PersonAddresses.Add(TempAddress);
        //                        //found.PersonAddresses.Sort();
        //                        break;
        //                    case 2:
        //                        //string temp

        //                        //Console.Write("Select address to modyficate: ");

        //                        //TempAddress.Street = Console.ReadLine().ToString();
        //                        break;
        //                    case 3:

        //                        break;
        //                    case 0:
        //                        break;
        //                    default:
        //                        chooseOption = 0;
        //                        break;

        //                }
        //            } while (chooseOption != 0);


        //            //found = (Person)result.Next();

        //            db.Store(found);

        //            Console.WriteLine("\n Person data modificated");
        //        }
        //        else
        //        {
        //            Console.WriteLine("\nThis peron don't exist in database");
        //        }
        //    }
        //}
        #endregion

        public static void UpdatePerson()
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile(@"C:\DBO\ODB.yap"))
            {

                string userSurename;

                Console.WriteLine("\nInsert person surename who you want modificate: \n");

                userSurename = Console.ReadLine();

                IObjectSet result = db.QueryByExample(new Person(null, userSurename, new Address(null, null, null), new Phone(null, null, null)));
                Person found;

                if (result.HasNext())
                {
                    found = (Person)result.Next();

                    Address TempPersonAddress = new Address(null, null, null);
                    Phone TempPersonPhone = new Phone(null, null, null);

                    Console.Write("\nName: ");
                    found.Name = Console.ReadLine().ToString();

                    Console.Write("Surename: ");
                    found.SureName = Console.ReadLine().ToString();

                    Console.Write("Person address - Street: ");
                    TempPersonAddress.Street = Console.ReadLine().ToString();

                    Console.Write("Person address - City: ");
                    TempPersonAddress.City = Console.ReadLine().ToString();

                    Console.Write("Person address - Postal code: ");
                    TempPersonAddress.PostalCode = Console.ReadLine().ToString();

                    Console.Write("Person phone - Number: ");
                    TempPersonPhone.Number = Console.ReadLine().ToString();

                    Console.Write("Person phone - Operator: ");
                    TempPersonPhone.Operator = Console.ReadLine().ToString();

                    Console.Write("Persone phone - Phone type: ");
                    TempPersonPhone.PhoneType = Console.ReadLine().ToString();

                    //found.PersonAddresses.
                   // found.PersonPhone = TempPersonPhone;

                    db.Store(found);

                    Console.WriteLine("\n Person data modificated");
                }
                else
                {
                    Console.WriteLine("\nThis peron don't exist in database");
                }


                //RetrieveAllPerson(db);
            }
        }

        public static void ShowPerson()
        {
            using (IObjectContainer db = Db4oEmbedded.OpenFile(@"C:\DBO\ODB.yap"))
            {
                string tempUserSurename;

                Console.WriteLine("Select surename to choose specyfic person, don't select do choose all ");

                tempUserSurename = Console.ReadLine();

                if (tempUserSurename == "")
                {
                    Person proto = new Person(null, null, new Address(null, null, null), new ObjectDataBase.Phone(null, null, null));
                    IObjectSet result = db.QueryByExample(proto);

                    foreach (object item in result)
                    {
                        Console.WriteLine(item);
                    }
                }
                else
                {
                    Person proto = new Person(null, tempUserSurename, new Address(null, null, null), new ObjectDataBase.Phone(null, null, null));
                    IObjectSet result = db.QueryByExample(proto);

                    foreach (object item in result)
                    {
                        Console.WriteLine(item);
                    }
                }


            }
        }

        public static void ListResult(IObjectSet result)
        {
            foreach (object item in result)
            {
                Console.WriteLine(item);
            }
        }

        public static void RetrieveAllPerson(IObjectContainer db)
        {
            IObjectSet result = db.QueryByExample(typeof(Person));
            ListResult(result);
        }

        public static void DeletePerson()
        {

            using (IObjectContainer db = Db4oEmbedded.OpenFile(@"C:\DBO\ODB.yap"))
            {


                string userName;

                Console.WriteLine("Insert person surname who you want delete: ");

                userName = Console.ReadLine();

                IObjectSet result = db.QueryByExample(new Person(null, userName, new Address(null, null, null), new ObjectDataBase.Phone(null, null, null)));
                Person found;
                if (result.HasNext())
                {
                    found = (Person)result.Next();
                    db.Delete(found);
                    //RetrieveAllPerson(db);

                    Console.WriteLine("\nPerson has been deleted from database");

                }
                else
                {
                    Console.WriteLine("This person don't exist in database");
                }
            }


        }

        public static void DeleteAddress()
        {

            using (IObjectContainer db = Db4oEmbedded.OpenFile(@"C:\DBO\ODB.yap"))
            {


                string userName;
                string DeleteStreet;
                string DeleteCity;

                Console.WriteLine("Insert person surname who address You want delete: ");

                userName = Console.ReadLine();

                Console.WriteLine("Insert address witch You want delete, by city and street: ");

                Console.WriteLine("Street: ");

                DeleteStreet = Console.ReadLine();

                Console.WriteLine("City: ");

                DeleteCity = Console.ReadLine();

                IObjectSet result = db.QueryByExample(new Person(null, userName, new Address(null, null, null), new ObjectDataBase.Phone(null, null, null)));
                Person found;
                if (result.HasNext())
                {
                    found = (Person)result.Next();
                    db.Delete(found.PersonAddresses.Find(x => (x.City == DeleteCity) && (x.Street == DeleteStreet)));
                    //RetrieveAllPerson(db);

                    Console.WriteLine("\nPerson address has been deleted from database");

                }
                else
                {
                    Console.WriteLine("This person don't exist in database");
                }
            }


        }

        public static void DeletePhone()
        {

            using (IObjectContainer db = Db4oEmbedded.OpenFile(@"C:\DBO\ODB.yap"))
            {


                string userName;
                string DeleteNumber;

                Console.WriteLine("Insert person surename who phone You want delete: ");

                userName = Console.ReadLine();

                Console.WriteLine("Insert phone witch You want delete, by number: ");

                Console.WriteLine("Number: ");

                DeleteNumber = Console.ReadLine();
                
                IObjectSet result = db.QueryByExample(new Person(null, userName, new Address(null, null, null), new ObjectDataBase.Phone(null, null, null)));
                Person found;
                if (result.HasNext())
                {
                    found = (Person)result.Next();
                    db.Delete(found.PersonAddresses.Find(x => x.City == DeleteNumber));
                    //RetrieveAllPerson(db);

                    Console.WriteLine("\nPerson phone has been deleted from database");

                }
                else
                {
                    Console.WriteLine("This person don't exist in database");
                }
            }


        }

        public static void Statistic()
        {

            using (IObjectContainer db = Db4oEmbedded.OpenFile(@"C:\DBO\ODB.yap"))
            {

                IObjectSet result = db.QueryByExample(new Person(null, null, new Address(null, null, null), new ObjectDataBase.Phone(null, null, null)));

                Person found;

                Console.WriteLine("There is " + result.Ext().Count + " persone in database\n");

                int AddressesCounter = 0;
                int PhonesCounter = 0;

                while (result.HasNext())
                {
                    found = (Person)result.Next();
                    AddressesCounter += found.PersonAddresses.Count;
                    PhonesCounter += found.PersonPhones.Count;
                }

                Console.WriteLine("There is " + AddressesCounter + " address in database\n");

                Console.WriteLine("There is " + PhonesCounter + " phone in database\n");
            }


        }


    }
}

