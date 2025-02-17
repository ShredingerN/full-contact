public class SqliteEfPaginationStorage : SqliteEfStorage, IPaginationStorage
{
    public SqliteEfPaginationStorage(SqliteDbContext context)
    : base(context)
    {
    }

    public (List<Contact>, int TotalCount) GetContacts(int pageNumber, int pageSize)
    {
        int total = context.Contacts.Count();
        List<Contact> contacts = context.Contacts
        .Skip((pageNumber - 1) * pageSize)
        .Take(pageSize)
        .ToList();
        return (contacts, total);
    }

}