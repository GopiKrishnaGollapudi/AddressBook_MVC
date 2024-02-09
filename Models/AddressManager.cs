using System;
using System.Collections.Generic;
using AddressBook.Models;
using Microsoft.EntityFrameworkCore;

public class AddressManager : IAddressManager
{
    IDataManager dataManager = new DataManager();

    public void AddContact(Contact contact)
    {
        dataManager.AddContact(contact: contact);
    }

    public List<Contact> GetContacts()
    {
        List<Contact> contacts = dataManager.GetContacts();
        return contacts;
    }

    public Contact GetContact(int contactId)
    {
        Contact contact = dataManager.GetContact(contactId);
        return contact;
    }

    public void DeleteContact(int contactId)
    {
        dataManager.DeleteContact(contactId: contactId );
    }

    public void EditContact(Contact contact)
    {
        dataManager.EditContact(contact: contact);
    }
}