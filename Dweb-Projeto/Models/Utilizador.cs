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

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
        [StringLength(50, ErrorMessage = "O {0} não pode ter mais de {1} caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "Foto")]
        [StringLength(50)]
        public string? Foto { get; set;}

        [Display(Name = "Data Nascimento")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório!")]
        public DateOnly DataNascimento { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(19)]
        [RegularExpression("([+]|00)?[0-9]{6,17}", ErrorMessage = "o {0} só pode conter digitos. No mínimo 6.")]
        [Required(ErrorMessage = "O {0} é de preenchimento obrigatório!")]
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
