using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstManyToMany.Migrations
{
    /// <inheritdoc />
    public partial class DeletPopulation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Population",
                table: "Countries");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Population",
                table: "Countries",
                type: "int",
                nullable: true);
        }
    }
}
