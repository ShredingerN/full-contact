using Microsoft.EntityFrameworkCore;
using Bogus;

public class SqliteEfFakerInitializer : IInitializer
{
    private readonly SqliteDbContext context;
    public SqliteEfFakerInitializer(SqliteDbContext context)
    {
        this.context = context;
    }

    public void Initialize()
    {

        context.Database.Migrate();
        if (!context.Contacts.Any())
        {
            var faker = new Faker<Contact>("ru")
            .RuleFor(c => c.Name, f => f.Name.FullName())
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber("7-###-###-####"));

            var contacts = faker.Generate(200);
            context.Contacts.AddRange(contacts);
            context.SaveChanges();
        }
    }
        
}