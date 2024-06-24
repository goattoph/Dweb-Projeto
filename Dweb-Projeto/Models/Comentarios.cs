using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dweb_Projeto.Models{
    public class Comentarios{

        [Key] // PK
        public int CommentId { get; set; }

        public string Texto { get; set; }

        /* ****************************************
         * Construção dos Relacionamentos
         * *************************************** */

        // relacionamento 1-N

        // esta anotação informa a EF
        // que o atributo 'UtilizadorFK' é uma FK em conjunto
        // com o atributo 'Utilizador'
        [ForeignKey(nameof(Utilizador))]
        public int UtilizadorFK { get; set; } // FK para o Utilizador
        public Utilizador Utilizador { get; set; } // FK para o Utilizador

        // esta anotação informa a EF
        // que o atributo 'PublicacaoFK' é uma FK em conjunto
        // com o atributo 'Publicacao'
        public int PublicacaoFK { get; set; } // FK para a Publicação
        public Publicacao Publicacao { get; set; } // FK para a Publicação


    }
}
