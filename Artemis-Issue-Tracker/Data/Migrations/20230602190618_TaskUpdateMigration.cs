using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artemis_Issue_Tracker.Data.Migrations
{
    public partial class TaskUpdateMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Task_parentid",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_parentid",
                table: "Task");

            migrationBuilder.DropColumn(
                name: "parentid",
                table: "Task");

            migrationBuilder.CreateIndex(
                name: "IX_Task_parent_id",
                table: "Task",
                column: "parent_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Task_parent_id",
                table: "Task",
                column: "parent_id",
                principalTable: "Task",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Task_Task_parent_id",
                table: "Task");

            migrationBuilder.DropIndex(
                name: "IX_Task_parent_id",
                table: "Task");

            migrationBuilder.AddColumn<int>(
                name: "parentid",
                table: "Task",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Task_parentid",
                table: "Task",
                column: "parentid");

            migrationBuilder.AddForeignKey(
                name: "FK_Task_Task_parentid",
                table: "Task",
                column: "parentid",
                principalTable: "Task",
                principalColumn: "id");
        }
    }
}
