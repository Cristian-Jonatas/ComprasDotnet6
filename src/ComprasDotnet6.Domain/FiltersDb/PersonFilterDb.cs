using ComprasDotnet6.Domain.Pagination;

namespace ComprasDotnet6.Domain.FiltersDb
{
    public class PersonFilterDb : PagedBaseRequest
    {
        public string? Nome { get; set; }
    }
}
