using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Artemis_Issue_Tracker.Data.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    progress = table.Column<int>(type: "int", nullable: false),
                    favorite = table.Column<bool>(type: "bit", nullable: false),
                    sprint_length = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserProject",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProject", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Sprint",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprint", x => x.id);
                    table.ForeignKey(
                        name: "FK_Sprint_Project_project_id",
                        column: x => x.project_id,
                        principalTable: "Project",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    priority = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    position = table.Column<int>(type: "int", nullable: false),
                    progress = table.Column<int>(type: "int", nullable: false),
                    time_estimate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    time_log = table.Column<DateTime>(type: "datetime2", nullable: false),
                    start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    end = table.Column<DateTime>(type: "datetime2", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    project_id = table.Column<int>(type: "int", nullable: true),
                    parent_id = table.Column<int>(type: "int", nullable: true),
                    sprint_id = table.Column<int>(type: "int", nullable: true),
                    parentid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.id);
                    table.ForeignKey(
                        name: "FK_Task_Project_project_id",
                        column: x => x.project_id,
                        principalTable: "Project",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Task_Sprint_sprint_id",
                        column: x => x.sprint_id,
                        principalTable: "Sprint",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Task_Task_parentid",
                        column: x => x.parentid,
                        principalTable: "Task",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    task_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.id);
                    table.ForeignKey(
                        name: "FK_Comment_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comment_Task_task_id",
                        column: x => x.task_id,
                        principalTable: "Task",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    log = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    task_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.id);
                    table.ForeignKey(
                        name: "FK_Log_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Log_Task_task_id",
                        column: x => x.task_id,
                        principalTable: "Task",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    uri = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    option = table.Column<int>(type: "int", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    task_id = table.Column<int>(type: "int", nullable: true),
                    comment_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => x.id);
                    table.ForeignKey(
                        name: "FK_Resource_AspNetUsers_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Resource_Comment_comment_id",
                        column: x => x.comment_id,
                        principalTable: "Comment",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_Resource_Task_task_id",
                        column: x => x.task_id,
                        principalTable: "Task",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_task_id",
                table: "Comment",
                column: "task_id");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_user_id",
                table: "Comment",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Log_task_id",
                table: "Log",
                column: "task_id");

            migrationBuilder.CreateIndex(
                name: "IX_Log_user_id",
                table: "Log",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_comment_id",
                table: "Resource",
                column: "comment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_task_id",
                table: "Resource",
                column: "task_id");

            migrationBuilder.CreateIndex(
                name: "IX_Resource_user_id",
                table: "Resource",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_Sprint_project_id",
                table: "Sprint",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_Task_parentid",
                table: "Task",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "IX_Task_project_id",
                table: "Task",
                column: "project_id");

            migrationBuilder.CreateIndex(
                name: "IX_Task_sprint_id",
                table: "Task",
                column: "sprint_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "Resource");

            migrationBuilder.DropTable(
                name: "UserProject");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropTable(
                name: "Sprint");

            migrationBuilder.DropTable(
                name: "Project");
        }
    }
}
