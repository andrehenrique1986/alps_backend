using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ALPS.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaFornecedor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    fornecedor_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    fornecedor_nome = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    fornecedor_nome_fantasia = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    fornecedor_numero_fiscal = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    fornecedor_endereco = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    fornecedor_telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    fornecedor_email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    fornecedor_ativo = table.Column<bool>(type: "boolean", nullable: false),
                    fornecedor_data_criacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_fornecedor_id", x => x.fornecedor_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fornecedor");
        }
    }
}
