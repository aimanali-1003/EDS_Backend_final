using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EDS_Backend_final.Migrations
{
    /// <inheritdoc />
    public partial class AddClientIDinJob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
                    migrationBuilder.AddColumn<int>(
                        name: "ClientID",
                        table: "Job",
                        type: "int",
                        nullable: false
                    );

            migrationBuilder.CreateIndex(
                name: "IX_Job_ClientID",
                table: "Job",
                column: "ClientID"
            );

                migrationBuilder.AddForeignKey(
         name: "FK_Job_Clients_ClientID",
         table: "Job",
         column: "ClientID",
         principalTable: "Clients",
         principalColumn: "ClientID",
         onDelete: ReferentialAction.NoAction
     );


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
