using Microsoft.EntityFrameworkCore;
using Cadastro_Usuario.Models;

namespace Cadastro_Usuario.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> opcoes) : base(opcoes)
        {

        }

        public DbSet<Dbusuario> usuario { get; set; }

    }
}
