using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infrastructure.Migrations
{
    public partial class PleaseGod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Addresses_AddressId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Baskets_CartId1",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Favourites_FavoritesId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Reservations_ReservationId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Baskets_CartId",
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

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RestaurantId1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Items_CartId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ItemId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Customers_AddressId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_CartId1",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_FavoritesId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_ReservationId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CartId",
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
                name: "AddressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "AdressId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "CartId1",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FavoritesId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "FavouritesId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "itemID",
                table: "Baskets");

            migrationBuilder.RenameColumn(
                name: "itemId",
                table: "Reservations",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_itemId",
                table: "Reservations",
                newName: "IX_Reservations_CustomerId");

            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Restaurants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.Sql("UPDATE Items SET RestaurantId = (SELECT TOP 1 Id FROM Restaurants) WHERE RestaurantId IS NULL");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Addresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BasketItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    CartId = table.Column<int>(type: "int", nullable: false),
                    pieceNumber = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BasketItems_Baskets_CartId",
                        column: x => x.CartId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketItems_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReservationItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ReservationID = table.Column<int>(type: "int", nullable: false),
                    ItemID = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModified = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationItem_Items_ItemID",
                        column: x => x.ItemID,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationItem_Reservations_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RestaurantId1",
                table: "Reservations",
                column: "RestaurantId1");

            migrationBuilder.CreateIndex(
                name: "IX_Baskets_customerId",
                table: "Baskets",
                column: "customerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_CartId",
                table: "BasketItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_BasketItems_ItemId",
                table: "BasketItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationItem_ItemID",
                table: "ReservationItem",
                column: "ItemID");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationItem_ReservationID",
                table: "ReservationItem",
                column: "ReservationID");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Customers_CustomerId",
                table: "Addresses",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Baskets_Customers_customerId",
                table: "Baskets",
                column: "customerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Restaurants_RestaurantId",
                table: "Items",
                column: "RestaurantId",
                principalTable: "Restaurants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Customers_CustomerId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Baskets_Customers_customerId",
                table: "Baskets");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_Restaurants_RestaurantId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations");

            migrationBuilder.DropTable(
                name: "BasketItems");

            migrationBuilder.DropTable(
                name: "ReservationItem");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_RestaurantId1",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Baskets_customerId",
                table: "Baskets");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_CustomerId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "Reservations",
                newName: "itemId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                newName: "IX_Reservations_itemId");

            migrationBuilder.AlterColumn<int>(
                name: "RestaurantId",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
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
                name: "CartId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CartId1",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavoritesId",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FavouritesId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "itemID",
                table: "Baskets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RestaurantId1",
                table: "Reservations",
                column: "RestaurantId1",
                unique: true,
                filter: "[RestaurantId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CartId",
                table: "Items",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemId",
                table: "Items",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_AddressId",
                table: "Customers",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CartId1",
                table: "Customers",
                column: "CartId1");

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
                name: "FK_Customers_Baskets_CartId1",
                table: "Customers",
                column: "CartId1",
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
                name: "FK_Items_Baskets_CartId",
                table: "Items",
                column: "CartId",
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
        }
    }
}
