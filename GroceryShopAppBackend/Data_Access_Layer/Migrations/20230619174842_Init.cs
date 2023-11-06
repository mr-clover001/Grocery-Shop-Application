using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data_Access_Layer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyOrders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    ImageFileName = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    Price = table.Column<double>(nullable: true),
                    Discount = table.Column<int>(nullable: true),
                    Specification = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    AvaiableQuantity = table.Column<int>(nullable: true),
                    Category = table.Column<string>(unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyOrders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    ImageFileName = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    Price = table.Column<double>(nullable: true),
                    Discount = table.Column<int>(nullable: true),
                    Specification = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    AvaiableQuantity = table.Column<int>(nullable: true),
                    Category = table.Column<string>(unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogin",
                columns: table => new
                {
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Password = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "UsersRegister",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    LastName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Mobile = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Role = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    MemberSin = table.Column<DateTime>(unicode: false, nullable: false),
                    Password = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersRegister", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ViewCart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    Quantity = table.Column<int>(nullable: true),
                    ImageFileName = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    Price = table.Column<double>(nullable: true),
                    Discount = table.Column<int>(nullable: true),
                    Specification = table.Column<string>(unicode: false, maxLength: 250, nullable: true),
                    AvaiableQuantity = table.Column<int>(nullable: true),
                    Category = table.Column<string>(unicode: false, maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ViewCart", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyOrders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "UserLogin");

            migrationBuilder.DropTable(
                name: "UsersRegister");

            migrationBuilder.DropTable(
                name: "ViewCart");
        }
    }
}
