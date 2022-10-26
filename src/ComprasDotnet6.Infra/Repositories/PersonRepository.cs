using ComprasDotnet6.Domain.Entities;
using ComprasDotnet6.Domain.FiltersDb;
using ComprasDotnet6.Domain.Interfaces;
using ComprasDotnet6.Domain.Pagination;
using ComprasDotnet6.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace ComprasDotnet6.Infra.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly ApplicationDbContext _context;
        public PersonRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Person> CreateAsync(Person person)
        {
            _context.Add(person);
            _context.SaveChanges();
            return person;
        }

        public async Task DeleteAsync(Person person)
        {
            _context.Remove(person);
            await _context.SaveChangesAsync();
        }

        public async Task EditAsync(Person person)
        {
           _context.Update(person);
           await _context.SaveChangesAsync();

        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _context.People.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<ICollection<Person>> GetPeopleAsync()
        {
            return await _context.People.ToListAsync();
        }

        public async Task<int> GetIdByDocumentAsync(string document)
        {
            return (await _context.People.FirstOrDefaultAsync(p => p.Document == document))?.Id ?? 0;
        }

        public async Task<PagedBaseResponse<Person>> GetPagedAsync(PersonFilterDb personFilterDb)
        {
            var people = _context.People.AsQueryable();
            if(!string.IsNullOrEmpty(personFilterDb.Nome))
                people = people.Where(x => x.Name.ToLower().Contains(personFilterDb.Nome.ToLower()));

            return await PagedBaseResponseHelper.GetResponseAsync<PagedBaseResponse<Person>, Person>(people, personFilterDb);
        }
    }
}
