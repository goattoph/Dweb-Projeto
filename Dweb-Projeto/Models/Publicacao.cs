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

        [Display(Name = "Título")]
        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório!")]
        [StringLength(50, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Titulo { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(200, ErrorMessage = "A {0} não pode ter mais de {1} caracteres.")]
        public string Descricao { get; set; }

        [Display(Name = "Foto")]
        [StringLength(50)]
        public string? Foto { get; set; }

        [Display(Name = "Data da Publicação")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataPublicacao { get; set; }

        // relacionamento 1-N

        // esta anotação informa a EF
        // que o atributo 'UtilizadorFK' é uma FK em conjunto
        // com o atributo 'Utilizador'
        [ForeignKey(nameof(Utilizador))]
        public int? UtilizadorFK { get; set; } // FK para o Utilizador
        /// <summary>
        /// Utilizador associado à publicação
        /// </summary>
        public Utilizador? Utilizador { get; set; } // FK para o Utilizador

        //Lista dos Comentarios que uma Publicação tem
        public ICollection<Comentarios> ListaComentarios { get; set; }

        //Lista dos Likes que uma Publicação tem
        public ICollection<Likes> ListaLikes { get; set; }

        // relacionamento M-N, SEM atributos no relacionamento
        public ICollection<Categoria> ListaCategorias { get; set; }
    }
}
