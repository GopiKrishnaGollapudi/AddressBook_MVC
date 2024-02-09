using AddressBook.Models;
public interface IAddressManager
{
    void AddContact(Contact contact);
    List<Contact> GetContacts();
    Contact GetContact(int contactId);
    void DeleteContact(int ContactId);
    void EditContact(Contact contact);
}