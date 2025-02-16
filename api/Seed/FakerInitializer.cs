using Microsoft.Data.Sqlite;
using Bogus;

public class FakerInitializer : IInitializer
{

    private string connectionString;
    public FakerInitializer(string connectionString)
    {
        this.connectionString = connectionString;
    }
    public void Initialize()
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();
        var command = connection.CreateCommand();


        command.CommandText = @"
        CREATE TABLE IF NOT EXISTS contacts (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            name TEXT NOT NULL,
            email TEXT NOT NULL,
            phone TEXT NOT NULL)";

        command.ExecuteNonQuery();

        command.CommandText = @"SELECT count(*) FROM contacts";
        long count = (long)command.ExecuteScalar();

        if (count == 0)
        {
            var faker = new Faker<Contact>("ru")
            .RuleFor(c => c.Name, f => f.Name.FullName())
            .RuleFor(c => c.Email, f => f.Internet.Email())
            .RuleFor(c => c.Phone, f => f.Phone.PhoneNumber("7-###-###-####"));

            var contacts = faker.Generate(20);

            foreach (var contact in contacts)
            {
                command.CommandText = @"INSERT INTO contacts (Name, Email, Phone) VALUES (@name, @email, @phone)";
                command.Parameters.Clear();
                command.Parameters.AddWithValue("@name", contact.Name);
                command.Parameters.AddWithValue("@email", contact.Email);
                command.Parameters.AddWithValue("@phone", contact.Phone);
                command.ExecuteNonQuery();

            }
            
        }
    }
}
