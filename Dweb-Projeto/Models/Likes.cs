using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dweb_Projeto.Models{
    /// <summary>
    /// classe para descrever os likes existentes
    /// </summary>
    public class Likes{

        /// <summary>
        /// chave primária PK
        /// </summary>
        [Key] // PK
        public int LikeID { get; set; }

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
        /// Utilizador associado ao like
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
        /// Publicação associada ao like
        /// </summary>
        public Publicacao Publicacao { get; set; } // FK para a Publicação
    }
}
