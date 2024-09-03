using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class PrimaryKeyDefinition2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RestaurantID",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "reservationID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "ItemID",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RestaurantID",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "BasketID",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "itemID",
                table: "BasketItems");

            migrationBuilder.DropColumn(
                name: "AddressID",
                table: "Addresses");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RestaurantID",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "reservationID",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemID",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RestaurantID",
                table: "Favourites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BasketID",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "itemID",
                table: "BasketItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AddressID",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
