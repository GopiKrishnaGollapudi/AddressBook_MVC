using AddressBook.Models;
public interface IDataManager
{
    void AddContact(Contact contact);
    Contact GetContact(int contactId);
    List<Contact> GetContacts();
    void DeleteContact(int contactId);

    void EditContact(Contact contact);
}