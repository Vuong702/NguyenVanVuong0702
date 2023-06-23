using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NguyenVanVuong0702.Migrations
{
    /// <inheritdoc />
    public partial class Creat_Table_NVVStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NVVStudent",
                columns: table => new
                {
                    MaSinhVien = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TenSinhVien = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NVVStudent", x => x.MaSinhVien);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NVVStudent");
        }
    }
}
