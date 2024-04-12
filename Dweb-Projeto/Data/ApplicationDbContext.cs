using Dweb_Projeto.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dweb_Projeto.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /* ********************************
        * definir as 'tabelas' da base de dados
        * ********************************* */

        public DbSet<Utilizador> Utilizador { get; set;}

        public DbSet<Publicacao> Publicacao { get; set;}

        public DbSet<Categoria> Categorias { get; set;}

        public DbSet<Comentarios> Comentarios { get; set;}

        public DbSet<Likes> Likes { get; set;}

    }
}
