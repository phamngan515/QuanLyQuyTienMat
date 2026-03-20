using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialDataV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GiaoDich",
                columns: table => new
                {
                    GiaoDichID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoCT = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    NgayCT = table.Column<DateTime>(type: "datetime", nullable: false),
                    DienGiai = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SoTien = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TKDoiUng = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    TenDoiTuong = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    LoaiGiaoDich = table.Column<byte>(type: "tinyint", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    SoTienBangChu = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ChungTuGoc = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GiaoDich__D8D14B310C589D28", x => x.GiaoDichID);
                });

            migrationBuilder.CreateTable(
                name: "VaiTro",
                columns: table => new
                {
                    VaiTroID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenVaiTro = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__VaiTro__477581362A1144F7", x => x.VaiTroID);
                });

            migrationBuilder.CreateTable(
                name: "NguoiDung",
                columns: table => new
                {
                    NguoiDungID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenNguoiDung = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    MatKhau = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    VaiTroID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__NguoiDun__C4BBA4DD1C097B1D", x => x.NguoiDungID);
                    table.ForeignKey(
                        name: "FK_User_Role",
                        column: x => x.VaiTroID,
                        principalTable: "VaiTro",
                        principalColumn: "VaiTroID");
                });

            migrationBuilder.InsertData(
                table: "GiaoDich",
                columns: new[] { "GiaoDichID", "ChungTuGoc", "DiaChi", "DienGiai", "LoaiGiaoDich", "NgayCT", "SoCT", "SoTien", "SoTienBangChu", "TenDoiTuong", "TKDoiUng" },
                values: new object[,]
                {
                    { 1, null, null, null, null, new DateTime(2026, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PT001", 10000000m, null, "Công ty ABC", null },
                    { 2, null, null, null, null, new DateTime(2026, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "PC001", 2500000m, null, "Điện lực Hà Nội", null }
                });

            migrationBuilder.InsertData(
                table: "VaiTro",
                columns: new[] { "VaiTroID", "TenVaiTro" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Kế toán" }
                });

            migrationBuilder.InsertData(
                table: "NguoiDung",
                columns: new[] { "NguoiDungID", "MatKhau", "TenNguoiDung", "VaiTroID" },
                values: new object[] { 1, "202CB962AC59075B964B07152D234B70", "admin", 1 });

            migrationBuilder.CreateIndex(
                name: "UQ__GiaoDich__BC3D1CA82009D386",
                table: "GiaoDich",
                column: "SoCT",
                unique: true,
                filter: "[SoCT] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_NguoiDung_VaiTroID",
                table: "NguoiDung",
                column: "VaiTroID");

            migrationBuilder.CreateIndex(
                name: "UQ__NguoiDun__57E5A81D1AA6E4BB",
                table: "NguoiDung",
                column: "TenNguoiDung",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UQ__VaiTro__1DA558144CD9EAE8",
                table: "VaiTro",
                column: "TenVaiTro",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GiaoDich");

            migrationBuilder.DropTable(
                name: "NguoiDung");

            migrationBuilder.DropTable(
                name: "VaiTro");
        }
    }
}
