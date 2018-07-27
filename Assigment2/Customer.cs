using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment2
{
    class Customer
    {
        private string icPassport;
        private string name;
        private string address;
        private int contactNumber;
        private string email;

        public Customer(string IcPassport, string Name, string Address, int ContactNumber, string Email)
        {
            icPassport = IcPassport;
            name = Name;
            address = Address;
            contactNumber = ContactNumber;
            email = Email;
        }

        public string GetIcPassport
        {
            get { return icPassport; }
            set { icPassport = value; }
        } 

        public string GetName
        {
            get { return name; }
            set { name = value; }
        }

        public string GetAddress
        {
            get { return address; }
            set { address = value; }
        }

        public int GetContactNumber
        {
            get { return contactNumber; }
            set { contactNumber = value; }
        }

        public string GetEmail
        {
            get { return email; }
            set { email = value; }
        }
    }
}
