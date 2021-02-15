using System.Data.Entity;
using Web.Models;

namespace Web.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Projeto_Livro_AspNet") { }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
    }
}