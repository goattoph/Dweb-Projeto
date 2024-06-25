using System.ComponentModel.DataAnnotations;

namespace Dweb_Projeto.Models{
    public class Categoria{

        /// <summary>
        /// classe para descrever as categorias existentes
        /// </summary>
        public Categoria(){
            ListaPublicacoes = new HashSet<Publicacao>();
        }

        /// <summary>
        /// Chave primária PK
        /// </summary>
        [Key] // PK
        public int CategoriaId { get; set; }

        /// <summary>
        /// Nome da categoria
        /// </summary>
        [Required(ErrorMessage = "O nome da categoria é obrigatório")]
        [StringLength(50, ErrorMessage = "O nome da categoria não pode ter mais de 50 caracteres")]
        [Display(Name = "Nome da Categoria")]
        public string Nome { get; set; }

        /* ****************************************
         * Construção dos Relacionamentos
         * *************************************** */

        // relacionamento N-M, SEM atributos no relacionamento

        // Lista das Publicações que uma Categoria tem

        /// <summary>
        /// Lista das Publicações associadas a uma Categoria
        /// </summary>
        public ICollection<Publicacao> ListaPublicacoes { get; set; }
    }
}
