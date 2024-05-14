using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataORMLayer.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataWithUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "CollectionId", "CategoryId", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("c2255774-5eaa-4ba2-973d-59a0ddab4fd3"), 2, "A Torah, a Bible, and a Qur’an", "Art of Three Faiths", "7D9B7113-A8F8-4035-99A7-A20DD400F6A3" },
                    { new Guid("eff0aef6-6bdb-46b6-a3d2-0b95cee5627b"), 1, "The description of the \"IMDb top 10 movies\" collection", "IMDb top 10 movies", "7D9B7113-A8F8-4035-99A7-A20DD400F6A3" }
                });

            migrationBuilder.InsertData(
                table: "CollectionFields",
                columns: new[] { "CollectionFieldId", "CollectionId", "FieldName", "FieldType" },
                values: new object[,]
                {
                    { new Guid("0eb65c24-a088-4ea3-a516-748f23b8c4fc"), new Guid("eff0aef6-6bdb-46b6-a3d2-0b95cee5627b"), "Relise date", "Date" },
                    { new Guid("31183a51-fdd9-4d70-a6bc-ad81ccc9616a"), new Guid("eff0aef6-6bdb-46b6-a3d2-0b95cee5627b"), "IMDb Score", "Integer" },
                    { new Guid("4ac59045-c266-42f7-83d1-90d662c70d50"), new Guid("eff0aef6-6bdb-46b6-a3d2-0b95cee5627b"), "Move plot", "Text" },
                    { new Guid("4eb4a691-e619-4f1a-b3c7-9ce2538f008d"), new Guid("eff0aef6-6bdb-46b6-a3d2-0b95cee5627b"), "Movie Title", "String" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "CollectionId", "Name" },
                values: new object[,]
                {
                    { new Guid("62b2c231-6cc2-43aa-bd50-d0ad23dd4afe"), new Guid("eff0aef6-6bdb-46b6-a3d2-0b95cee5627b"), "3rd position" },
                    { new Guid("6f4d4ac6-2821-44a5-b8d0-d3351347a251"), new Guid("eff0aef6-6bdb-46b6-a3d2-0b95cee5627b"), "Second position" },
                    { new Guid("cbe77005-a0a5-4801-96d4-e0014ec9d7d6"), new Guid("eff0aef6-6bdb-46b6-a3d2-0b95cee5627b"), "First position" }
                });

            migrationBuilder.InsertData(
                table: "DateFields",
                columns: new[] { "DateFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("1175037b-c5f6-4685-b85b-5ca5de399f26"), new Guid("4eb4a691-e619-4f1a-b3c7-9ce2538f008d"), new Guid("6f4d4ac6-2821-44a5-b8d0-d3351347a251"), new DateTime(1972, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("39c75b2e-a926-41c8-bfde-3c23cb347078"), new Guid("4eb4a691-e619-4f1a-b3c7-9ce2538f008d"), new Guid("cbe77005-a0a5-4801-96d4-e0014ec9d7d6"), new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("40a111ae-352b-4c38-96ac-343d52bcb8b6"), new Guid("4eb4a691-e619-4f1a-b3c7-9ce2538f008d"), new Guid("62b2c231-6cc2-43aa-bd50-d0ad23dd4afe"), new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "IntegerFields",
                columns: new[] { "IntegerFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("0cfbf1b1-dcde-4942-8f82-787f4e82e133"), new Guid("4eb4a691-e619-4f1a-b3c7-9ce2538f008d"), new Guid("6f4d4ac6-2821-44a5-b8d0-d3351347a251"), 92 },
                    { new Guid("69762eb8-d70e-41fd-8f97-3564231a3439"), new Guid("4eb4a691-e619-4f1a-b3c7-9ce2538f008d"), new Guid("cbe77005-a0a5-4801-96d4-e0014ec9d7d6"), 93 },
                    { new Guid("7bed4ab8-c6c5-41de-a901-ee4a9f0b02cb"), new Guid("4eb4a691-e619-4f1a-b3c7-9ce2538f008d"), new Guid("62b2c231-6cc2-43aa-bd50-d0ad23dd4afe"), 90 }
                });

            migrationBuilder.InsertData(
                table: "StringFields",
                columns: new[] { "StringFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("8a724c23-b070-4bb8-9236-494782ede9f3"), new Guid("4eb4a691-e619-4f1a-b3c7-9ce2538f008d"), new Guid("cbe77005-a0a5-4801-96d4-e0014ec9d7d6"), "The Shawshank Redemption" },
                    { new Guid("981ae0b9-570e-4bd8-aabc-4fbd008efcff"), new Guid("4eb4a691-e619-4f1a-b3c7-9ce2538f008d"), new Guid("62b2c231-6cc2-43aa-bd50-d0ad23dd4afe"), "The Dark Knight" },
                    { new Guid("c1af57aa-a7cc-4de5-b73f-06597d413d4a"), new Guid("4eb4a691-e619-4f1a-b3c7-9ce2538f008d"), new Guid("6f4d4ac6-2821-44a5-b8d0-d3351347a251"), "The Godfather" }
                });

            migrationBuilder.InsertData(
                table: "TextFields",
                columns: new[] { "TextFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("46aac2de-feef-42c2-ac84-2aa766cfc527"), new Guid("4ac59045-c266-42f7-83d1-90d662c70d50"), new Guid("6f4d4ac6-2821-44a5-b8d0-d3351347a251"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." },
                    { new Guid("81f2fb1a-9a85-4098-a752-84b244a71b94"), new Guid("4ac59045-c266-42f7-83d1-90d662c70d50"), new Guid("cbe77005-a0a5-4801-96d4-e0014ec9d7d6"), "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion." },
                    { new Guid("d2f00405-3022-4bd5-8213-9b5ebbc1e6d5"), new Guid("4ac59045-c266-42f7-83d1-90d662c70d50"), new Guid("62b2c231-6cc2-43aa-bd50-d0ad23dd4afe"), "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: new Guid("0eb65c24-a088-4ea3-a516-748f23b8c4fc"));

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("31183a51-fdd9-4d70-a6bc-ad81ccc9616a"));

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "CollectionId",
                keyValue: new Guid("c2255774-5eaa-4ba2-973d-59a0ddab4fd3"));

            migrationBuilder.DeleteData(
                table: "DateFields",
                keyColumn: "DateFieldId",
                keyValue: new Guid("1175037b-c5f6-4685-b85b-5ca5de399f26"));

            migrationBuilder.DeleteData(
                table: "DateFields",
                keyColumn: "DateFieldId",
                keyValue: new Guid("39c75b2e-a926-41c8-bfde-3c23cb347078"));

            migrationBuilder.DeleteData(
                table: "DateFields",
                keyColumn: "DateFieldId",
                keyValue: new Guid("40a111ae-352b-4c38-96ac-343d52bcb8b6"));

            migrationBuilder.DeleteData(
                table: "IntegerFields",
                keyColumn: "IntegerFieldId",
                keyValue: new Guid("0cfbf1b1-dcde-4942-8f82-787f4e82e133"));

            migrationBuilder.DeleteData(
                table: "IntegerFields",
                keyColumn: "IntegerFieldId",
                keyValue: new Guid("69762eb8-d70e-41fd-8f97-3564231a3439"));

            migrationBuilder.DeleteData(
                table: "IntegerFields",
                keyColumn: "IntegerFieldId",
                keyValue: new Guid("7bed4ab8-c6c5-41de-a901-ee4a9f0b02cb"));

            migrationBuilder.DeleteData(
                table: "StringFields",
                keyColumn: "StringFieldId",
                keyValue: new Guid("8a724c23-b070-4bb8-9236-494782ede9f3"));

            migrationBuilder.DeleteData(
                table: "StringFields",
                keyColumn: "StringFieldId",
                keyValue: new Guid("981ae0b9-570e-4bd8-aabc-4fbd008efcff"));

            migrationBuilder.DeleteData(
                table: "StringFields",
                keyColumn: "StringFieldId",
                keyValue: new Guid("c1af57aa-a7cc-4de5-b73f-06597d413d4a"));

            migrationBuilder.DeleteData(
                table: "TextFields",
                keyColumn: "TextFieldId",
                keyValue: new Guid("46aac2de-feef-42c2-ac84-2aa766cfc527"));

            migrationBuilder.DeleteData(
                table: "TextFields",
                keyColumn: "TextFieldId",
                keyValue: new Guid("81f2fb1a-9a85-4098-a752-84b244a71b94"));

            migrationBuilder.DeleteData(
                table: "TextFields",
                keyColumn: "TextFieldId",
                keyValue: new Guid("d2f00405-3022-4bd5-8213-9b5ebbc1e6d5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("4ac59045-c266-42f7-83d1-90d662c70d50"));

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("4eb4a691-e619-4f1a-b3c7-9ce2538f008d"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("62b2c231-6cc2-43aa-bd50-d0ad23dd4afe"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("6f4d4ac6-2821-44a5-b8d0-d3351347a251"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("cbe77005-a0a5-4801-96d4-e0014ec9d7d6"));

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "CollectionId",
                keyValue: new Guid("eff0aef6-6bdb-46b6-a3d2-0b95cee5627b"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);
        }
    }
}
