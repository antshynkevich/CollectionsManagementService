using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataORMLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddDateCreationToItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "CollectionId",
                keyValue: new Guid("6a2d56c8-2450-4504-b0a1-77f884f403b2"));

            migrationBuilder.DeleteData(
                table: "DateFields",
                keyColumn: "DateFieldId",
                keyValue: new Guid("0591592d-2df3-4456-bc89-e46d86f24f10"));

            migrationBuilder.DeleteData(
                table: "DateFields",
                keyColumn: "DateFieldId",
                keyValue: new Guid("9d38dbbb-d396-43e3-b73c-468e22c7192b"));

            migrationBuilder.DeleteData(
                table: "DateFields",
                keyColumn: "DateFieldId",
                keyValue: new Guid("9e321b41-76ff-44cc-a6a7-7aac581224ba"));

            migrationBuilder.DeleteData(
                table: "IntegerFields",
                keyColumn: "IntegerFieldId",
                keyValue: new Guid("4d4d9886-711b-43a1-b309-11eb30cdb448"));

            migrationBuilder.DeleteData(
                table: "IntegerFields",
                keyColumn: "IntegerFieldId",
                keyValue: new Guid("a287ed46-caf4-4003-95fb-973f05bcb5a0"));

            migrationBuilder.DeleteData(
                table: "IntegerFields",
                keyColumn: "IntegerFieldId",
                keyValue: new Guid("c78a3c8a-dcfc-4996-8a38-6550cf3f3662"));

            migrationBuilder.DeleteData(
                table: "StringFields",
                keyColumn: "StringFieldId",
                keyValue: new Guid("19faf591-060b-467e-aa9c-f4209f5758fc"));

            migrationBuilder.DeleteData(
                table: "StringFields",
                keyColumn: "StringFieldId",
                keyValue: new Guid("a8eb5afb-17de-4067-b964-7ce3296b2815"));

            migrationBuilder.DeleteData(
                table: "StringFields",
                keyColumn: "StringFieldId",
                keyValue: new Guid("e66f388a-c59f-407d-b1c2-d0de8f96fd6f"));

            migrationBuilder.DeleteData(
                table: "TextFields",
                keyColumn: "TextFieldId",
                keyValue: new Guid("0a4f1ad8-2df4-446c-a949-6164c3ef31f1"));

            migrationBuilder.DeleteData(
                table: "TextFields",
                keyColumn: "TextFieldId",
                keyValue: new Guid("ec62a8c4-b5ad-44ec-b5f3-2797b22f323f"));

            migrationBuilder.DeleteData(
                table: "TextFields",
                keyColumn: "TextFieldId",
                keyValue: new Guid("f86bf397-5907-4a16-88ed-a6b8287b6b82"));

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("667417d6-24c2-4fa8-8422-d324b276e5ac"));

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("6fe6a0ff-a34b-481a-8a50-91d800a410bc"));

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("8a4b2dd3-222a-4015-9a42-0483816c62d3"));

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("ca840b8b-ac4d-4e11-a7c8-2a2764583e5e"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("c37506ec-4751-4a57-ba38-47f88e66e12a"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("ca1c3b5b-6e17-47d2-afb4-7b5984addaf6"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("df9618db-732e-4057-a849-9cff40a72e4d"));

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "CollectionId",
                keyValue: new Guid("850457ef-d55f-4fb0-a582-c1ecd6981cdd"));

            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Collections",
                newName: "CreationDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 11, "Other" });

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "CollectionId", "CategoryId", "CreationDate", "Description", "ImageUrl", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("18b3ceff-71af-41f0-a233-21f451f3b916"), 2, new DateTime(2024, 5, 25, 13, 44, 28, 489, DateTimeKind.Utc).AddTicks(5295), "A Torah, a Bible, and a Qur’an", null, "Art of Three Faiths", "7D9B7113-A8F8-4035-99A7-A20DD400F6A3" },
                    { new Guid("a6e6789b-5d8b-4b21-a6fe-93bd2facc37f"), 1, new DateTime(2024, 5, 25, 13, 44, 28, 489, DateTimeKind.Utc).AddTicks(5293), "The description of the \"IMDb top 10 movies\" collection", null, "IMDb top 10 movies", "7D9B7113-A8F8-4035-99A7-A20DD400F6A3" }
                });

            migrationBuilder.InsertData(
                table: "CollectionFields",
                columns: new[] { "CollectionFieldId", "CollectionId", "FieldName", "FieldType" },
                values: new object[,]
                {
                    { new Guid("1b69d7fd-3738-45d0-8588-5d386790e5ed"), new Guid("a6e6789b-5d8b-4b21-a6fe-93bd2facc37f"), "IMDb Score", "Integer" },
                    { new Guid("2bca3f20-097b-4e11-8d1f-4b43e3fff2ae"), new Guid("a6e6789b-5d8b-4b21-a6fe-93bd2facc37f"), "Move plot", "Text" },
                    { new Guid("3736e870-843a-40b2-b7e7-c51a1b2e9324"), new Guid("a6e6789b-5d8b-4b21-a6fe-93bd2facc37f"), "Relise date", "Date" },
                    { new Guid("823898ae-9908-4c81-aaa8-39e28e4bcfde"), new Guid("a6e6789b-5d8b-4b21-a6fe-93bd2facc37f"), "Movie Title", "String" },
                    { new Guid("df1a7f2a-cc6a-4fc5-8714-f88e164a2701"), new Guid("18b3ceff-71af-41f0-a233-21f451f3b916"), "Book's contents.", "Text" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "CollectionId", "CreationDate", "Name" },
                values: new object[,]
                {
                    { new Guid("915dab79-35be-41df-95d9-67def07cbec8"), new Guid("18b3ceff-71af-41f0-a233-21f451f3b916"), new DateTime(2024, 5, 25, 13, 44, 28, 489, DateTimeKind.Utc).AddTicks(5352), "Bible" },
                    { new Guid("a47e636b-fd26-4d29-ad18-a6a35e93fad4"), new Guid("a6e6789b-5d8b-4b21-a6fe-93bd2facc37f"), new DateTime(2024, 5, 25, 13, 44, 28, 489, DateTimeKind.Utc).AddTicks(5350), "Second position" },
                    { new Guid("d6efaacb-5cf8-4c85-80e3-f2cce477b104"), new Guid("a6e6789b-5d8b-4b21-a6fe-93bd2facc37f"), new DateTime(2024, 5, 25, 13, 44, 28, 489, DateTimeKind.Utc).AddTicks(5351), "3rd position" },
                    { new Guid("d8f44541-72d6-4c2d-880b-ee02b79d384a"), new Guid("a6e6789b-5d8b-4b21-a6fe-93bd2facc37f"), new DateTime(2024, 5, 25, 13, 44, 28, 489, DateTimeKind.Utc).AddTicks(5349), "First position" }
                });

            migrationBuilder.InsertData(
                table: "DateFields",
                columns: new[] { "DateFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("22b7b63c-d6ee-4134-b961-92356155748c"), new Guid("3736e870-843a-40b2-b7e7-c51a1b2e9324"), new Guid("d8f44541-72d6-4c2d-880b-ee02b79d384a"), new DateOnly(1994, 1, 1) },
                    { new Guid("55dce612-b39e-46e7-9693-92197c4289c9"), new Guid("3736e870-843a-40b2-b7e7-c51a1b2e9324"), new Guid("d6efaacb-5cf8-4c85-80e3-f2cce477b104"), new DateOnly(2008, 1, 1) },
                    { new Guid("cb14e74d-acb4-4c2d-a185-d1e5ba0dfb68"), new Guid("3736e870-843a-40b2-b7e7-c51a1b2e9324"), new Guid("a47e636b-fd26-4d29-ad18-a6a35e93fad4"), new DateOnly(1972, 1, 1) }
                });

            migrationBuilder.InsertData(
                table: "IntegerFields",
                columns: new[] { "IntegerFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("4e2cef90-18b7-4caf-9310-178ea7b6f224"), new Guid("1b69d7fd-3738-45d0-8588-5d386790e5ed"), new Guid("d6efaacb-5cf8-4c85-80e3-f2cce477b104"), 90 },
                    { new Guid("d9cab02c-8f7b-47f8-b935-52992ac1cfac"), new Guid("1b69d7fd-3738-45d0-8588-5d386790e5ed"), new Guid("d8f44541-72d6-4c2d-880b-ee02b79d384a"), 93 },
                    { new Guid("fa526541-33c6-4d27-9703-bd46e8b43cdb"), new Guid("1b69d7fd-3738-45d0-8588-5d386790e5ed"), new Guid("a47e636b-fd26-4d29-ad18-a6a35e93fad4"), 92 }
                });

            migrationBuilder.InsertData(
                table: "StringFields",
                columns: new[] { "StringFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("2731dfb5-8e35-43b4-a3c8-bce0499fe12f"), new Guid("823898ae-9908-4c81-aaa8-39e28e4bcfde"), new Guid("d8f44541-72d6-4c2d-880b-ee02b79d384a"), "The Shawshank Redemption" },
                    { new Guid("3065ea0b-73a8-4718-a434-9c7f747f60a2"), new Guid("823898ae-9908-4c81-aaa8-39e28e4bcfde"), new Guid("d6efaacb-5cf8-4c85-80e3-f2cce477b104"), "The Dark Knight" },
                    { new Guid("5722b69e-b94d-4203-a155-fb53f6640b07"), new Guid("823898ae-9908-4c81-aaa8-39e28e4bcfde"), new Guid("a47e636b-fd26-4d29-ad18-a6a35e93fad4"), "The Godfather" }
                });

            migrationBuilder.InsertData(
                table: "TextFields",
                columns: new[] { "TextFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("77518d47-487b-4d65-b9f5-1b435e972c5c"), new Guid("2bca3f20-097b-4e11-8d1f-4b43e3fff2ae"), new Guid("a47e636b-fd26-4d29-ad18-a6a35e93fad4"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." },
                    { new Guid("aa899aee-a89d-475b-a208-90fb68379ffd"), new Guid("2bca3f20-097b-4e11-8d1f-4b43e3fff2ae"), new Guid("d6efaacb-5cf8-4c85-80e3-f2cce477b104"), "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice." },
                    { new Guid("c2694121-3db5-415a-a653-019b7b557786"), new Guid("2bca3f20-097b-4e11-8d1f-4b43e3fff2ae"), new Guid("d8f44541-72d6-4c2d-880b-ee02b79d384a"), "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion." },
                    { new Guid("cdc21a7c-0844-4ad7-a2ed-4de3850045dc"), new Guid("df1a7f2a-cc6a-4fc5-8714-f88e164a2701"), new Guid("915dab79-35be-41df-95d9-67def07cbec8"), "The Bible is a collection of religious texts or scriptures, some, all, or a variant of which are held to be sacred in Christianity, Judaism, Samaritanism, Islam, the Baha'i Faith, and other Abrahamic religions." }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "DateFields",
                keyColumn: "DateFieldId",
                keyValue: new Guid("22b7b63c-d6ee-4134-b961-92356155748c"));

            migrationBuilder.DeleteData(
                table: "DateFields",
                keyColumn: "DateFieldId",
                keyValue: new Guid("55dce612-b39e-46e7-9693-92197c4289c9"));

            migrationBuilder.DeleteData(
                table: "DateFields",
                keyColumn: "DateFieldId",
                keyValue: new Guid("cb14e74d-acb4-4c2d-a185-d1e5ba0dfb68"));

            migrationBuilder.DeleteData(
                table: "IntegerFields",
                keyColumn: "IntegerFieldId",
                keyValue: new Guid("4e2cef90-18b7-4caf-9310-178ea7b6f224"));

            migrationBuilder.DeleteData(
                table: "IntegerFields",
                keyColumn: "IntegerFieldId",
                keyValue: new Guid("d9cab02c-8f7b-47f8-b935-52992ac1cfac"));

            migrationBuilder.DeleteData(
                table: "IntegerFields",
                keyColumn: "IntegerFieldId",
                keyValue: new Guid("fa526541-33c6-4d27-9703-bd46e8b43cdb"));

            migrationBuilder.DeleteData(
                table: "StringFields",
                keyColumn: "StringFieldId",
                keyValue: new Guid("2731dfb5-8e35-43b4-a3c8-bce0499fe12f"));

            migrationBuilder.DeleteData(
                table: "StringFields",
                keyColumn: "StringFieldId",
                keyValue: new Guid("3065ea0b-73a8-4718-a434-9c7f747f60a2"));

            migrationBuilder.DeleteData(
                table: "StringFields",
                keyColumn: "StringFieldId",
                keyValue: new Guid("5722b69e-b94d-4203-a155-fb53f6640b07"));

            migrationBuilder.DeleteData(
                table: "TextFields",
                keyColumn: "TextFieldId",
                keyValue: new Guid("77518d47-487b-4d65-b9f5-1b435e972c5c"));

            migrationBuilder.DeleteData(
                table: "TextFields",
                keyColumn: "TextFieldId",
                keyValue: new Guid("aa899aee-a89d-475b-a208-90fb68379ffd"));

            migrationBuilder.DeleteData(
                table: "TextFields",
                keyColumn: "TextFieldId",
                keyValue: new Guid("c2694121-3db5-415a-a653-019b7b557786"));

            migrationBuilder.DeleteData(
                table: "TextFields",
                keyColumn: "TextFieldId",
                keyValue: new Guid("cdc21a7c-0844-4ad7-a2ed-4de3850045dc"));

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("1b69d7fd-3738-45d0-8588-5d386790e5ed"));

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("2bca3f20-097b-4e11-8d1f-4b43e3fff2ae"));

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("3736e870-843a-40b2-b7e7-c51a1b2e9324"));

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("823898ae-9908-4c81-aaa8-39e28e4bcfde"));

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("df1a7f2a-cc6a-4fc5-8714-f88e164a2701"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("915dab79-35be-41df-95d9-67def07cbec8"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("a47e636b-fd26-4d29-ad18-a6a35e93fad4"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("d6efaacb-5cf8-4c85-80e3-f2cce477b104"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("d8f44541-72d6-4c2d-880b-ee02b79d384a"));

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "CollectionId",
                keyValue: new Guid("18b3ceff-71af-41f0-a233-21f451f3b916"));

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "CollectionId",
                keyValue: new Guid("a6e6789b-5d8b-4b21-a6fe-93bd2facc37f"));

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "CreationDate",
                table: "Collections",
                newName: "CreateDate");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 99, "Other" });

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "CollectionId", "CategoryId", "CreateDate", "Description", "ImageUrl", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("6a2d56c8-2450-4504-b0a1-77f884f403b2"), 2, new DateTime(2024, 5, 23, 17, 0, 50, 341, DateTimeKind.Utc).AddTicks(1595), "A Torah, a Bible, and a Qur’an", null, "Art of Three Faiths", "7D9B7113-A8F8-4035-99A7-A20DD400F6A3" },
                    { new Guid("850457ef-d55f-4fb0-a582-c1ecd6981cdd"), 1, new DateTime(2024, 5, 23, 17, 0, 50, 341, DateTimeKind.Utc).AddTicks(1594), "The description of the \"IMDb top 10 movies\" collection", null, "IMDb top 10 movies", "7D9B7113-A8F8-4035-99A7-A20DD400F6A3" }
                });

            migrationBuilder.InsertData(
                table: "CollectionFields",
                columns: new[] { "CollectionFieldId", "CollectionId", "FieldName", "FieldType" },
                values: new object[,]
                {
                    { new Guid("667417d6-24c2-4fa8-8422-d324b276e5ac"), new Guid("850457ef-d55f-4fb0-a582-c1ecd6981cdd"), "IMDb Score", "Integer" },
                    { new Guid("6fe6a0ff-a34b-481a-8a50-91d800a410bc"), new Guid("850457ef-d55f-4fb0-a582-c1ecd6981cdd"), "Relise date", "Date" },
                    { new Guid("8a4b2dd3-222a-4015-9a42-0483816c62d3"), new Guid("850457ef-d55f-4fb0-a582-c1ecd6981cdd"), "Movie Title", "String" },
                    { new Guid("ca840b8b-ac4d-4e11-a7c8-2a2764583e5e"), new Guid("850457ef-d55f-4fb0-a582-c1ecd6981cdd"), "Move plot", "Text" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "CollectionId", "Name" },
                values: new object[,]
                {
                    { new Guid("c37506ec-4751-4a57-ba38-47f88e66e12a"), new Guid("850457ef-d55f-4fb0-a582-c1ecd6981cdd"), "Second position" },
                    { new Guid("ca1c3b5b-6e17-47d2-afb4-7b5984addaf6"), new Guid("850457ef-d55f-4fb0-a582-c1ecd6981cdd"), "First position" },
                    { new Guid("df9618db-732e-4057-a849-9cff40a72e4d"), new Guid("850457ef-d55f-4fb0-a582-c1ecd6981cdd"), "3rd position" }
                });

            migrationBuilder.InsertData(
                table: "DateFields",
                columns: new[] { "DateFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("0591592d-2df3-4456-bc89-e46d86f24f10"), new Guid("6fe6a0ff-a34b-481a-8a50-91d800a410bc"), new Guid("ca1c3b5b-6e17-47d2-afb4-7b5984addaf6"), new DateOnly(1994, 1, 1) },
                    { new Guid("9d38dbbb-d396-43e3-b73c-468e22c7192b"), new Guid("6fe6a0ff-a34b-481a-8a50-91d800a410bc"), new Guid("c37506ec-4751-4a57-ba38-47f88e66e12a"), new DateOnly(1972, 1, 1) },
                    { new Guid("9e321b41-76ff-44cc-a6a7-7aac581224ba"), new Guid("6fe6a0ff-a34b-481a-8a50-91d800a410bc"), new Guid("df9618db-732e-4057-a849-9cff40a72e4d"), new DateOnly(2008, 1, 1) }
                });

            migrationBuilder.InsertData(
                table: "IntegerFields",
                columns: new[] { "IntegerFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("4d4d9886-711b-43a1-b309-11eb30cdb448"), new Guid("667417d6-24c2-4fa8-8422-d324b276e5ac"), new Guid("ca1c3b5b-6e17-47d2-afb4-7b5984addaf6"), 93 },
                    { new Guid("a287ed46-caf4-4003-95fb-973f05bcb5a0"), new Guid("667417d6-24c2-4fa8-8422-d324b276e5ac"), new Guid("c37506ec-4751-4a57-ba38-47f88e66e12a"), 92 },
                    { new Guid("c78a3c8a-dcfc-4996-8a38-6550cf3f3662"), new Guid("667417d6-24c2-4fa8-8422-d324b276e5ac"), new Guid("df9618db-732e-4057-a849-9cff40a72e4d"), 90 }
                });

            migrationBuilder.InsertData(
                table: "StringFields",
                columns: new[] { "StringFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("19faf591-060b-467e-aa9c-f4209f5758fc"), new Guid("8a4b2dd3-222a-4015-9a42-0483816c62d3"), new Guid("df9618db-732e-4057-a849-9cff40a72e4d"), "The Dark Knight" },
                    { new Guid("a8eb5afb-17de-4067-b964-7ce3296b2815"), new Guid("8a4b2dd3-222a-4015-9a42-0483816c62d3"), new Guid("c37506ec-4751-4a57-ba38-47f88e66e12a"), "The Godfather" },
                    { new Guid("e66f388a-c59f-407d-b1c2-d0de8f96fd6f"), new Guid("8a4b2dd3-222a-4015-9a42-0483816c62d3"), new Guid("ca1c3b5b-6e17-47d2-afb4-7b5984addaf6"), "The Shawshank Redemption" }
                });

            migrationBuilder.InsertData(
                table: "TextFields",
                columns: new[] { "TextFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("0a4f1ad8-2df4-446c-a949-6164c3ef31f1"), new Guid("ca840b8b-ac4d-4e11-a7c8-2a2764583e5e"), new Guid("c37506ec-4751-4a57-ba38-47f88e66e12a"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." },
                    { new Guid("ec62a8c4-b5ad-44ec-b5f3-2797b22f323f"), new Guid("ca840b8b-ac4d-4e11-a7c8-2a2764583e5e"), new Guid("ca1c3b5b-6e17-47d2-afb4-7b5984addaf6"), "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion." },
                    { new Guid("f86bf397-5907-4a16-88ed-a6b8287b6b82"), new Guid("ca840b8b-ac4d-4e11-a7c8-2a2764583e5e"), new Guid("df9618db-732e-4057-a849-9cff40a72e4d"), "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice." }
                });
        }
    }
}
