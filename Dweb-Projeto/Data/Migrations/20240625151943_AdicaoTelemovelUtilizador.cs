using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dweb_Projeto.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicaoTelemovelUtilizador : Migration
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

            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Utilizador");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Utilizador",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Utilizador",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Telemovel",
                table: "Utilizador",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Publicacao",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<int>(
                name: "PublicacaoPostId",
                table: "Likes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "Comentarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "PublicacaoPostId",
                table: "Comentarios",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Comentarios_Publicacao_PublicacaoPostId",
                table: "Comentarios",
                column: "PublicacaoPostId",
                principalTable: "Publicacao",
                principalColumn: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Publicacao_PublicacaoPostId",
                table: "Likes",
                column: "PublicacaoPostId",
                principalTable: "Publicacao",
                principalColumn: "PostId");
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

            migrationBuilder.DropColumn(
                name: "Telemovel",
                table: "Utilizador");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Utilizador",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Foto",
                table: "Utilizador",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Telefone",
                table: "Utilizador",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Publicacao",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PublicacaoPostId",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Texto",
                table: "Comentarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PublicacaoPostId",
                table: "Comentarios",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Categorias",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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
        }
    }
}
