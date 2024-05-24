using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataORMLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddCollectionDateAndImageUri : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "CollectionId",
                keyValue: new Guid("e32017f0-a165-4f97-9af1-673aebb34480"));

            migrationBuilder.DeleteData(
                table: "DateFields",
                keyColumn: "DateFieldId",
                keyValue: new Guid("18f13eb1-40a5-409e-aff7-295c96a7ad9b"));

            migrationBuilder.DeleteData(
                table: "DateFields",
                keyColumn: "DateFieldId",
                keyValue: new Guid("562d1670-3e8c-46e7-8337-8698902dd5c4"));

            migrationBuilder.DeleteData(
                table: "DateFields",
                keyColumn: "DateFieldId",
                keyValue: new Guid("c91d74cd-0eae-49c7-842b-4f277fa821da"));

            migrationBuilder.DeleteData(
                table: "IntegerFields",
                keyColumn: "IntegerFieldId",
                keyValue: new Guid("03a69434-95fd-4a3d-ab15-a1f65d7e7456"));

            migrationBuilder.DeleteData(
                table: "IntegerFields",
                keyColumn: "IntegerFieldId",
                keyValue: new Guid("1c37c5d6-25a1-4c0f-bc8a-cd6b6a8f5a1f"));

            migrationBuilder.DeleteData(
                table: "IntegerFields",
                keyColumn: "IntegerFieldId",
                keyValue: new Guid("eed5f3bf-02a9-42c2-91fc-cc7ce6dcae51"));

            migrationBuilder.DeleteData(
                table: "StringFields",
                keyColumn: "StringFieldId",
                keyValue: new Guid("0045a9a8-7d2b-4a9d-aa1f-bbce32af5d34"));

            migrationBuilder.DeleteData(
                table: "StringFields",
                keyColumn: "StringFieldId",
                keyValue: new Guid("01b5920d-db3a-49ff-981d-1911f0c91ed2"));

            migrationBuilder.DeleteData(
                table: "StringFields",
                keyColumn: "StringFieldId",
                keyValue: new Guid("cda00441-60a5-46d8-8091-64854d6be854"));

            migrationBuilder.DeleteData(
                table: "TextFields",
                keyColumn: "TextFieldId",
                keyValue: new Guid("5285a1a8-a789-42e6-9362-2846a7774692"));

            migrationBuilder.DeleteData(
                table: "TextFields",
                keyColumn: "TextFieldId",
                keyValue: new Guid("82393a40-8f02-4708-ace1-6a0b333f651b"));

            migrationBuilder.DeleteData(
                table: "TextFields",
                keyColumn: "TextFieldId",
                keyValue: new Guid("aea4f00e-a4d6-45ad-82f3-7780a0c7168b"));

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("6b9b5fbc-d5de-4c9f-a9b0-2063bc4a3e0e"));

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("94c39e41-a4cc-4e53-8da1-9d9276c7f8c4"));

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("9d3cc88c-16c5-4c9c-9f0a-4bf975477f7c"));

            migrationBuilder.DeleteData(
                table: "CollectionFields",
                keyColumn: "CollectionFieldId",
                keyValue: new Guid("ec8025b1-fb17-42a5-9c95-641d35b4cb92"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("141ef17d-e2e6-46cb-a553-e5591e8e1017"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("afee4460-1d53-444f-b5ac-0b88148ab372"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("dc1ddc83-8d5c-42cd-a5ad-8a917407135a"));

            migrationBuilder.DeleteData(
                table: "Collections",
                keyColumn: "CollectionId",
                keyValue: new Guid("8d9f08cf-f43a-4566-9442-cbe7d07ac510"));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Collections",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Collections",
                columns: new[] { "CollectionId", "CategoryId", "CreateDate", "Description", "ImageUrl", "Name", "UserId" },
                values: new object[,]
                {
                    { new Guid("8d9f08cf-f43a-4566-9442-cbe7d07ac510"), 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "The description of the \"IMDb top 10 movies\" collection", null, "IMDb top 10 movies", "7D9B7113-A8F8-4035-99A7-A20DD400F6A3" },
                    { new Guid("e32017f0-a165-4f97-9af1-673aebb34480"), 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "A Torah, a Bible, and a Qur’an", null, "Art of Three Faiths", "7D9B7113-A8F8-4035-99A7-A20DD400F6A3" }
                });

            migrationBuilder.InsertData(
                table: "CollectionFields",
                columns: new[] { "CollectionFieldId", "CollectionId", "FieldName", "FieldType" },
                values: new object[,]
                {
                    { new Guid("6b9b5fbc-d5de-4c9f-a9b0-2063bc4a3e0e"), new Guid("8d9f08cf-f43a-4566-9442-cbe7d07ac510"), "Movie Title", "String" },
                    { new Guid("94c39e41-a4cc-4e53-8da1-9d9276c7f8c4"), new Guid("8d9f08cf-f43a-4566-9442-cbe7d07ac510"), "IMDb Score", "Integer" },
                    { new Guid("9d3cc88c-16c5-4c9c-9f0a-4bf975477f7c"), new Guid("8d9f08cf-f43a-4566-9442-cbe7d07ac510"), "Move plot", "Text" },
                    { new Guid("ec8025b1-fb17-42a5-9c95-641d35b4cb92"), new Guid("8d9f08cf-f43a-4566-9442-cbe7d07ac510"), "Relise date", "Date" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "CollectionId", "Name" },
                values: new object[,]
                {
                    { new Guid("141ef17d-e2e6-46cb-a553-e5591e8e1017"), new Guid("8d9f08cf-f43a-4566-9442-cbe7d07ac510"), "3rd position" },
                    { new Guid("afee4460-1d53-444f-b5ac-0b88148ab372"), new Guid("8d9f08cf-f43a-4566-9442-cbe7d07ac510"), "Second position" },
                    { new Guid("dc1ddc83-8d5c-42cd-a5ad-8a917407135a"), new Guid("8d9f08cf-f43a-4566-9442-cbe7d07ac510"), "First position" }
                });

            migrationBuilder.InsertData(
                table: "DateFields",
                columns: new[] { "DateFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("18f13eb1-40a5-409e-aff7-295c96a7ad9b"), new Guid("ec8025b1-fb17-42a5-9c95-641d35b4cb92"), new Guid("afee4460-1d53-444f-b5ac-0b88148ab372"), new DateOnly(1972, 1, 1) },
                    { new Guid("562d1670-3e8c-46e7-8337-8698902dd5c4"), new Guid("ec8025b1-fb17-42a5-9c95-641d35b4cb92"), new Guid("dc1ddc83-8d5c-42cd-a5ad-8a917407135a"), new DateOnly(1994, 1, 1) },
                    { new Guid("c91d74cd-0eae-49c7-842b-4f277fa821da"), new Guid("ec8025b1-fb17-42a5-9c95-641d35b4cb92"), new Guid("141ef17d-e2e6-46cb-a553-e5591e8e1017"), new DateOnly(2008, 1, 1) }
                });

            migrationBuilder.InsertData(
                table: "IntegerFields",
                columns: new[] { "IntegerFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("03a69434-95fd-4a3d-ab15-a1f65d7e7456"), new Guid("94c39e41-a4cc-4e53-8da1-9d9276c7f8c4"), new Guid("141ef17d-e2e6-46cb-a553-e5591e8e1017"), 90 },
                    { new Guid("1c37c5d6-25a1-4c0f-bc8a-cd6b6a8f5a1f"), new Guid("94c39e41-a4cc-4e53-8da1-9d9276c7f8c4"), new Guid("dc1ddc83-8d5c-42cd-a5ad-8a917407135a"), 93 },
                    { new Guid("eed5f3bf-02a9-42c2-91fc-cc7ce6dcae51"), new Guid("94c39e41-a4cc-4e53-8da1-9d9276c7f8c4"), new Guid("afee4460-1d53-444f-b5ac-0b88148ab372"), 92 }
                });

            migrationBuilder.InsertData(
                table: "StringFields",
                columns: new[] { "StringFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("0045a9a8-7d2b-4a9d-aa1f-bbce32af5d34"), new Guid("6b9b5fbc-d5de-4c9f-a9b0-2063bc4a3e0e"), new Guid("afee4460-1d53-444f-b5ac-0b88148ab372"), "The Godfather" },
                    { new Guid("01b5920d-db3a-49ff-981d-1911f0c91ed2"), new Guid("6b9b5fbc-d5de-4c9f-a9b0-2063bc4a3e0e"), new Guid("dc1ddc83-8d5c-42cd-a5ad-8a917407135a"), "The Shawshank Redemption" },
                    { new Guid("cda00441-60a5-46d8-8091-64854d6be854"), new Guid("6b9b5fbc-d5de-4c9f-a9b0-2063bc4a3e0e"), new Guid("141ef17d-e2e6-46cb-a553-e5591e8e1017"), "The Dark Knight" }
                });

            migrationBuilder.InsertData(
                table: "TextFields",
                columns: new[] { "TextFieldId", "CollectionFieldId", "ItemId", "Value" },
                values: new object[,]
                {
                    { new Guid("5285a1a8-a789-42e6-9362-2846a7774692"), new Guid("9d3cc88c-16c5-4c9c-9f0a-4bf975477f7c"), new Guid("afee4460-1d53-444f-b5ac-0b88148ab372"), "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son." },
                    { new Guid("82393a40-8f02-4708-ace1-6a0b333f651b"), new Guid("9d3cc88c-16c5-4c9c-9f0a-4bf975477f7c"), new Guid("141ef17d-e2e6-46cb-a553-e5591e8e1017"), "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice." },
                    { new Guid("aea4f00e-a4d6-45ad-82f3-7780a0c7168b"), new Guid("9d3cc88c-16c5-4c9c-9f0a-4bf975477f7c"), new Guid("dc1ddc83-8d5c-42cd-a5ad-8a917407135a"), "Over the course of several years, two convicts form a friendship, seeking consolation and, eventually, redemption through basic compassion." }
                });
        }
    }
}
