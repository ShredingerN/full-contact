public interface IStorage
{
    List<Contact> GetContacts();
    bool Add(Contact contact);
    bool UpdateContact(ContactDto contactDto, int id);
    bool Remove(int id);
    Contact SearchContact(int id);
}
