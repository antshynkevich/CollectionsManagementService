using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataORMLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                columns: table => new
                {
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.CollectionId);
                    table.ForeignKey(
                        name: "FK_Collections_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CollectionFields",
                columns: table => new
                {
                    CollectionFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FieldName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FieldType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionFields", x => x.CollectionFieldId);
                    table.ForeignKey(
                        name: "FK_CollectionFields_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CollectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_Collections_CollectionId",
                        column: x => x.CollectionId,
                        principalTable: "Collections",
                        principalColumn: "CollectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BooleanFields",
                columns: table => new
                {
                    BooleanFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollectionFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooleanFields", x => x.BooleanFieldId);
                    table.ForeignKey(
                        name: "FK_BooleanFields_CollectionFields_CollectionFieldId",
                        column: x => x.CollectionFieldId,
                        principalTable: "CollectionFields",
                        principalColumn: "CollectionFieldId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BooleanFields_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId");
                });

            migrationBuilder.CreateTable(
                name: "DateFields",
                columns: table => new
                {
                    DateFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollectionFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateFields", x => x.DateFieldId);
                    table.ForeignKey(
                        name: "FK_DateFields_CollectionFields_CollectionFieldId",
                        column: x => x.CollectionFieldId,
                        principalTable: "CollectionFields",
                        principalColumn: "CollectionFieldId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DateFields_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId");
                });

            migrationBuilder.CreateTable(
                name: "IntegerFields",
                columns: table => new
                {
                    IntegerFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollectionFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegerFields", x => x.IntegerFieldId);
                    table.ForeignKey(
                        name: "FK_IntegerFields_CollectionFields_CollectionFieldId",
                        column: x => x.CollectionFieldId,
                        principalTable: "CollectionFields",
                        principalColumn: "CollectionFieldId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IntegerFields_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId");
                });

            migrationBuilder.CreateTable(
                name: "ItemTag",
                columns: table => new
                {
                    ItemsItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagsTagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTag", x => new { x.ItemsItemId, x.TagsTagId });
                    table.ForeignKey(
                        name: "FK_ItemTag_Items_ItemsItemId",
                        column: x => x.ItemsItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTag_Tags_TagsTagId",
                        column: x => x.TagsTagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StringFields",
                columns: table => new
                {
                    StringFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollectionFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StringFields", x => x.StringFieldId);
                    table.ForeignKey(
                        name: "FK_StringFields_CollectionFields_CollectionFieldId",
                        column: x => x.CollectionFieldId,
                        principalTable: "CollectionFields",
                        principalColumn: "CollectionFieldId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StringFields_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId");
                });

            migrationBuilder.CreateTable(
                name: "TextFields",
                columns: table => new
                {
                    TextFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CollectionFieldId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(512)", maxLength: 512, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextFields", x => x.TextFieldId);
                    table.ForeignKey(
                        name: "FK_TextFields_CollectionFields_CollectionFieldId",
                        column: x => x.CollectionFieldId,
                        principalTable: "CollectionFields",
                        principalColumn: "CollectionFieldId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TextFields_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "ItemId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_BooleanFields_CollectionFieldId",
                table: "BooleanFields",
                column: "CollectionFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_BooleanFields_ItemId",
                table: "BooleanFields",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_CollectionFields_CollectionId",
                table: "CollectionFields",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Collections_CategoryId",
                table: "Collections",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_DateFields_CollectionFieldId",
                table: "DateFields",
                column: "CollectionFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_DateFields_ItemId",
                table: "DateFields",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegerFields_CollectionFieldId",
                table: "IntegerFields",
                column: "CollectionFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_IntegerFields_ItemId",
                table: "IntegerFields",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CollectionId",
                table: "Items",
                column: "CollectionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTag_TagsTagId",
                table: "ItemTag",
                column: "TagsTagId");

            migrationBuilder.CreateIndex(
                name: "IX_StringFields_CollectionFieldId",
                table: "StringFields",
                column: "CollectionFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_StringFields_ItemId",
                table: "StringFields",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TextFields_CollectionFieldId",
                table: "TextFields",
                column: "CollectionFieldId");

            migrationBuilder.CreateIndex(
                name: "IX_TextFields_ItemId",
                table: "TextFields",
                column: "ItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooleanFields");

            migrationBuilder.DropTable(
                name: "DateFields");

            migrationBuilder.DropTable(
                name: "IntegerFields");

            migrationBuilder.DropTable(
                name: "ItemTag");

            migrationBuilder.DropTable(
                name: "StringFields");

            migrationBuilder.DropTable(
                name: "TextFields");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "CollectionFields");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Collections");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
