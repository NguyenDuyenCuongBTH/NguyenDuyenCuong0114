using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NguyenDuyenCuong114.Migrations
{
    /// <inheritdoc />
    public partial class NDCStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NDCStudent",
                columns: table => new
                {
                    NDCStudentID = table.Column<string>(type: "TEXT", nullable: false),
                    NDCStudentName = table.Column<string>(type: "TEXT", nullable: false),
                    Sdt = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NDCStudent", x => x.NDCStudentID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NDCStudent");
        }
    }
}
