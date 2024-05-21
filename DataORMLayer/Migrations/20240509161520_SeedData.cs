using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataORMLayer.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
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
                    { 3, "Clothes" }
                });

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "CollectionId", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("6496dc63-74c0-433e-a2b7-df2404f7f8ae"), 2, "A Torah, a Bible, and a Qur’an", "Art of Three Faiths" },
                    { new Guid("b517042e-3623-4c6f-8364-1c34086d6ee0"), 1, "The description of the \"IMDb top 10 movies\" collection", "IMDb top 10 movies" }
                });

            migrationBuilder.InsertData(
                table: "CollectionFields",
                columns: new[] { "CollectionFieldId", "CollectionId", "FieldName", "FieldType" },
                values: new object[,]
                {
                    { new Guid("3aca56b2-49de-4597-b9ed-8a860291aaab"), new Guid("b517042e-3623-4c6f-8364-1c34086d6ee0"), "Relise date", "Date" },
                    { new Guid("4a30c9d8-95d9-4534-84e1-ea700460b502"), new Guid("b517042e-3623-4c6f-8364-1c34086d6ee0"), "IMDb Score", "Integer" },
                    { new Guid("5b0a1dd9-451b-47a7-9f2e-f8e785aa6916"), new Guid("b517042e-3623-4c6f-8364-1c34086d6ee0"), "Movie Title", "String" },
                    { new Guid("950c8fb5-dc40-4adf-bc87-478ddd52cca3"), new Guid("b517042e-3623-4c6f-8364-1c34086d6ee0"), "Move plot", "Text" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "CollectionId", "Name" },
                values: new object[,]
                {
                    { new Guid("10f44355-2de2-422c-b8e5-196cb1cc7da7"), new Guid("b517042e-3623-4c6f-8364-1c34086d6ee0"), "First position" },
                    { new Guid("3cb2814e-768f-487e-bb15-f19752b8bb56"), new Guid("b517042e-3623-4c6f-8364-1c34086d6ee0"), "3rd position" },
                    { new Guid("f9029210-cd7a-4884-b2ce-3705317a9af3"), new Guid("b517042e-3623-4c6f-8364-1c34086d6ee0"), "Second position" }
                });

            migrationBuilder.InsertData(
                table: "DateFields",
                columns: new[] { "DateFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("7e010e81-bc2a-4b43-a55b-ea13f44ca455"), new Guid("5b0a1dd9-451b-47a7-9f2e-f8e785aa6916"), new Guid("f9029210-cd7a-4884-b2ce-3705317a9af3"), new DateTime(1972, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("83fd153d-35ce-49bc-955b-ca3e7eacf7dc"), new Guid("5b0a1dd9-451b-47a7-9f2e-f8e785aa6916"), new Guid("3cb2814e-768f-487e-bb15-f19752b8bb56"), new DateTime(2008, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("9a69dbee-de41-4d67-88b9-d7cb54903d35"), new Guid("5b0a1dd9-451b-47a7-9f2e-f8e785aa6916"), new Guid("10f44355-2de2-422c-b8e5-196cb1cc7da7"), new DateTime(1994, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "IntegerFields",
                columns: new[] { "IntegerFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("1188a3be-8e36-45b6-8515-6d57231699d0"), new Guid("5b0a1dd9-451b-47a7-9f2e-f8e785aa6916"), new Guid("10f44355-2de2-422c-b8e5-196cb1cc7da7"), 93 },
                    { new Guid("1cfd8e0a-bf02-4f5e-b616-d44f8c251771"), new Guid("5b0a1dd9-451b-47a7-9f2e-f8e785aa6916"), new Guid("f9029210-cd7a-4884-b2ce-3705317a9af3"), 92 },
                    { new Guid("2129fc60-da9a-4576-a34a-d64f7b1d6150"), new Guid("5b0a1dd9-451b-47a7-9f2e-f8e785aa6916"), new Guid("3cb2814e-768f-487e-bb15-f19752b8bb56"), 90 }
                });

            migrationBuilder.InsertData(
                table: "StringFields",
                columns: new[] { "StringFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("029295fc-76df-4cf3-afa9-71ed38e79a4c"), new Guid("5b0a1dd9-451b-47a7-9f2e-f8e785aa6916"), new Guid("10f44355-2de2-422c-b8e5-196cb1cc7da7"), "The Shawshank Redemption" },
                    { new Guid("69f196ac-6b62-470e-90b8-3190a0299fbc"), new Guid("5b0a1dd9-451b-47a7-9f2e-f8e785aa6916"), new Guid("3cb2814e-768f-487e-bb15-f19752b8bb56"), "The Dark Knight" },
                    { new Guid("721f3c36-b04f-4b86-b599-3cea3430ff1d"), new Guid("5b0a1dd9-451b-47a7-9f2e-f8e785aa6916"), new Guid("f9029210-cd7a-4884-b2ce-3705317a9af3"), "The Godfather" }
                });

            migrationBuilder.InsertData(
                table: "TextFields",
                columns: new[] { "TextFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("27fdafd5-67d6-4f3a-bd94-9f695728ad28"), new Guid("950c8fb5-dc40-4adf-bc87-478ddd52cca3"), new Guid("f9029210-cd7a-4884-b2ce-3705317a9af3"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." },
                    { new Guid("501d33fc-6732-4e22-bd4a-a916979da374"), new Guid("950c8fb5-dc40-4adf-bc87-478ddd52cca3"), new Guid("10f44355-2de2-422c-b8e5-196cb1cc7da7"), "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion." },
                    { new Guid("581c5bbf-f961-4074-a037-09b6f6efe434"), new Guid("950c8fb5-dc40-4adf-bc87-478ddd52cca3"), new Guid("3cb2814e-768f-487e-bb15-f19752b8bb56"), "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice." }
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
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("3aca56b2-49de-4597-b9ed-8a860291aaab"));

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("4a30c9d8-95d9-4534-84e1-ea700460b502"));

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "CollectionId",
                keyValue: new Guid("6496dc63-74c0-433e-a2b7-df2404f7f8ae"));

            migrationBuilder.DeleteData(
                table: "DateFields",
                keyColumn: "DateFieldId",
                keyValue: new Guid("7e010e81-bc2a-4b43-a55b-ea13f44ca455"));

            migrationBuilder.DeleteData(
                table: "DateFields",
                keyColumn: "DateFieldId",
                keyValue: new Guid("83fd153d-35ce-49bc-955b-ca3e7eacf7dc"));

            migrationBuilder.DeleteData(
                table: "DateFields",
                keyColumn: "DateFieldId",
                keyValue: new Guid("9a69dbee-de41-4d67-88b9-d7cb54903d35"));

            migrationBuilder.DeleteData(
                table: "IntegerFields",
                keyColumn: "IntegerFieldId",
                keyValue: new Guid("1188a3be-8e36-45b6-8515-6d57231699d0"));

            migrationBuilder.DeleteData(
                table: "IntegerFields",
                keyColumn: "IntegerFieldId",
                keyValue: new Guid("1cfd8e0a-bf02-4f5e-b616-d44f8c251771"));

            migrationBuilder.DeleteData(
                table: "IntegerFields",
                keyColumn: "IntegerFieldId",
                keyValue: new Guid("2129fc60-da9a-4576-a34a-d64f7b1d6150"));

            migrationBuilder.DeleteData(
                table: "StringFields",
                keyColumn: "StringFieldId",
                keyValue: new Guid("029295fc-76df-4cf3-afa9-71ed38e79a4c"));

            migrationBuilder.DeleteData(
                table: "StringFields",
                keyColumn: "StringFieldId",
                keyValue: new Guid("69f196ac-6b62-470e-90b8-3190a0299fbc"));

            migrationBuilder.DeleteData(
                table: "StringFields",
                keyColumn: "StringFieldId",
                keyValue: new Guid("721f3c36-b04f-4b86-b599-3cea3430ff1d"));

            migrationBuilder.DeleteData(
                table: "TextFields",
                keyColumn: "TextFieldId",
                keyValue: new Guid("27fdafd5-67d6-4f3a-bd94-9f695728ad28"));

            migrationBuilder.DeleteData(
                table: "TextFields",
                keyColumn: "TextFieldId",
                keyValue: new Guid("501d33fc-6732-4e22-bd4a-a916979da374"));

            migrationBuilder.DeleteData(
                table: "TextFields",
                keyColumn: "TextFieldId",
                keyValue: new Guid("581c5bbf-f961-4074-a037-09b6f6efe434"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("5b0a1dd9-451b-47a7-9f2e-f8e785aa6916"));

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("950c8fb5-dc40-4adf-bc87-478ddd52cca3"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("10f44355-2de2-422c-b8e5-196cb1cc7da7"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("3cb2814e-768f-487e-bb15-f19752b8bb56"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("f9029210-cd7a-4884-b2ce-3705317a9af3"));

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "CollectionId",
                keyValue: new Guid("b517042e-3623-4c6f-8364-1c34086d6ee0"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);
        }
    }
}
