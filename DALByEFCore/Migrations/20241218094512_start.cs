using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DALByEFCore.Migrations
{
    /// <inheritdoc />
    public partial class start : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    empid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Emptz = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false),
                    LastName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: false),
                    FirstName = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    Zip = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: true),
                    Phone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    Address = table.Column<string>(type: "varchar(25)", unicode: false, maxLength: 25, nullable: true),
                    City = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Position = table.Column<int>(type: "int", nullable: true),
                    DateHire = table.Column<DateOnly>(type: "date", nullable: true),
                    birthdate = table.Column<DateOnly>(type: "date", nullable: true),
                    managerID = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee_tbl", x => x.empid);
                });

            migrationBuilder.CreateTable(
                name: "Products_tbl",
                columns: table => new
                {
                    ProdID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdDesc = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: true),
                    cost_buy = table.Column<int>(type: "int", nullable: true),
                    Cost_sale = table.Column<double>(type: "float", nullable: false),
                    qty_stock = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products_tbl", x => x.ProdID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CustAddress = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CustCity = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    CustPhone = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    CustFax = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: true),
                    EmpID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer_tbl", x => x.CustID);
                    table.ForeignKey(
                        name: "FK_Customer_tbl_Employee_tbl",
                        column: x => x.EmpID,
                        principalTable: "Employees",
                        principalColumn: "empid");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeSalary_tbl",
                columns: table => new
                {
                    EmpID = table.Column<int>(type: "int", nullable: false),
                    PeriodDate = table.Column<DateOnly>(type: "date", nullable: false),
                    Payrate = table.Column<int>(type: "int", nullable: true),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    Bonus = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeSalary_tbl", x => new { x.EmpID, x.PeriodDate });
                    table.ForeignKey(
                        name: "FK_EmployeeSalary_tbl_Employee_tbl",
                        column: x => x.EmpID,
                        principalTable: "Employees",
                        principalColumn: "empid");
                });

            migrationBuilder.CreateTable(
                name: "Orders_tbl",
                columns: table => new
                {
                    Ordnum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustID = table.Column<int>(type: "int", nullable: true),
                    ProdID = table.Column<int>(type: "int", nullable: true),
                    Qty = table.Column<int>(type: "int", nullable: true),
                    orddate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders_tbl", x => x.Ordnum);
                    table.ForeignKey(
                        name: "FK_Orders_tbl_Customer_tbl",
                        column: x => x.CustID,
                        principalTable: "Customers",
                        principalColumn: "CustID");
                    table.ForeignKey(
                        name: "FK_Orders_tbl_Products_tbl",
                        column: x => x.ProdID,
                        principalTable: "Products_tbl",
                        principalColumn: "ProdID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_EmpID",
                table: "Customers",
                column: "EmpID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_tbl_CustID",
                table: "Orders_tbl",
                column: "CustID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_tbl_ProdID",
                table: "Orders_tbl",
                column: "ProdID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeSalary_tbl");

            migrationBuilder.DropTable(
                name: "Orders_tbl");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Products_tbl");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
