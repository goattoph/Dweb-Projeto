namespace Dweb_Projeto.Models{
    public class Utilizador{

        public Utilizador(){
            ListaComentarios = new HashSet<Comentarios>();
            ListaLikes = new HashSet<Likes>();
            ListaPublicacoes = new HashSet<Publicacao>();
        }

        public int userID { get; set; }

        public string nome { get; set; }

        public string email { get; set;}

        public string password { get; set;}

        public string foto { get; set;}

        /* ****************************************
         * Construção dos Relacionamentos
         * *************************************** */

        // relacionamento 1-N

        // Lista dos Comentarios que um Utilizador tem
        public ICollection<Comentarios> ListaComentarios { get; set;}

        // Lista dos Comentarios que um Utilizador tem
        public ICollection<Likes> ListaLikes { get; set;}

        // relacionamento M-N, SEM atributos no relacionamento

        public ICollection<Publicacao> ListaPublicacoes { get; set;}

    }
}
