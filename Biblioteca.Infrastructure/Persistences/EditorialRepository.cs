using Biblioteca.Domain.Models;
using Biblioteca.Domain.Repositories;
using Biblioteca.Infrastructure.Cores.Contexts;
using Biblioteca.Infrastructure.Cores.Persistences;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Persistences;

public class EditorialRepository : CrudRepository<Editorial, int>, IEditorialRepository
{
    public EditorialRepository(InfrastructureDbContext context) : base(context)
    {
    }
}