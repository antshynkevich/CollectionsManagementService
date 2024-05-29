using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataORMLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddUserCommentsAndLikes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "TextFields",
                type: "nvarchar(1024)",
                maxLength: 1024,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512);

            migrationBuilder.CreateTable(
                name: "UserComments",
                columns: table => new
                {
                    UserCommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    PublicationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComments", x => x.UserCommentId);
                    table.ForeignKey(
                        name: "FK_UserComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserComments_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLikes",
                columns: table => new
                {
                    UserLikeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LikeDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikes", x => x.UserLikeId);
                    table.ForeignKey(
                        name: "FK_UserLikes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserLikes_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Name",
                value: "Electronic Devices and Gadgets");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "Name",
                value: "Clothes");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "Name",
                value: "Music Albums, Clips, and Records");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "Name",
                value: "Products and Services Reviews");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_ItemId",
                table: "UserComments",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComments_UserId",
                table: "UserComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikes_ItemId",
                table: "UserLikes",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikes_UserId",
                table: "UserLikes",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserComments");

            migrationBuilder.DropTable(
                name: "UserLikes");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "TextFields",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1024)",
                oldMaxLength: 1024);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3,
                column: "Name",
                value: "Clothes");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 6,
                column: "Name",
                value: "Music Albums, Clips, and Records");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 7,
                column: "Name",
                value: "Product and Service Reviews");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 10,
                column: "Name",
                value: "Firearms");

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
    }
}
