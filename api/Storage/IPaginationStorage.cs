public interface IPaginationStorage:IStorage
{
    (List<Contact>, int TotalCount) GetContacts(int pageNumber, int pageSize);
}