using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreMVC_Identity.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    au_id = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: false),
                    au_lname = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: false),
                    au_fname = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    phone = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    address = table.Column<string>(type: "varchar(40)", unicode: false, maxLength: 40, nullable: true),
                    city = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    state = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    zip = table.Column<string>(type: "varchar(5)", unicode: false, maxLength: 5, nullable: true),
                    contract = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.au_id);
                });

            migrationBuilder.CreateIndex(
                name: "aunmind",
                table: "authors",
                columns: new[] { "au_lname", "au_fname" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "authors");
        }
    }
}
