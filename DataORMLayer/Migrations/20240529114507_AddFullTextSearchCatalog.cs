using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataORMLayer.Migrations
{
    /// <inheritdoc />
    public partial class AddFullTextSearchCatalog : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE FULLTEXT CATALOG [FullTextCatalog] WITH ACCENT_SENSITIVITY = OFF AS DEFAULT", true);
            migrationBuilder.Sql("CREATE FULLTEXT INDEX ON dbo.Items(Name) KEY INDEX PK_Items ON FullTextCatalog;", true);
            migrationBuilder.Sql("CREATE FULLTEXT INDEX ON dbo.StringFields(Value) KEY INDEX PK_StringFields ON FullTextCatalog;", true);
            migrationBuilder.Sql("CREATE FULLTEXT INDEX ON dbo.TextFields(Value) KEY INDEX PK_TextFields ON FullTextCatalog;", true);
            migrationBuilder.Sql("CREATE FULLTEXT INDEX ON dbo.Collections(Description) KEY INDEX PK_Collections ON FullTextCatalog;", true);
            migrationBuilder.Sql("CREATE FULLTEXT INDEX ON dbo.Tags(Name) KEY INDEX PK_Tags ON FullTextCatalog;", true);
            migrationBuilder.Sql("CREATE FULLTEXT INDEX ON dbo.Categories(Name) KEY INDEX PK_Categories ON FullTextCatalog;", true);
            migrationBuilder.Sql("CREATE FULLTEXT INDEX ON dbo.CollectionFields(FieldName) KEY INDEX PK_CollectionFields ON FullTextCatalog;", true);
            migrationBuilder.Sql("CREATE FULLTEXT INDEX ON dbo.UserComments(CommentText) KEY INDEX PK_UserComments ON FullTextCatalog;", true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP FULLTEXT CATALOG FullTextCatalog");
        }
    }
}
