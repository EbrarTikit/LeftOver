using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class BulkMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropColumn(
                name: "Rate",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Baskets");

            migrationBuilder.RenameColumn(
                name: "AddressID",
                table: "Restaurants",
                newName: "postalCode");

            migrationBuilder.RenameColumn(
                name: "RestaurantID",
                table: "Reservations",
                newName: "RestaurantId");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Reservations",
                newName: "totalPrice");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Reservations",
                newName: "ReservationCode");

            migrationBuilder.RenameColumn(
                name: "RestaurantID",
                table: "Items",
                newName: "RestaurantId");

            migrationBuilder.RenameColumn(
                name: "FavouritesID",
                table: "Customers",
                newName: "FavouritesId");

            migrationBuilder.RenameColumn(
                name: "BasketID",
                table: "Customers",
                newName: "BasketId");

            migrationBuilder.RenameColumn(
                name: "ZipCode",
                table: "Addresses",
                newName: "Town");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Addresses",
                newName: "Neighbourhood");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreetInformation",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId1",
                table: "Reservations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "isCancelled",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "isDelivered",
                table: "Reservations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "itemId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Items",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BasketId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "pieceNumber",
                table: "Items",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Favourites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RestaurantId",
                table: "Favourites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AdressId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BasketId1",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavoritesId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "itemID",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "customerId",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "AdressDirection",
                table: "Addresses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuildingNo",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Floor",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_itemId",
                table: "Reservations",
                column: "itemId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RestaurantId",
                table: "Reservations",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RestaurantId1",
                table: "Reservations",
                column: "RestaurantId1",
                unique: true,
                filter: "[RestaurantId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Items_BasketId",
                table: "Items",
                column: "BasketId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemId",
                table: "Items",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_RestaurantId",
                table: "Items",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_RestaurantId",
                table: "Favourites",
                column: "RestaurantId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_BasketId1",
                table: "Customers",
                column: "BasketId1");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FavoritesId",
                table: "Customers",
                column: "FavoritesId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_ReservationId",
                table: "Customers",
                column: "ReservationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Addresses_AddressId",
                table: "Customers",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Baskets_BasketId1",
                table: "Customers",
                column: "BasketId1",
                principalTable: "Baskets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Favourites_FavoritesId",
                table: "Customers",
                column: "FavoritesId",
                principalTable: "Favourites",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Reservations_ReservationId",
                table: "Customers",
                column: "ReservationId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Restaurants_RestaurantId",
                table: "Favourites",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Baskets_BasketId",
                table: "Items",
                column: "BasketId",
                principalTable: "Baskets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Items_ItemId",
                table: "Items",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Restaurants_RestaurantId",
                table: "Items",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Items_itemId",
                table: "Reservations",
                column: "itemId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Restaurants_RestaurantId",
                table: "Reservations",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Restaurants_RestaurantId1",
                table: "Reservations",
                column: "RestaurantId1",
                principalTable: "Restaurants",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_AddressId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Baskets_BasketId1",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Favourites_FavoritesId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Reservations_ReservationId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Restaurants_RestaurantId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Baskets_BasketId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Items_ItemId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Restaurants_RestaurantId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Items_itemId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Restaurants_RestaurantId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Restaurants_RestaurantId1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_itemId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RestaurantId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RestaurantId1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Items_BasketId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_RestaurantId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Favourites_RestaurantId",
                table: "Favourites");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AddressId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_BasketId1",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_FavoritesId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ReservationId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "StreetInformation",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "RestaurantId1",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "isCancelled",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "isDelivered",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "itemId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "BasketId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "pieceNumber",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "RestaurantId",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AdressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "BasketId1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FavoritesId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "customerId",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "AdressDirection",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "BuildingNo",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Floor",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "postalCode",
                table: "Restaurants",
                newName: "AddressID");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Reservations",
                newName: "RestaurantID");

            migrationBuilder.RenameColumn(
                name: "totalPrice",
                table: "Reservations",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "ReservationCode",
                table: "Reservations",
                newName: "UserName");

            migrationBuilder.RenameColumn(
                name: "RestaurantId",
                table: "Items",
                newName: "RestaurantID");

            migrationBuilder.RenameColumn(
                name: "FavouritesId",
                table: "Customers",
                newName: "FavouritesID");

            migrationBuilder.RenameColumn(
                name: "BasketId",
                table: "Customers",
                newName: "BasketID");

            migrationBuilder.RenameColumn(
                name: "Town",
                table: "Addresses",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "Neighbourhood",
                table: "Addresses",
                newName: "State");

            migrationBuilder.AddColumn<double>(
                name: "Rate",
                table: "Restaurants",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantID",
                table: "Reservations",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "RestaurantID",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Favourites",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "itemID",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Baskets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BasketID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PieceNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                });
        }
    }
}
