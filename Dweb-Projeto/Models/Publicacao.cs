using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dweb_Projeto.Models{
    /// <summary>
    /// classe para descrever as publicações existentes
    /// </summary>
    public class Publicacao{
        public Publicacao() {
            ListaCategorias = new HashSet<Categoria>();
            ListaComentarios = new HashSet<Comentarios>();
            ListaLikes = new HashSet<Likes>();
        }

        /// <summary>
        /// chave primária PK
        /// </summary>
        [Key] //PK
        public int PostId { get; set; }

        /// <summary>
        /// Titulo da publicação
        /// </summary>
        [Display(Name = "Título")]
        [Required(ErrorMessage ="O {0} é de preenchimento obrigatório!")]
        [StringLength(50, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Titulo { get; set; }

        /// <summary>
        /// Descrição da publicação
        /// </summary>
        [Display(Name = "Descrição")]
        [StringLength(200, ErrorMessage = "A {0} não pode ter mais de {1} caracteres.")]
        public string Descricao { get; set; }

        /// <summary>
        /// nome do ficheiro que contém o a foto da publicação
        /// </summary>
        [Display(Name = "Foto")]
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        [StringLength(50)]
        public string Foto { get; set; }

        /// <summary>
        /// data da publicação
        /// </summary>
        [Display(Name = "Data da Publicação")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataPublicacao { get; set; }

        // relacionamento 1-N

        // esta anotação informa a EF
        // que o atributo 'UtilizadorFK' é uma FK em conjunto
        // com o atributo 'Utilizador'

        /// <summary>
        /// chave estrangeira FK para o Utilizador
        /// </summary>
        [ForeignKey(nameof(Utilizador))]
        public int UtilizadorFK { get; set; } // FK para o Utilizador
        /// <summary>
        /// Utilizador associado à publicação
        /// </summary>
        public Utilizador Utilizador { get; set; } // FK para o Utilizador

        //Lista dos Comentarios que uma Publicação tem
        /// <summary>
        /// Lista dos Comentários associados a uma Publicação
        /// </summary>
        public ICollection<Comentarios> ListaComentarios { get; set; }

        //Lista dos Likes que uma Publicação tem
        /// <summary>
        /// Lista dos Likes associados a uma Publicação
        /// </summary>
        public ICollection<Likes> ListaLikes { get; set; }

        // relacionamento M-N, SEM atributos no relacionamento
        /// <summary>
        /// Lista das Categorias associadas a uma Publicação
        /// </summary>
        public ICollection<Categoria> ListaCategorias { get; set; }
    }
}
