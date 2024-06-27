using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dweb_Projeto.Models{
    /// <summary>
    /// classe para descrever os comentários existentes
    /// </summary>
    public class Comentarios{

        /// <summary>
        /// chave primária PK
        /// </summary>
        [Key] // PK
        public int CommentId { get; set; }
        /// <summary>
        /// texto do comentário
        /// </summary>
        [Required(ErrorMessage = "O texto do comentário é obrigatório")]
        [StringLength(500, ErrorMessage = "O texto do comentário não pode ter mais de 500 caracteres")]
        [Display(Name = "Texto do Comentário")]
        public string Texto { get; set; }

        /* ****************************************
         * Construção dos Relacionamentos
         * *************************************** */

        // relacionamento 1-N

        
        // esta anotação informa a EF
        // que o atributo 'UtilizadorFK' é uma FK em conjunto
        // com o atributo 'Utilizador'

        /// <summary>
        /// Chave estrangeira FK para o Utilizador
        /// </summary>
        [ForeignKey(nameof(Utilizador))]
        public int UtilizadorFK { get; set; } // FK para o Utilizador
        /// <summary>
        /// Utilizador associado ao comentário
        /// </summary>
        public Utilizador Utilizador { get; set; } // FK para o Utilizador


        // esta anotação informa a EF
        // que o atributo 'PublicacaoFK' é uma FK em conjunto
        // com o atributo 'Publicacao'

        /// <summary>
        /// Chave estrangeira FK para a Publicação
        /// </summary>
        [ForeignKey(nameof(Publicacao))]        
        public int PublicacaoFK { get; set; } // FK para a Publicação
        /// <summary>
        /// Publicação associada ao comentário
        /// </summary>
        public Publicacao Publicacao { get; set; } // FK para a Publicação


    }
}
