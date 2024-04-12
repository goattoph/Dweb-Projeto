using System.ComponentModel.DataAnnotations;

namespace Dweb_Projeto.Models{
    public class Categoria{

        public Categoria(){
            ListaPublicacoes = new HashSet<Publicacao>();
        }

        [Key] // PK
        public int categoriaId { get; set; }

        public string nome { get; set; }

        /* ****************************************
         * Construção dos Relacionamentos
         * *************************************** */

        // relacionamento 1-N

        // Lista das Publicações que uma Categoria tem
        public ICollection<Publicacao> ListaPublicacoes { get; set; }
    }
}
