using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDS_Backend_final.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnsToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
            name: "CategoryID",
            table: "Columns",
            type: "int",
            nullable: false,
            defaultValue: 0
        );

            migrationBuilder.CreateIndex(
                name: "IX_Columns_CategoryID",
                table: "Columns",
                column: "CategoryID"
            );

            migrationBuilder.AddForeignKey(
                name: "FK_Columns_Categories_CategoryID",
                table: "Columns",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.NoAction,  // Specify the action on delete
                onUpdate: ReferentialAction.NoAction   // Specify the action on update
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
