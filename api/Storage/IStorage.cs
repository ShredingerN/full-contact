public interface IStorage
{
    List<Contact> GetContacts();
    Contact Add(Contact contact);
    bool UpdateContact(ContactDto contactDto, int id);
    bool Remove(int id);
    Contact GetContactById(int id);
}
