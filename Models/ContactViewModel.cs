using System;

namespace AddressBook.Models
{
    public class ContactViewModel
    {
        public Contact NewContact { get; set; }
        public Contact EditContact { get; set; }
        public List<Contact> Contacts { get; set; }
    }
}