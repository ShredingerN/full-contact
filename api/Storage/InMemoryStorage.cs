using Bogus;

//хранение данных в памяти, в списке без базы данных
public class InMemoryStorage : IStorage
{
    private List<Contact> Contacts { get; set; }
    public InMemoryStorage()
    {
        this.Contacts = new List<Contact>();
        var faker = new Faker("ru");

        for (int i = 1; i <= 10; i++)
        {
            Contacts.Add(new Contact()
            {
                Id = i,
                Name = faker.Name.FullName(),
                Email = faker.Internet.Email(),
                Phone = faker.Phone.PhoneNumber("7-###-###-####")
            });

        }
    }

    public Contact Add(Contact contact)
    {
        if (Contacts.Any(
            item => item.Id == contact.Id))
        {
            return null;
        }
        Contacts.Add(contact);
        return contact;
    }
    public List<Contact> GetContacts()
    {
        return Contacts;
    }
    public bool Remove(int id)
    {
        Contact contact;
        for (int i = 0; i < Contacts.Count; i++)
        {
            if (Contacts[i].Id == id)
            {
                contact = Contacts[i];
                Contacts.Remove(contact);
                return true;
            }
        }
        return false;
    }
    public bool UpdateContact(ContactDto contactDto, int id)
    {
        Contact contact;
        for (int i = 0; i < this.Contacts.Count; i++)
        {
            if (Contacts[i].Id == id)
            {
                contact = Contacts[i];
                if (!String.IsNullOrEmpty(contactDto.Email))
                {
                    contact.Email = contactDto.Email;
                }

                if (!String.IsNullOrEmpty(contactDto.Name))
                {
                    contact.Name = contactDto.Name;
                }

                if (!String.IsNullOrEmpty(contactDto.Phone))
                {
                    contact.Phone = contactDto.Phone;
                }

                return true;
            }
        }
        return false;
    }

    public Contact GetContactById(int id)
    {
        return Contacts.FirstOrDefault(
            item => item.Id == id);
    }


}