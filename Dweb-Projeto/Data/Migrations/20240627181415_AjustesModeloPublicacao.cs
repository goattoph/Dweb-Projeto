using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dweb_Projeto.Data.Migrations
{
    /// <inheritdoc />
    public partial class AjustesModeloPublicacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Likes_PublicacaoPostId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_PublicacaoPostId",
                table: "Comentarios");

            migrationBuilder.DropColumn(
                name: "PublicacaoPostId",
                table: "Likes");

            migrationBuilder.DropColumn(
                name: "PublicacaoPostId",
                table: "Comentarios");

            migrationBuilder.AlterColumn<int>(
                name: "UtilizadorFK",
                table: "Publicacao",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Publicacao",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "Comentarios",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Categorias",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PublicacaoFK",
                table: "Likes",
                column: "PublicacaoFK");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_PublicacaoFK",
                table: "Comentarios",
                column: "PublicacaoFK");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Publicacao_PublicacaoFK",
                table: "Comentarios",
                column: "PublicacaoFK",
                principalTable: "Publicacao",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Publicacao_PublicacaoFK",
                table: "Likes",
                column: "PublicacaoFK",
                principalTable: "Publicacao",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Publicacao_Utilizador_UtilizadorFK",
                table: "Publicacao",
                column: "UtilizadorFK",
                principalTable: "Utilizador",
                principalColumn: "UserID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comentarios_Publicacao_PublicacaoFK",
                table: "Comentarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Publicacao_PublicacaoFK",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Publicacao_Utilizador_UtilizadorFK",
                table: "Publicacao");

            migrationBuilder.DropIndex(
                name: "IX_Likes_PublicacaoFK",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Comentarios_PublicacaoFK",
                table: "Comentarios");

            migrationBuilder.AlterColumn<int>(
                name: "UtilizadorFK",
                table: "Publicacao",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Publicacao",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublicacaoPostId",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "Comentarios",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "PublicacaoPostId",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateIndex(
                name: "IX_Likes_PublicacaoPostId",
                table: "Likes",
                column: "PublicacaoPostId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_PublicacaoPostId",
                table: "Comentarios",
                column: "PublicacaoPostId");

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
    }
}
