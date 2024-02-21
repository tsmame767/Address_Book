using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace addressbook
{
    public class booktest
    {
        public int id;
        //"Data Source=LAPTOP-SD20JSPU;Initial Catalog=ado_db;Integrated Security=True;";

        public string constr = "Data Source = LAPTOP-SD20JSPU;Initial Catalog= Address_Book;Integrated Security= True";

        /*
        static Dictionary<int,string> Namedict = new Dictionary<int,string>();
        static Dictionary<int,string> Emaildict = new Dictionary<int,string>();
        static Dictionary<int,string> Citydict = new Dictionary<int,string>();
        static Dictionary<int,string> Statedict = new Dictionary<int,string>();
        static Dictionary<int,long> Contactdict = new Dictionary<int,long>();
        static Dictionary<int,int> Zipdict = new Dictionary<int,int>();
        */

        //public int ContactCount = 0;

        public List<User> users = new List<User>(); //global list


        public int getcurrid()
        {
            id = 0;
            SqlConnection conn = null;
            using(conn= new SqlConnection(constr))
            {
                string query = "select * from contacts";
                SqlCommand cmd=new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader dr= cmd.ExecuteReader();
                

                while (dr.Read())
                {
                    id = (int)dr["id"];
                }
                if (id == 0)
                {
                    return 1;
                }
                else
                {
                    return id + 1;
                }
            }
            

            return id;
        }
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

        public long checknuminp()
        {
            
            long newdata=0;
            int flag = 1;
            while (true)
            {
                Console.WriteLine("Enter Contact: ");
                long contact = Convert.ToInt64(Console.ReadLine());

                bool invalid = Regex.IsMatch(Convert.ToString(contact), "^[6-9][0-9]{9}$");
                if (invalid)
                {
                    newdata = contact;
                    flag = 1;
                    break;
                }
                else if (invalid == false)
                {
                    
                    flag = 0;
                    //newdata = contact;
                }
            }
            if(flag == 1)
            {
                return newdata;
            }
            return 0;
        }
        public string AddContact() //method for creating a new contact
        {
            string name="";
            string email="";
            string city="";
            string state="";
            long contact=0;
            int zip=0;

            bool invalid = true;



            // Data Collecting 

            int i = 1;
            while (i <= 6)
            {
                switch (i)
                {
                    case 1:
                        if (invalid)
                        {
                            Console.WriteLine("enter name: ");
                            name = Console.ReadLine();
                            invalid = !Regex.IsMatch(name, "^[A-Za-z]{2,}$");
                        }
                        else
                        {
                            invalid = true;
                            i++;
                            //break;

                        }
                        break;
                    case 2:
                        if (invalid)
                        {
                            Console.WriteLine("Enter Email: ");
                            email = Console.ReadLine();
                            invalid = !Regex.IsMatch(email, "^[A-Za-z0-9]{2,}[@][a-z]{2,}[.][.a-z]{2,}$");
                        }
                        else
                        {
                            invalid = true;
                            i++;
                            //break;
                        }
                        break;

                    case 3:
                        if (invalid)
                        {
                            Console.WriteLine("Enter City: ");
                            city = Console.ReadLine();
                            invalid = !Regex.IsMatch(city, "^[A-Za-z]{2,}$");
                        }
                        else
                        {
                            invalid = true;
                            i++;
                            //break;
                        }
                        break;

                    case 4:
                        if (invalid)
                        {
                            Console.WriteLine("Enter State: ");
                            state = Console.ReadLine();
                            invalid = !Regex.IsMatch(state, "^[A-Za-z]{2,}$");
                        }
                        else
                        {
                            invalid = true;
                            i++;
                            //break;
                        }
                        break;

                    case 5:
                        if (invalid)
                        {
                            Console.WriteLine("Enter Zip: ");
                            zip = Convert.ToInt32(Console.ReadLine());
                            invalid = !Regex.IsMatch(Convert.ToString(zip), "^[0-9]{6}$");
                        }
                        else
                        {
                            invalid = true;
                            i++;
                            //break;
                        }
                        break;

                    case 6:
                        //Console.WriteLine("enter contact: ");
                        contact = checknuminp();

                        while (true)
                        {
                            if (contact !=0 && checkcont(contact))
                            {
                                Console.WriteLine("enter data again: ");
                                contact = checknuminp();
                            }
                            else if(checkcont(contact)==false)
                            {
                                break;
                                
                            }

                        }
                        i++;
                        break;


                        
                        
                       /* else
                        {
                            invalid = true;
                            i++;
                            //break;
                        */
                        

                    case 7:
                        Console.WriteLine("passed switch");
                        break;
                }
            }

            SqlConnection connect = null;
            try
            {
                using (connect = new SqlConnection(constr))
                {
                    
                    string query = $"insert into contacts values({getcurrid()},'{name}','{email}','{city}','{state}',{zip},{contact})";
                    Console.WriteLine(getcurrid());
                    connect.Open();
                    SqlCommand cmd = new SqlCommand(query, connect);
                    int res = cmd.ExecuteNonQuery();

                    if (res > 0)
                    {
                        return $"{res} rows inserted";
                    }
                    //if (connect.State == ConnectionState.Open)
                    //{
                    //    return "open ";
                    //}
                    //else
                    //{
                    //    return "close";
                    //}

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine (ex.Message);
            }
            finally
            {
                connect.Close();
            }

            return "not inserted";

            /*
            Namedict.Add(contact, name);
            Emaildict.Add(contact, email);
            Citydict.Add(contact, city);
            Statedict.Add(contact, state);
            Contactdict.Add(contact, contact);
            Zipdict.Add(contact, zip);*/




            //Data Storing
            //User u1 = new User(name,email,city,state,contact,zip);


            //Object Adding to List
            //ListAdd(u1);
            //ContactCount++;

        }


        
        public void ShowDetail() {



            SqlConnection connect = null;

            using (connect = new SqlConnection(constr))
            {
                Console.WriteLine("\n\nchoose 1 : show all contact details :\nchoose 2 :  show detail of one contact  :");
                int choose = Convert.ToInt32(Console.ReadLine());

                if (choose == 2)
                {
                    Console.WriteLine("enter the contact number: ");
                    long con= Convert.ToInt64(Console.ReadLine());
                    string query = $"select * from contacts where contact = {con}";

                    SqlCommand cmd = new SqlCommand(query, connect);
                    connect.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    // while (dr.Read())
                    // {
                    dr.Read();
                    Console.WriteLine($"\n\nId= {dr["id"]}, name= {dr["name"]}, email= {dr["email"]}, city= {dr["city"]}, state= {dr["state"]}, contact= {dr["contact"]}");
                   // }
                }
                else if(choose == 1) 
                {
                    string query = $"select * from contacts ";

                    SqlCommand cmd = new SqlCommand(query, connect);
                    connect.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    int datacount = 0;

                    
                    while (dr.Read())
                    {
                        Console.WriteLine($"\n\nId = {dr["id"]} name = {dr["name"]} email = {dr["email"]} city = {dr["city"]} state = {dr["state"]} zip = {dr["zip"]} contact = {dr["contact"]}");
                        datacount++;
                    }

                    if (datacount == 0)
                    {
                        Console.WriteLine("\n\nNo Data Available\n\n");
                    }



                }
                else
                {
                    Console.WriteLine("\n\ninvalid choice\n\n");
                }
            }
            /*
            Console.WriteLine("Enter the your contact number: ");
            long phone = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("name " + Namedict[phone]);

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
            */
        }

        public string CheckInstr(string inp, string oldstr)
        {
            if (inp == "\n" || inp == "") 
            {
                return oldstr;
            }
            return inp;
        }
        public long CheckInp(string inp, long comp)
        {
            if (inp == "")
            {
                return comp;
            }

            return Convert.ToInt64(inp);
        }
        public void EditDetail()
        {

            string name = "";
            string email = "";
            string city = "";
            string state = "";
            long contact = 0;
            int zip = 0; 

            SqlConnection conn = null;

            Console.WriteLine("Enter the your contact number: ");
            long phone = Convert.ToInt64(Console.ReadLine());

            using (conn = new SqlConnection(constr))  // sql connection string
            {
                string query1 = $"select * from contacts where contact = {phone}";

                SqlCommand cmd1 = new SqlCommand(query1, conn);
                conn.Open();
                SqlDataReader dr =  cmd1.ExecuteReader();

                dr.Read();
                User userobj = new User((string)dr["name"], (string)dr["email"], (string)dr["city"], (string)dr["state"], (long)dr["contact"], (int)dr["zip"]);


                Console.WriteLine($"\n\nPrevious name {userobj.name}");
                Console.WriteLine($"Previous email {userobj.email}");
                Console.WriteLine($"Previous city {userobj.city}");
                Console.WriteLine($"Previous state {userobj.state}");
                Console.WriteLine($"Previous zip {userobj.zip}");
                Console.WriteLine($"Previous contact {userobj.contact} \n\n");

                Console.WriteLine("Edit Name: ");
                userobj.name = CheckInstr(Console.ReadLine(), userobj.name);

                Console.WriteLine("Edit Email: ");
                userobj.email = CheckInstr(Console.ReadLine(), userobj.email);

                Console.WriteLine("Edit City: ");
                userobj.city = CheckInstr(Console.ReadLine(), userobj.city);
                Console.WriteLine(userobj.city);

                Console.WriteLine("Edit State: ");
                userobj.state = CheckInstr(Console.ReadLine(), userobj.state);
                Console.WriteLine(userobj.state);

                Console.WriteLine("Edit Zip: ");
                userobj.zip = CheckInp(Console.ReadLine(), userobj.zip);

                Console.WriteLine("Edit Contact: ");
                userobj.contact = CheckInp(Console.ReadLine(), userobj.contact);

                Console.WriteLine($"\n\nupdated name {userobj.name}");
                Console.WriteLine($"updated email {userobj.email}");
                Console.WriteLine($"updated city {userobj.city}");
                Console.WriteLine($"updated state {userobj.state}");
                Console.WriteLine($"updated zip {userobj.zip}");
                Console.WriteLine($"updated contact {userobj.contact}");
                
                conn.Close();
                String query2 = $"update contacts set name = '{userobj.name}', email = '{userobj.email}',  city = '{userobj.city}', state = '{userobj.state}', zip = {userobj.zip}, contact={userobj.contact} where contact = {phone}";
                SqlCommand cmd2 = new SqlCommand(query2, conn);
                conn.Open();
                int res = cmd2.ExecuteNonQuery();
                if (res > 0)
                {
                    Console.WriteLine("updated data");
                }
            }

            

            
            /*
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
            }*/
        }

        public void DeleteCont()
        {
            SqlConnection conn = null;



            using (conn = new SqlConnection(constr))
            {
                Console.WriteLine("choose 1 to delete all rows :\nchoose 2 to delete one row : ");
                int choose = Convert.ToInt32(Console.ReadLine());
                conn.Open();

                SqlCommand cmd1=null;
                int res = 0;
                if (choose == 1)
                {
                    string query1 = "Delete from contacts";
                    cmd1 = new SqlCommand(query1, conn);
                    
                    res = cmd1.ExecuteNonQuery();

                    if (res > 0)
                    {
                        Console.WriteLine($"Deleted {res} rows");
                    }
                    else
                    {
                        Console.WriteLine($"Not Data to Delete");
                    }

                }

                else if (choose == 2)
                {
                    Console.WriteLine("Enter the your contact number: ");
                    long phone = Convert.ToInt64(Console.ReadLine());

                    string query2 = $"Delete from contacts where contact = {phone}";
                    cmd1 = new SqlCommand();
                    cmd1.CommandText = query2;
                    cmd1.Connection = conn;
                    res = cmd1.ExecuteNonQuery();

                    if (res > 0)
                    {
                        Console.WriteLine("Deleted Row");
                    }
                    else
                    {
                        Console.WriteLine("Not Data to Delete");
                    }

                }

            }
                //for (int i = 0; i < users.Count; i++)
                //{

                //    if (phone == users[i].contact)
                //    {
                //        users.RemoveAt(i);
                //    }
                //}
                //ContactCount--;
        }

        public void ViewPreferredCont()
        {

            SqlConnection conn = null;
            //Console.WriteLine("Enter the your contact number: ");
            //int phone = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter city or state: ");
            string Region = Console.ReadLine();

            using (conn = new SqlConnection(constr))
            {
                string query = $"select * from contacts where city = '{Region}' or state = '{Region}'";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                while(dr.Read())
                {
                    Console.WriteLine($"Id= {dr["id"]}, name= {dr["name"]}, email= {dr["email"]}, city= {dr["city"]}, state= {dr["state"]} contact= {dr["contact"]}\n\n");
                }
            }




            //for (int i = 0; i < users.Count(); i++)
            //{
            //    //if (users[i].contact == phone)
            //    //{
                    
            //        if (Region == users[i].city || Region == users[i].state)
            //        {
            //            Console.WriteLine($"Name : {users[i].name}");
            //            Console.WriteLine($"Email : {users[i].email}");
            //            Console.WriteLine($"City : {users[i].city}");
            //            Console.WriteLine($"State : {users[i].state}");
            //            Console.WriteLine($"Contact : {users[i].contact}");
            //            Console.WriteLine($"Zip : {users[i].zip}");
            //        }
            //    //}
            //}

        }

        public int ContactCount()
        {
            SqlConnection conn = null;
            using (conn = new SqlConnection(constr))
            {
                string query = $"select count(*) from contacts";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                int res = (int)cmd.ExecuteScalar();

                return res;
            }
        }



    }

    


}
