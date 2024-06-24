using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dweb_Projeto.Models{
    public class Publicacao{

        public Publicacao() {
            ListaCategorias = new HashSet<Categoria>();
            ListaComentarios = new HashSet<Comentarios>();
            ListaLikes = new HashSet<Likes>();
        }

        [Key] //PK
        public int PostId { get; set; }

        public string Titulo { get; set; }

        public string Descricao { get; set; }

        public string Foto { get; set; }

        // relacionamento 1-N

        // esta anotação informa a EF
        // que o atributo 'UtilizadorFK' é uma FK em conjunto
        // com o atributo 'Utilizador'
        [ForeignKey(nameof(Utilizador))]
        public int UtilizadorFK { get; set; } // FK para o Utilizador
        public Utilizador Utilizador { get; set; } // FK para o Utilizador

        //Lista dos Comentarios que uma Publicação tem
        public ICollection<Comentarios> ListaComentarios { get; set; }

        //Lista dos Likes que uma Publicação tem
        public ICollection<Likes> ListaLikes { get; set; }

        // relacionamento M-N, SEM atributos no relacionamento
        public ICollection<Categoria> ListaCategorias { get; set; }
    }
}
