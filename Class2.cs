using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace addressbook
{
    public class booktest
    {

        /*
        static Dictionary<int,string> Namedict = new Dictionary<int,string>();
        static Dictionary<int,string> Emaildict = new Dictionary<int,string>();
        static Dictionary<int,string> Citydict = new Dictionary<int,string>();
        static Dictionary<int,string> Statedict = new Dictionary<int,string>();
        static Dictionary<int,long> Contactdict = new Dictionary<int,long>();
        static Dictionary<int,int> Zipdict = new Dictionary<int,int>();
        */

        public int ContactCount = 0;

        public List<User> users = new List<User>(); //global list

        public void ListAdd(User Obj) //method for adding objects to the list
        {
            users.Add(Obj);    
        }

        public bool checkcont(long num)
        {
            for(int i=0;i<users.Count;i++)
            {
                if (num == users[i].contact)
                {
                    return true;
                }

            }
            return false;
        }
        public void AddContact() //method for creating a new contact
        {
            string name="";
            string email="";
            string city="";
            string state="";
            long contact=0;
            int zip=0;

            bool invalid = true;



            // Data Collecting 

            while (true)
            {
                if (invalid)
                {
                    Console.WriteLine("Enter Name :");
                    name= Convert.ToString(Console.ReadLine());
                    invalid = !Regex.IsMatch(name, "^[A-Za-z]{2,}$");
                }
                else
                {
                    invalid = true;
                    break;
                    
                }
            }

            while (true)
            {
                if (invalid)
                {
                    Console.WriteLine("Enter Email :");
                    email = Convert.ToString(Console.ReadLine());
                    invalid = !Regex.IsMatch(email, "^[A-Za-z0-9]{2,}[@][a-z]{2,}[.][a-z.]{2,}$");
                }
                else
                {
                    invalid = true;
                    break;
                }
            }

            while (true)
            {
                if (invalid)
                {
                    Console.WriteLine("Enter City :");
                    city = Convert.ToString(Console.ReadLine());
                    invalid = !Regex.IsMatch(city, "^[A-za-z]{2,}$");
                }
                else
                {
                    invalid = true;
                    break;
                }
            }

            while (true)
            {
                if (invalid)
                {
                    Console.WriteLine("Enter State :");
                    state = Convert.ToString(Console.ReadLine());
                    invalid = !Regex.IsMatch(state, "^[A-Za-z]{2,}$");
                }
                else
                {
                    invalid = true;
                    break;
                }
            }

            while (true)
            {
                if (invalid)
                {
                    Console.WriteLine("Enter Zip :");
                    zip = Convert.ToInt32(Console.ReadLine());
                    invalid = !Regex.IsMatch(Convert.ToString(zip), "^[0-9]{6}$");
                }
                else
                {
                    invalid = true;
                    break;
                }
            }

            while (true)
            {
                if (invalid)
                {
                    Console.WriteLine("Enter Contact :");
                    contact = Convert.ToInt64(Console.ReadLine());
                    while (true)
                    {
                        if (checkcont(contact))
                        {
                            Console.WriteLine("This contact already exists\nenter the details again!: ");
                            contact = Convert.ToInt64(Console.ReadLine());
                        }
                        else
                        {
                            invalid = !Regex.IsMatch(Convert.ToString(contact), "^[6-9][0-9]{9}$");
                            break;
                        }

                    }
                    
                }
                else
                {
                    invalid = true;
                    break;
                }
            }

            

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
            ContactCount++;

        }



        public void ShowDetail()
        {
            Console.WriteLine("Enter the your contact number: ");
            long phone = Convert.ToInt64(Console.ReadLine());

            //Console.WriteLine("name " + Namedict[phone]);

            int itr = 0;

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
                else
                {
                    itr++;
                }



            }
            if (itr==users.Count())
            {
                Console.WriteLine("no such details found");
            }

        }

        public string CheckInstr(string inp, string comp)
        {
            if (inp == "\n")
            {
                return comp;
            }
            return inp;
        }
        public long CheckInp(string inp, long comp)
        {
            if (inp == "")
            {
                return comp;
            }

            return Convert.ToInt32(inp);
        }
        public void EditDetail()
        {
            Console.WriteLine("Enter the your contact number: ");
            long phone = Convert.ToInt64(Console.ReadLine());

            for (int i = 0; i < users.Count; i++)
            {

                if (phone == users[i].contact)
                {
                    //show previous value
                    Console.WriteLine($"\n\nPrevious name {users[i].name}");
                    Console.WriteLine($"Previous email {users[i].email}");
                    Console.WriteLine($"Previous city {users[i].city}");
                    Console.WriteLine($"Previous state {users[i].state}");
                    Console.WriteLine($"Previous zip {users[i].zip}");
                    Console.WriteLine($"Previous contact {users[i].contact} \n\n");

                    //set value
                    Console.WriteLine("Edit Name: ");
                    users[i].name = CheckInstr(Console.ReadLine(), users[i].name);

                    Console.WriteLine("Edit Email: ");
                    users[i].email = CheckInstr(Console.ReadLine(), users[i].email);

                    Console.WriteLine("Edit City: ");
                    users[i].city = CheckInstr(Console.ReadLine(), users[i].city);

                    Console.WriteLine("Edit State: ");
                    users[i].state = CheckInstr(Console.ReadLine(), users[i].state);

                    Console.WriteLine("Edit Zip: ");
                    users[i].zip = CheckInp(Console.ReadLine(), users[i].zip);

                    Console.WriteLine("Edit Contact: ");
                    users[i].contact = CheckInp(Console.ReadLine(), users[i].contact);

                    //show updated value
                    Console.WriteLine($"\n\n updated name {users[i].name}");
                    Console.WriteLine($"updated email {users[i].email}");
                    Console.WriteLine($"updated city {users[i].city}");
                    Console.WriteLine($"updated state {users[i].state}");
                    Console.WriteLine($"updated zip {users[i].zip}");
                    Console.WriteLine($"updated contact {users[i].contact}");



                }
            }
        }

        public void DeleteCont()
        {
            Console.WriteLine("Enter the your contact number: ");
            long phone = Convert.ToInt64(Console.ReadLine());

            for (int i = 0; i < users.Count; i++)
            {

                if (phone == users[i].contact)
                {
                    users.RemoveAt(i);
                }
            }
            ContactCount--;
        }

        public void ViewPreferredCont()
        {
            //Console.WriteLine("Enter the your contact number: ");
            //int phone = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter city or state: ");
            string Region = Console.ReadLine();
            for (int i = 0; i < users.Count(); i++)
            {
                //if (users[i].contact == phone)
                //{
                    
                    if (Region == users[i].city || Region == users[i].state)
                    {
                        Console.WriteLine($"Name : {users[i].name}");
                        Console.WriteLine($"Email : {users[i].email}");
                        Console.WriteLine($"City : {users[i].city}");
                        Console.WriteLine($"State : {users[i].state}");
                        Console.WriteLine($"Contact : {users[i].contact}");
                        Console.WriteLine($"Zip : {users[i].zip}");
                    }
                //}
            }

        }
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
                    obj.AddContact();
                }

            else if( choose == 2)
                {
                    obj.ShowDetail();
                }
                /*for (int i = 0; i < users.Count; i++)
                {
                    Console.WriteLine(users[i].name);
                }*/

            else if(choose ==3)
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
                    Console.WriteLine($"\n$There are {obj.ContactCount} Contacts in the Address Book");
                }

                
            } while (choose != 7);



        }
    }


}
