using ComprasDotnet6.Domain.Entities;
using ComprasDotnet6.Domain.FiltersDb;
using ComprasDotnet6.Domain.Pagination;

namespace ComprasDotnet6.Domain.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> GetByIdAsync(int id);
        Task<ICollection<Person>> GetPeopleAsync();
        Task<Person> CreateAsync(Person person);
        Task EditAsync(Person person);
        Task DeleteAsync(Person person);
        Task<int> GetIdByDocumentAsync(string document);
        Task<PagedBaseResponse<Person>> GetPagedAsync(PersonFilterDb personFilterDb);
    }
}
