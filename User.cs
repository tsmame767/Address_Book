using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace addressbook
{
    public class User
    {
        public string name;
        public string email;
        public string city;
        public string state;
        public long contact;
        public long zip;
        public User(string n, string e, string c, string s, long cot, int z)
        {
            name = n;
            email = e;
            city = c;
            state = s;
            contact = cot;
            zip = z;

        }
    }
}
