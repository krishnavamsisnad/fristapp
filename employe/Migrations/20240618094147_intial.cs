using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employe.Migrations
{
    /// <inheritdoc />
    public partial class intial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Saralydata",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeId = table.Column<int>(type: "int", nullable: false),
                    Employename = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prince = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saralydata", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeId = table.Column<int>(type: "int", nullable: false),
                    Sarly = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employs_Saralydata_EmployeId",
                        column: x => x.EmployeId,
                        principalTable: "Saralydata",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employs_EmployeId",
                table: "Employs",
                column: "EmployeId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employs");

            migrationBuilder.DropTable(
                name: "Saralydata");
        }
    }
}
