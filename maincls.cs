using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook
{
    public class maincls
    {
        static void Main()
        {
            booktest obj = new booktest();

            int choose;

            do
            {
                Console.WriteLine("Welcome to Address Book Program\n");

                Console.WriteLine("1. Add New Contact");
                Console.WriteLine("2. Show Details Of A Contact");
                Console.WriteLine("3. Edit A Contact");
                Console.WriteLine("4. Delete A Contact");
                Console.WriteLine("5. View All Contacts For A State or City");
                Console.WriteLine("6. Get Count of Contacts");
                Console.WriteLine("7. Exit\n");

                choose = Convert.ToInt32(Console.ReadLine());

                if (choose == 1)
                {
                    Console.WriteLine(obj.AddContact());
                }

                else if (choose == 2)
                {
                    obj.ShowDetail();
                }
                /*for (int i = 0; i < users.Count; i++)
                {
                    Console.WriteLine(users[i].name);
                }*/

                else if (choose == 3)
                {


                    obj.EditDetail();
                }

                else if (choose == 4)
                {
                    obj.DeleteCont();

                }

                else if (choose == 5)
                {
                    obj.ViewPreferredCont();
                }

                else if (choose == 6)
                {
                    Console.WriteLine($"\n$There are {obj.ContactCount()} Contacts in the Address Book");
                }


            } while (choose != 7);



        }
    }
}
