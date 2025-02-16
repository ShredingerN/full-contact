using Microsoft.Data.Sqlite;

//подключаем базку к приложению
public class SqliteStorage : IStorage
{
    private string connectionString;

    public SqliteStorage(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public List<Contact> GetContacts()
    {
        var contacts = new List<Contact>();
        //using используется для автоматического освобождения закрытия сеанса базы данных
        using var connection = new SqliteConnection(connectionString);
        connection.Open();
        //объект будет выполнять Sql запросы к бд
        var command = connection.CreateCommand();
        //будет получать таблицу
        command.CommandText = @"SELECT * FROM contacts";
        //читаем полученное из запроса
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            contacts.Add(new Contact()
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Email = reader.GetString(2),
                Phone = reader.GetString(3)
            });
        }

        return contacts;
    }

    public Contact Add(Contact contact)
    {

        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        string sql = @"INSERT INTO contacts (name, email, phone) VALUES(@name, @email, @phone);
        SELECT last_insert_rowid();";
        command.CommandText = sql;
        command.Parameters.AddWithValue("@name", contact.Name);
        command.Parameters.AddWithValue("@email", contact.Email);
        command.Parameters.AddWithValue("@phone", contact.Phone);

        contact.Id = Convert.ToInt32(command.ExecuteScalar());

        return contact;
    }
    public bool UpdateContact(ContactDto contactDto, int id)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();
        var command = connection.CreateCommand();
        string sql = @"UPDATE contacts SET name=@name, email=@email, phone=@phone WHERE id=@id";
        command.CommandText = sql;
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@name", contactDto.Name);
        command.Parameters.AddWithValue("@email", contactDto.Email);
        command.Parameters.AddWithValue("@phone", contactDto.Phone);

        return command.ExecuteNonQuery() > 0;
    }
    public bool Remove(int id)
    {

        using var connection = new SqliteConnection(connectionString);
        connection.Open();
        var command = connection.CreateCommand();
        string sql = @"DELETE FROM contacts WHERE id=@id;";
        command.CommandText = sql;
        command.Parameters.AddWithValue("@id", id);


        return command.ExecuteNonQuery() > 0;
    }

    public Contact GetContactById(int id)
    {
        using var connection = new SqliteConnection(connectionString);
        connection.Open();
        var command = connection.CreateCommand();
        string sql = @"SELECT * FROM contacts WHERE id=@id";
        command.CommandText = sql;
        command.Parameters.AddWithValue("@id", id);

        using var reader = command.ExecuteReader();

        if (reader.Read())
        {
            return new Contact
            {
                Id = reader.GetInt32(0),
                Name = reader.GetString(1),
                Email = reader.GetString(2),
                Phone = reader.GetString(3)
            };
        }

        return null;
    }
}
