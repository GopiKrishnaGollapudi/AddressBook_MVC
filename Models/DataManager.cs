using System;
using System.Data.SqlClient;
using Dapper;
using AddressBook.Models;

public class DataManager : IDataManager
{
    SqlConnection connection = new SqlConnection("Server=sqldev;Database=AddressBook;User ID=intern2023;Password=oRAGuENctuRE");

    public void AddContact(Contact contact)
    {
        string addContact = "INSERT INTO Contacts (Name,Email,Mobile,Landline,Website,Address) VALUES (@Name,@Email,@Mobile,@Landline,@Website,@Address)";
        connection.Query(addContact, contact);
    }

    public Contact GetContact(int contactId)
    {
        string getcontactQuery = "SELECT * FROM Contacts WHERE ContactId= " + contactId;
        Contact contact = connection.QueryFirstOrDefault<Contact>(getcontactQuery);
        return contact;
    }

    public List<Contact> GetContacts()
    {
        string getcontactsQuery = "SELECT * FROM Contacts";
        List<Contact> contacts = connection.Query<Contact>(getcontactsQuery).ToList();
        return contacts;
    }

    public void DeleteContact(int contactId)
    {
        string deleteContactQuery = "DELETE FROM Contacts WHERE ContactId=" + contactId;
        connection.Execute(deleteContactQuery);
    }

    public void EditContact(Contact contact)
    {
        string updateContact = "UPDATE Contacts SET Name = @Name, Email = @Email, Mobile = @Mobile WHERE ContactId = @ContactId";
        connection.Execute(updateContact, contact);
    }
}