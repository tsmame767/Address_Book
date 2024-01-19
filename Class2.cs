using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook
{
    internal class booktest
    {

        /*
        static Dictionary<int,string> Namedict = new Dictionary<int,string>();
        static Dictionary<int,string> Emaildict = new Dictionary<int,string>();
        static Dictionary<int,string> Citydict = new Dictionary<int,string>();
        static Dictionary<int,string> Statedict = new Dictionary<int,string>();
        static Dictionary<int,long> Contactdict = new Dictionary<int,long>();
        static Dictionary<int,int> Zipdict = new Dictionary<int,int>();
        */

        static List<User> users = new List<User>(); //global list

        static void ListAdd(User Obj) //method for adding objects to the list
        {
            users.Add(Obj);    
        }
        static void AddContact() //method for creating a new contact
        {
            string name;
            string email;
            string city;
            string state;
            int contact;
            int zip;



            // Data Collecting 
            Console.WriteLine("Enter Name :");
            name = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter Email :");
            email = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter City :");
            city = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter State :");
            state = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter Contact :");
            contact = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Zip :");
            zip = Convert.ToInt32(Console.ReadLine());

            /*
            Namedict.Add(contact, name);
            Emaildict.Add(contact, email);
            Citydict.Add(contact, city);
            Statedict.Add(contact, state);
            Contactdict.Add(contact, contact);
            Zipdict.Add(contact, zip);*/




            //Data Storing
            User u1 = new User(name,email,city,state,contact,zip);


            //Object Adding to List
            ListAdd(u1);

        }

        static void ShowDetail()
        {
            Console.WriteLine("Enter the your contact number: ");
            int phone = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("name " + Namedict[phone]);

            

            for (int i = 0; i < users.Count; i++)
            {

                if (phone == users[i].contact)
                {
                    Console.WriteLine($"Name : {users[i].name}");
                    Console.WriteLine($"Email : {users[i].email}");
                    Console.WriteLine($"City : {users[i].city}");
                    Console.WriteLine($"State : {users[i].state}");
                    Console.WriteLine($"Contact : {users[i].contact}");
                    Console.WriteLine($"Zip : {users[i].zip}");
                }
            }

        }


        static void Main()
        {
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
                Console.WriteLine("7. Exit");

                choose = Convert.ToInt32(Console.ReadLine());

                if (choose == 1)
                {
                    AddContact();
                }

            else if( choose == 2)
                {
                    ShowDetail ();
                }
                /*for (int i = 0; i < users.Count; i++)
                {
                    Console.WriteLine(users[i].name);
                }*/
            } while (choose != 7);



        }
    }


}
