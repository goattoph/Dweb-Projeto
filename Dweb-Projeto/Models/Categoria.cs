using System.ComponentModel.DataAnnotations;

namespace Dweb_Projeto.Models{
    public class Categoria{

        public Categoria(){
            ListaPublicacoes = new HashSet<Publicacao>();
        }

        [Key] // PK
        public int CategoriaId { get; set; }

        public string Nome { get; set; }

        /* ****************************************
         * Construção dos Relacionamentos
         * *************************************** */

        // relacionamento N-M, SEM atributos no relacionamento

        // Lista das Publicações que uma Categoria tem
        public ICollection<Publicacao> ListaPublicacoes { get; set; }
    }
}
