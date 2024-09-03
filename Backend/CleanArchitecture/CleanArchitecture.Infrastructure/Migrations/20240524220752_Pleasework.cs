using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class Pleasework : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Baskets_BasketId1",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Baskets_BasketId",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "BasketId",
                table: "Items",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_BasketId",
                table: "Items",
                newName: "IX_Items_CartId");

            migrationBuilder.RenameColumn(
                name: "BasketId1",
                table: "Customers",
                newName: "CartId1");

            migrationBuilder.RenameColumn(
                name: "BasketId",
                table: "Customers",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_BasketId1",
                table: "Customers",
                newName: "IX_Customers_CartId1");

            migrationBuilder.AddColumn<string>(
                name: "CId",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Baskets_CartId1",
                table: "Customers",
                column: "CartId1",
                principalTable: "Baskets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Baskets_CartId",
                table: "Items",
                column: "CartId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Baskets_CartId1",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Baskets_CartId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Items",
                newName: "BasketId");

            migrationBuilder.RenameIndex(
                name: "IX_Items_CartId",
                table: "Items",
                newName: "IX_Items_BasketId");

            migrationBuilder.RenameColumn(
                name: "CartId1",
                table: "Customers",
                newName: "BasketId1");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Customers",
                newName: "BasketId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_CartId1",
                table: "Customers",
                newName: "IX_Customers_BasketId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Baskets_BasketId1",
                table: "Customers",
                column: "BasketId1",
                principalTable: "Baskets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Baskets_BasketId",
                table: "Items",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
