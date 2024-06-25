using Dweb_Projeto.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dweb_Projeto.Data
{
    /// <summary>
    /// classe responsável pela criação e gestão da Base de Dados
    /// </summary>
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /* ********************************
        * definir as 'tabelas' da base de dados
        * ********************************* */

        /// <summary>
        /// tabela Utilizadores
        /// </summary>
        public DbSet<Utilizador> Utilizador { get; set;}
        /// <summary>
        /// tabela Publicações
        /// </summary>
        public DbSet<Publicacao> Publicacao { get; set;}
        /// <summary>
        /// tabela Categorias
        /// </summary>
        public DbSet<Categoria> Categorias { get; set;}
        /// <summary>
        /// tabela Comentários
        /// </summary>
        public DbSet<Comentarios> Comentarios { get; set;}
        /// <summary>
        /// tabela Likes
        /// </summary>
        public DbSet<Likes> Likes { get; set;}

    }
}
