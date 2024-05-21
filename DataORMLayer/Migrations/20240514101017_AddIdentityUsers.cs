using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataORMLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Items",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Collections",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Collections",
                type: "nvarchar(512)",
                maxLength: 512,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FieldName",
                table: "CollectionFields",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(64)",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

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

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Collections",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(512)",
                oldMaxLength: 512);

            migrationBuilder.AlterColumn<string>(
                name: "FieldName",
                table: "CollectionFields",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(64)",
                oldMaxLength: 64);

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
    }
}
