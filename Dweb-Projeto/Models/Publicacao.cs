using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dweb_Projeto.Models{
    public class Publicacao{

        public Publicacao() {
            ListaUtilizadores = new HashSet<Utilizador>();
            ListaComentarios = new HashSet<Comentarios>();
            ListaLikes = new HashSet<Likes>();
        }

        [Key] //PK
        public int postId { get; set; }

        public string titulo { get; set; }

        public string descricao { get; set; }

        public string foto { get; set; }

        // relacionamento 1-N

        // esta anotação informa a EF
        // que o atributo 'CategoriaFK' é uma FK em conjunto
        // com o atributo 'Categoria'
        [ForeignKey(nameof(Categoria))]
        public int CategoriaFK { get; set; } // FK para a Categoria
        public Categoria Categoria { get; set; } // FK para a Categoria

        //Lista dos Comentarios que uma Publicação tem
        public ICollection<Comentarios> ListaComentarios { get; set; }

        //Lista dos Likes que uma Publicação tem
        public ICollection<Likes> ListaLikes { get; set; }

        // relacionamento M-N, SEM atributos no relacionamento
        public ICollection<Utilizador> ListaUtilizadores { get; set; }
    }
}
