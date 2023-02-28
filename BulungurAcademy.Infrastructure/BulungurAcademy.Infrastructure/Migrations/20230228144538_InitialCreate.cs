using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BulungurAcademy.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TelegramId = table.Column<long>(type: "bigint", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserRole = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExamsSubjects",
                columns: table => new
                {
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamsSubjects", x => new { x.SubjectId, x.ExamId });
                    table.ForeignKey(
                        name: "FK_ExamsSubjects_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamsSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamApplicant",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstSubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SecondSubjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamApplicant", x => new { x.UserId, x.ExamId });
                    table.ForeignKey(
                        name: "FK_ExamApplicant_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamApplicant_Subjects_FirstSubjectId",
                        column: x => x.FirstSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExamApplicant_Subjects_SecondSubjectId",
                        column: x => x.SecondSubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExamApplicant_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Exams",
                columns: new[] { "Id", "CreatedAt", "ExamDate", "ExamName", "UpdatedAt" },
                values: new object[] { new Guid("be04ecde-1fc4-4716-be35-eef6d6d8e910"), new DateTime(2023, 2, 28, 19, 45, 38, 736, DateTimeKind.Local).AddTicks(9650), new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Imtihon 1", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("5435ae21-249f-478b-9025-921038560579"), new DateTime(2023, 2, 28, 19, 45, 38, 737, DateTimeKind.Local).AddTicks(9918), "Fizika", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("57208275-ff06-4986-8929-24aa5d9de6cc"), new DateTime(2023, 2, 28, 19, 45, 38, 737, DateTimeKind.Local).AddTicks(9905), "Matematika", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CreatedAt", "FirstName", "LastName", "Phone", "Status", "TelegramId", "UpdatedAt", "UserRole" },
                values: new object[] { new Guid("d0f61a40-70c5-427d-bd11-b3b371865e59"), new DateTime(2023, 2, 28, 19, 45, 38, 738, DateTimeKind.Local).AddTicks(5449), "Shohruz", "Bobobekov", "+998901033685", 1, 1035640073L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ExamApplicant_ExamId",
                table: "ExamApplicant",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamApplicant_FirstSubjectId",
                table: "ExamApplicant",
                column: "FirstSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamApplicant_SecondSubjectId",
                table: "ExamApplicant",
                column: "SecondSubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ExamsSubjects_ExamId",
                table: "ExamsSubjects",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TelegramId",
                table: "Users",
                column: "TelegramId",
                unique: true,
                filter: "[TelegramId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamApplicant");

            migrationBuilder.DropTable(
                name: "ExamsSubjects");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}
