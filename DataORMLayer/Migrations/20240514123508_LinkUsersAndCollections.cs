using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataORMLayer.Migrations
{
    /// <inheritdoc />
    public partial class LinkUsersAndCollections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("45b1b4be-6329-4e17-83b2-b45582856f5e"));

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("5814e7fd-1452-4299-9777-dd2d6651c130"));

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "CollectionId",
                keyValue: new Guid("6c51e8a9-6935-4771-8605-2d8a0f5c4784"));

            migrationBuilder.DeleteData(
                table: "DateFields",
                keyColumn: "DateFieldId",
                keyValue: new Guid("36e536c7-0170-49c6-994e-d565ab7b0382"));

            migrationBuilder.DeleteData(
                table: "DateFields",
                keyColumn: "DateFieldId",
                keyValue: new Guid("5f8a4381-a205-47aa-92e6-c81346f32447"));

            migrationBuilder.DeleteData(
                table: "DateFields",
                keyColumn: "DateFieldId",
                keyValue: new Guid("6629a625-5159-4813-9b32-9c95ce52b322"));

            migrationBuilder.DeleteData(
                table: "IntegerFields",
                keyColumn: "IntegerFieldId",
                keyValue: new Guid("1196e805-48bd-44c9-af31-daa72b0348bf"));

            migrationBuilder.DeleteData(
                table: "IntegerFields",
                keyColumn: "IntegerFieldId",
                keyValue: new Guid("c85ad82d-914d-4106-9515-bc65b736d456"));

            migrationBuilder.DeleteData(
                table: "IntegerFields",
                keyColumn: "IntegerFieldId",
                keyValue: new Guid("f9e816a1-7d0e-44ae-8a87-5ceaa9f419dd"));

            migrationBuilder.DeleteData(
                table: "StringFields",
                keyColumn: "StringFieldId",
                keyValue: new Guid("0e41554d-ff41-4015-bd46-1bc013377d24"));

            migrationBuilder.DeleteData(
                table: "StringFields",
                keyColumn: "StringFieldId",
                keyValue: new Guid("2116d45c-f4c0-49a3-990d-a95c091cbca6"));

            migrationBuilder.DeleteData(
                table: "StringFields",
                keyColumn: "StringFieldId",
                keyValue: new Guid("9731642d-ac88-4290-be28-7cde968e6a67"));

            migrationBuilder.DeleteData(
                table: "TextFields",
                keyColumn: "TextFieldId",
                keyValue: new Guid("31e1b5f3-7387-42c6-92f6-b4d28fb44a5e"));

            migrationBuilder.DeleteData(
                table: "TextFields",
                keyColumn: "TextFieldId",
                keyValue: new Guid("337c3cf7-dfb7-4f58-a683-9b135ea6ed48"));

            migrationBuilder.DeleteData(
                table: "TextFields",
                keyColumn: "TextFieldId",
                keyValue: new Guid("fa67d56e-39ab-49d6-a110-d1710e0ef664"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("41e60fe2-8c67-4b96-9aea-6e424748a96a"));

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("9cd7aa7b-9844-4dbb-b976-c35567831702"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("96bfae56-2bb3-4cfc-bb06-4d1a7f6cf01b"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("bd417096-98cc-45d0-8426-98d640d1dad6"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("f7ca05e5-9afe-4a69-b334-4b73b3070b89"));

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "CollectionId",
                keyValue: new Guid("3eb4774d-dbd5-4227-95b1-1cd193474556"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Collections",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_UserId",
                table: "Collections",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_AspNetUsers_UserId",
                table: "Collections",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_AspNetUsers_UserId",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_UserId",
                table: "Collections");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Collections");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Movies" },
                    { 2, "Books" },
                    { 3, "Clothes" },
                    { 4, "Games, Toys, and Figures" },
                    { 5, "Bills and Coins, Stamps" },
                    { 6, "Music Albums, Clips, and Records" },
                    { 7, "Firearms" },
                    { 8, "Cars and Vehicles" },
                    { 99, "Other" }
                });

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "CollectionId", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("3eb4774d-dbd5-4227-95b1-1cd193474556"), 1, "The description of the \"IMDb top 10 movies\" collection", "IMDb top 10 movies" },
                    { new Guid("6c51e8a9-6935-4771-8605-2d8a0f5c4784"), 2, "A Torah, a Bible, and a Qur’an", "Art of Three Faiths" }
                });

            migrationBuilder.InsertData(
                table: "CollectionFields",
                columns: new[] { "CollectionFieldId", "CollectionId", "FieldName", "FieldType" },
                values: new object[,]
                {
                    { new Guid("41e60fe2-8c67-4b96-9aea-6e424748a96a"), new Guid("3eb4774d-dbd5-4227-95b1-1cd193474556"), "Movie Title", "String" },
                    { new Guid("45b1b4be-6329-4e17-83b2-b45582856f5e"), new Guid("3eb4774d-dbd5-4227-95b1-1cd193474556"), "Relise date", "Date" },
                    { new Guid("5814e7fd-1452-4299-9777-dd2d6651c130"), new Guid("3eb4774d-dbd5-4227-95b1-1cd193474556"), "IMDb Score", "Integer" },
                    { new Guid("9cd7aa7b-9844-4dbb-b976-c35567831702"), new Guid("3eb4774d-dbd5-4227-95b1-1cd193474556"), "Move plot", "Text" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "CollectionId", "Name" },
                values: new object[,]
                {
                    { new Guid("96bfae56-2bb3-4cfc-bb06-4d1a7f6cf01b"), new Guid("3eb4774d-dbd5-4227-95b1-1cd193474556"), "First position" },
                    { new Guid("bd417096-98cc-45d0-8426-98d640d1dad6"), new Guid("3eb4774d-dbd5-4227-95b1-1cd193474556"), "3rd position" },
                    { new Guid("f7ca05e5-9afe-4a69-b334-4b73b3070b89"), new Guid("3eb4774d-dbd5-4227-95b1-1cd193474556"), "Second position" }
                });

            migrationBuilder.InsertData(
                table: "DateFields",
                columns: new[] { "DateFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("36e536c7-0170-49c6-994e-d565ab7b0382"), new Guid("41e60fe2-8c67-4b96-9aea-6e424748a96a"), new Guid("96bfae56-2bb3-4cfc-bb06-4d1a7f6cf01b"), new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("5f8a4381-a205-47aa-92e6-c81346f32447"), new Guid("41e60fe2-8c67-4b96-9aea-6e424748a96a"), new Guid("bd417096-98cc-45d0-8426-98d640d1dad6"), new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6629a625-5159-4813-9b32-9c95ce52b322"), new Guid("41e60fe2-8c67-4b96-9aea-6e424748a96a"), new Guid("f7ca05e5-9afe-4a69-b334-4b73b3070b89"), new DateTime(1972, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "IntegerFields",
                columns: new[] { "IntegerFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("1196e805-48bd-44c9-af31-daa72b0348bf"), new Guid("41e60fe2-8c67-4b96-9aea-6e424748a96a"), new Guid("f7ca05e5-9afe-4a69-b334-4b73b3070b89"), 92 },
                    { new Guid("c85ad82d-914d-4106-9515-bc65b736d456"), new Guid("41e60fe2-8c67-4b96-9aea-6e424748a96a"), new Guid("bd417096-98cc-45d0-8426-98d640d1dad6"), 90 },
                    { new Guid("f9e816a1-7d0e-44ae-8a87-5ceaa9f419dd"), new Guid("41e60fe2-8c67-4b96-9aea-6e424748a96a"), new Guid("96bfae56-2bb3-4cfc-bb06-4d1a7f6cf01b"), 93 }
                });

            migrationBuilder.InsertData(
                table: "StringFields",
                columns: new[] { "StringFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("0e41554d-ff41-4015-bd46-1bc013377d24"), new Guid("41e60fe2-8c67-4b96-9aea-6e424748a96a"), new Guid("bd417096-98cc-45d0-8426-98d640d1dad6"), "The Dark Knight" },
                    { new Guid("2116d45c-f4c0-49a3-990d-a95c091cbca6"), new Guid("41e60fe2-8c67-4b96-9aea-6e424748a96a"), new Guid("96bfae56-2bb3-4cfc-bb06-4d1a7f6cf01b"), "The Shawshank Redemption" },
                    { new Guid("9731642d-ac88-4290-be28-7cde968e6a67"), new Guid("41e60fe2-8c67-4b96-9aea-6e424748a96a"), new Guid("f7ca05e5-9afe-4a69-b334-4b73b3070b89"), "The Godfather" }
                });

            migrationBuilder.InsertData(
                table: "TextFields",
                columns: new[] { "TextFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("31e1b5f3-7387-42c6-92f6-b4d28fb44a5e"), new Guid("9cd7aa7b-9844-4dbb-b976-c35567831702"), new Guid("bd417096-98cc-45d0-8426-98d640d1dad6"), "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice." },
                    { new Guid("337c3cf7-dfb7-4f58-a683-9b135ea6ed48"), new Guid("9cd7aa7b-9844-4dbb-b976-c35567831702"), new Guid("96bfae56-2bb3-4cfc-bb06-4d1a7f6cf01b"), "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion." },
                    { new Guid("fa67d56e-39ab-49d6-a110-d1710e0ef664"), new Guid("9cd7aa7b-9844-4dbb-b976-c35567831702"), new Guid("f7ca05e5-9afe-4a69-b334-4b73b3070b89"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." }
                });
        }
    }
}
