using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Migration_01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "employers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    company_name = table.Column<string>(type: "text", nullable: false),
                    telephone_number = table.Column<string>(type: "text", nullable: false),
                    address = table.Column<string>(type: "text", nullable: false),
                    number_of_job_postings = table.Column<int>(type: "integer", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    last_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "forbidden_words",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    word = table.Column<string>(type: "text", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    last_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_forbidden_words", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "job_postings",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    position = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    expiration_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    quality = table.Column<int>(type: "integer", nullable: false),
                    benefits = table.Column<List<string>>(type: "text[]", nullable: true),
                    type = table.Column<int>(type: "integer", nullable: false),
                    salary = table.Column<decimal>(type: "numeric", nullable: false),
                    employer_id = table.Column<long>(type: "bigint", nullable: false),
                    created_by = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    last_modified_by = table.Column<string>(type: "text", nullable: true),
                    last_modified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_job_postings", x => x.id);
                    table.ForeignKey(
                        name: "FK_job_postings_employers_employer_id",
                        column: x => x.employer_id,
                        principalTable: "employers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "employers",
                columns: new[] { "id", "address", "company_name", "created", "created_by", "last_modified", "last_modified_by", "number_of_job_postings", "telephone_number" },
                values: new object[,]
                {
                    { 1000000L, "Bursa", "Kariyer Net", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 1, "1234567890" },
                    { 1000001L, "İstanbul", "Definex", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, 1, "9876543210" }
                });

            migrationBuilder.InsertData(
                table: "forbidden_words",
                columns: new[] { "id", "created", "created_by", "last_modified", "last_modified_by", "word" },
                values: new object[,]
                {
                    { 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Çirkin" },
                    { 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, null, null, "Pislik" }
                });

            migrationBuilder.InsertData(
                table: "job_postings",
                columns: new[] { "id", "benefits", "created", "created_by", "description", "employer_id", "expiration_date", "last_modified", "last_modified_by", "position", "quality", "salary", "type" },
                values: new object[,]
                {
                    { 1000000L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Açıklama", 1000000L, new DateTime(2023, 10, 10, 1, 12, 23, 692, DateTimeKind.Utc).AddTicks(8350), null, null, "Yazılım Uzmanı,", 5, 5000m, 0 },
                    { 1000001L, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Açıklama", 1000001L, new DateTime(2023, 11, 10, 1, 12, 23, 692, DateTimeKind.Utc).AddTicks(8360), null, null, "Yazılım Uzmanı", 4, 3000m, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_job_postings_employer_id",
                table: "job_postings",
                column: "employer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "forbidden_words");

            migrationBuilder.DropTable(
                name: "job_postings");

            migrationBuilder.DropTable(
                name: "employers");
        }
    }
}
