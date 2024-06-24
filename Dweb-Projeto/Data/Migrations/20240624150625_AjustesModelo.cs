using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dweb_Projeto.Data.Migrations
{
    /// <inheritdoc />
    public partial class AjustesModelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Publicacao_PublicacaopostId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Publicacao_PublicacaopostId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacao_Categorias_CategoriaFK",
                table: "Publicacao");

            migrationBuilder.DropTable(
                name: "PublicacaoUtilizador");

            migrationBuilder.DropColumn(
                name: "email",
                table: "Utilizador");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Utilizador",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "foto",
                table: "Utilizador",
                newName: "Foto");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "Utilizador",
                newName: "UserID");

            migrationBuilder.RenameColumn(
                name: "password",
                table: "Utilizador",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "titulo",
                table: "Publicacao",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "foto",
                table: "Publicacao",
                newName: "Foto");

            migrationBuilder.RenameColumn(
                name: "descricao",
                table: "Publicacao",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "postId",
                table: "Publicacao",
                newName: "PostId");

            migrationBuilder.RenameColumn(
                name: "CategoriaFK",
                table: "Publicacao",
                newName: "UtilizadorFK");

            migrationBuilder.RenameIndex(
                name: "IX_Publicacao_CategoriaFK",
                table: "Publicacao",
                newName: "IX_Publicacao_UtilizadorFK");

            migrationBuilder.RenameColumn(
                name: "PublicacaopostId",
                table: "Likes",
                newName: "PublicacaoPostId");

            migrationBuilder.RenameColumn(
                name: "likeID",
                table: "Likes",
                newName: "LikeID");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_PublicacaopostId",
                table: "Likes",
                newName: "IX_Likes_PublicacaoPostId");

            migrationBuilder.RenameColumn(
                name: "texto",
                table: "Comentarios",
                newName: "Texto");

            migrationBuilder.RenameColumn(
                name: "PublicacaopostId",
                table: "Comentarios",
                newName: "PublicacaoPostId");

            migrationBuilder.RenameColumn(
                name: "commentId",
                table: "Comentarios",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_PublicacaopostId",
                table: "Comentarios",
                newName: "IX_Comentarios_PublicacaoPostId");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Categorias",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "categoriaId",
                table: "Categorias",
                newName: "CategoriaId");

            migrationBuilder.AddColumn<DateOnly>(
                name: "DataNascimento",
                table: "Utilizador",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateTable(
                name: "CategoriaPublicacao",
                columns: table => new
                {
                    ListaCategoriasCategoriaId = table.Column<int>(type: "int", nullable: false),
                    ListaPublicacoesPostId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaPublicacao", x => new { x.ListaCategoriasCategoriaId, x.ListaPublicacoesPostId });
                    table.ForeignKey(
                        name: "FK_CategoriaPublicacao_Categorias_ListaCategoriasCategoriaId",
                        column: x => x.ListaCategoriasCategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoriaPublicacao_Publicacao_ListaPublicacoesPostId",
                        column: x => x.ListaPublicacoesPostId,
                        principalTable: "Publicacao",
                        principalColumn: "PostId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriaPublicacao_ListaPublicacoesPostId",
                table: "CategoriaPublicacao",
                column: "ListaPublicacoesPostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Publicacao_PublicacaoPostId",
                table: "Comentarios",
                column: "PublicacaoPostId",
                principalTable: "Publicacao",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Publicacao_PublicacaoPostId",
                table: "Likes",
                column: "PublicacaoPostId",
                principalTable: "Publicacao",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacao_Utilizador_UtilizadorFK",
                table: "Publicacao",
                column: "UtilizadorFK",
                principalTable: "Utilizador",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Publicacao_PublicacaoPostId",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Publicacao_PublicacaoPostId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacao_Utilizador_UtilizadorFK",
                table: "Publicacao");

            migrationBuilder.DropTable(
                name: "CategoriaPublicacao");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "Utilizador");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Utilizador",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Foto",
                table: "Utilizador",
                newName: "foto");

            migrationBuilder.RenameColumn(
                name: "UserID",
                table: "Utilizador",
                newName: "userID");

            migrationBuilder.RenameColumn(
                name: "Telefone",
                table: "Utilizador",
                newName: "password");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Publicacao",
                newName: "titulo");

            migrationBuilder.RenameColumn(
                name: "Foto",
                table: "Publicacao",
                newName: "foto");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Publicacao",
                newName: "descricao");

            migrationBuilder.RenameColumn(
                name: "PostId",
                table: "Publicacao",
                newName: "postId");

            migrationBuilder.RenameColumn(
                name: "UtilizadorFK",
                table: "Publicacao",
                newName: "CategoriaFK");

            migrationBuilder.RenameIndex(
                name: "IX_Publicacao_UtilizadorFK",
                table: "Publicacao",
                newName: "IX_Publicacao_CategoriaFK");

            migrationBuilder.RenameColumn(
                name: "PublicacaoPostId",
                table: "Likes",
                newName: "PublicacaopostId");

            migrationBuilder.RenameColumn(
                name: "LikeID",
                table: "Likes",
                newName: "likeID");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_PublicacaoPostId",
                table: "Likes",
                newName: "IX_Likes_PublicacaopostId");

            migrationBuilder.RenameColumn(
                name: "Texto",
                table: "Comentarios",
                newName: "texto");

            migrationBuilder.RenameColumn(
                name: "PublicacaoPostId",
                table: "Comentarios",
                newName: "PublicacaopostId");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "Comentarios",
                newName: "commentId");

            migrationBuilder.RenameIndex(
                name: "IX_Comentarios_PublicacaoPostId",
                table: "Comentarios",
                newName: "IX_Comentarios_PublicacaopostId");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Categorias",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "Categorias",
                newName: "categoriaId");

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "Utilizador",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
                name: "IX_PublicacaoUtilizador_ListaUtilizadoresuserID",
                table: "PublicacaoUtilizador",
                column: "ListaUtilizadoresuserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Publicacao_PublicacaopostId",
                table: "Comentarios",
                column: "PublicacaopostId",
                principalTable: "Publicacao",
                principalColumn: "postId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Publicacao_PublicacaopostId",
                table: "Likes",
                column: "PublicacaopostId",
                principalTable: "Publicacao",
                principalColumn: "postId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacao_Categorias_CategoriaFK",
                table: "Publicacao",
                column: "CategoriaFK",
                principalTable: "Categorias",
                principalColumn: "categoriaId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
