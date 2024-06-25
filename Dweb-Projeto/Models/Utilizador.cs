using System.ComponentModel.DataAnnotations;

namespace Dweb_Projeto.Models{
    public class Utilizador{

        public Utilizador(){
            ListaComentarios = new HashSet<Comentarios>();
            ListaLikes = new HashSet<Likes>();
            ListaPublicacoes = new HashSet<Publicacao>();
        }

        [Key] // PK
        public int UserID { get; set; }

        public string Nome { get; set; }

        public string Foto { get; set;}

        public DateOnly DataNascimento { get; set; }

        public string Telefone { get; set; }

        /* ****************************************
         * Construção dos Relacionamentos
         * *************************************** */

        // relacionamento 1-N

        // Lista dos Comentarios que um Utilizador tem
        public ICollection<Comentarios> ListaComentarios { get; set;}

        // Lista dos Likes que um Utilizador tem
        public ICollection<Likes> ListaLikes { get; set;}

        // Lista das Publicações que um Utilizador tem
        public ICollection<Publicacao> ListaPublicacoes { get; set;}

    }
}
