using Db4objects.Db4o;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace db4o
{
    class Program
    {
        static void Main(string[] args)
        {

            int chooseOption = -1;

            Console.WriteLine(System.IO.File.ReadAllText(@"C:\Users\Varimatras\Documents\Visual Studio 2015\Projects\db4o\db4o\IntroInscription.txt"));

            do
            {
                chooseOption = -1;

                do
                {

                    Console.WriteLine("\nSelect: ");
                    try
                    {
                    chooseOption = Int32.Parse(Console.ReadLine());
                    }
                    catch (FormatException e)
                    {

                        Console.WriteLine("You can't select nothing");
                    }
                } while (chooseOption==-1);


            switch(chooseOption)
                {
                    case 1: 
                        Operation.AddUser();
                        break;
                    case 2:
                        Operation.UpdatePerson();
                        break;
                    case 3:
                        Operation.DeletePerson();
                        break;
                    case 4:
                        Operation.AddAddress();
                        break;
                    case 5:
                        Operation.UpdateAddress();
                        break;
                    case 6:
                        Operation.DeleteAddress();
                        break;
                    case 7:
                        Operation.AddPhones();
                        break;
                    case 8:
                        Operation.UpdatePhone();
                        break;
                    case 9:
                        Operation.DeletePhone();
                        break;
                    case 10:
                        Operation.ShowPerson();
                        break;
                    case 11:
                        Operation.Statistic();
                        break;
                    case 12:
                        Console.WriteLine(System.IO.File.ReadAllText(@"C:\Users\Varimatras\Documents\Visual Studio 2015\Projects\db4o\db4o\IntroInscription.txt"));
                        break;
                    case 0:
                        break;
                    default:
                        chooseOption = 0;
                        break;

                }
            //Operation.DeletePerson();
            } while (chooseOption != 0);

            Console.WriteLine("\nThank You for using ours database :)\n");
        }
    }
}
