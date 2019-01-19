using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PMAPI.Migrations
{
    public partial class initdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CodeMaps",
                columns: table => new
                {
                    Key = table.Column<string>(maxLength: 32, nullable: false),
                    Version = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    RemovedOn = table.Column<DateTime>(nullable: true),
                    Code = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Category = table.Column<string>(maxLength: 32, nullable: false),
                    CodeName = table.Column<string>(maxLength: 32, nullable: false),
                    Upper = table.Column<string>(maxLength: 32, nullable: true),
                    Lower = table.Column<string>(maxLength: 32, nullable: true),
                    ChineseName = table.Column<string>(maxLength: 32, nullable: false),
                    Description = table.Column<string>(maxLength: 256, nullable: true),
                    Seq = table.Column<int>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeMaps", x => x.Key);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeMaps");
        }
    }
}
