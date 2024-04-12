using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dweb_Projeto.Data.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorias",
                columns: table => new
                {
                    categoriaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorias", x => x.categoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Utilizador",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foto = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizador", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "Publicacao",
                columns: table => new
                {
                    postId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    foto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoriaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publicacao", x => x.postId);
                    table.ForeignKey(
                        name: "FK_Publicacao_Categorias_CategoriaFK",
                        column: x => x.CategoriaFK,
                        principalTable: "Categorias",
                        principalColumn: "categoriaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    commentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    texto = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UtilizadorFK = table.Column<int>(type: "int", nullable: false),
                    PublicacaoFK = table.Column<int>(type: "int", nullable: false),
                    PublicacaopostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.commentId);
                    table.ForeignKey(
                        name: "FK_Comentarios_Publicacao_PublicacaopostId",
                        column: x => x.PublicacaopostId,
                        principalTable: "Publicacao",
                        principalColumn: "postId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comentarios_Utilizador_UtilizadorFK",
                        column: x => x.UtilizadorFK,
                        principalTable: "Utilizador",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    likeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilizadorFK = table.Column<int>(type: "int", nullable: false),
                    PublicacaoFK = table.Column<int>(type: "int", nullable: false),
                    PublicacaopostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.likeID);
                    table.ForeignKey(
                        name: "FK_Likes_Publicacao_PublicacaopostId",
                        column: x => x.PublicacaopostId,
                        principalTable: "Publicacao",
                        principalColumn: "postId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Likes_Utilizador_UtilizadorFK",
                        column: x => x.UtilizadorFK,
                        principalTable: "Utilizador",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicacaoUtilizador",
                columns: table => new
                {
                    ListaPublicacoespostId = table.Column<int>(type: "int", nullable: false),
                    ListaUtilizadoresuserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicacaoUtilizador", x => new { x.ListaPublicacoespostId, x.ListaUtilizadoresuserID });
                    table.ForeignKey(
                        name: "FK_PublicacaoUtilizador_Publicacao_ListaPublicacoespostId",
                        column: x => x.ListaPublicacoespostId,
                        principalTable: "Publicacao",
                        principalColumn: "postId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublicacaoUtilizador_Utilizador_ListaUtilizadoresuserID",
                        column: x => x.ListaUtilizadoresuserID,
                        principalTable: "Utilizador",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_PublicacaopostId",
                table: "Comentarios",
                column: "PublicacaopostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UtilizadorFK",
                table: "Comentarios",
                column: "UtilizadorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PublicacaopostId",
                table: "Likes",
                column: "PublicacaopostId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_UtilizadorFK",
                table: "Likes",
                column: "UtilizadorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Publicacao_CategoriaFK",
                table: "Publicacao",
                column: "CategoriaFK");

            migrationBuilder.CreateIndex(
                name: "IX_PublicacaoUtilizador_ListaUtilizadoresuserID",
                table: "PublicacaoUtilizador",
                column: "ListaUtilizadoresuserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "PublicacaoUtilizador");

            migrationBuilder.DropTable(
                name: "Publicacao");

            migrationBuilder.DropTable(
                name: "Utilizador");

            migrationBuilder.DropTable(
                name: "Categorias");
        }
    }
}
