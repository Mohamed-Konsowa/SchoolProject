using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class configdataannotationaddInstructor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_studentSubjects",
                table: "studentSubjects");

            migrationBuilder.DropIndex(
                name: "IX_studentSubjects_SubID",
                table: "studentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departmetSubjects",
                table: "departmetSubjects");

            migrationBuilder.DropIndex(
                name: "IX_departmetSubjects_SubID",
                table: "departmetSubjects");

            migrationBuilder.DropColumn(
                name: "StudSubID",
                table: "studentSubjects");

            migrationBuilder.DropColumn(
                name: "DeptSubID",
                table: "departmetSubjects");

            migrationBuilder.AlterColumn<string>(
                name: "NameEn",
                table: "students",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "InsManagerId",
                table: "departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_studentSubjects",
                table: "studentSubjects",
                columns: new[] { "SubID", "StudID" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_departmetSubjects",
                table: "departmetSubjects",
                columns: new[] { "SubID", "DID" });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameAr = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameEn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DID = table.Column<int>(type: "int", nullable: false),
                    SuperVisorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.InsId);
                    table.ForeignKey(
                        name: "FK_Instructor_Instructor_SuperVisorId",
                        column: x => x.SuperVisorId,
                        principalTable: "Instructor",
                        principalColumn: "InsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Instructor_departments_DID",
                        column: x => x.DID,
                        principalTable: "departments",
                        principalColumn: "DID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ins_Subject",
                columns: table => new
                {
                    InsId = table.Column<int>(type: "int", nullable: false),
                    SubId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ins_Subject", x => new { x.SubId, x.InsId });
                    table.ForeignKey(
                        name: "FK_Ins_Subject_Instructor_InsId",
                        column: x => x.InsId,
                        principalTable: "Instructor",
                        principalColumn: "InsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ins_Subject_subjects_SubId",
                        column: x => x.SubId,
                        principalTable: "subjects",
                        principalColumn: "SubID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_departments_InsManagerId",
                table: "departments",
                column: "InsManagerId",
                unique: true,
                filter: "[InsManagerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Ins_Subject_InsId",
                table: "Ins_Subject",
                column: "InsId");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_DID",
                table: "Instructor",
                column: "DID");

            migrationBuilder.CreateIndex(
                name: "IX_Instructor_SuperVisorId",
                table: "Instructor",
                column: "SuperVisorId");

            migrationBuilder.AddForeignKey(
                name: "FK_departments_Instructor_InsManagerId",
                table: "departments",
                column: "InsManagerId",
                principalTable: "Instructor",
                principalColumn: "InsId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departments_Instructor_InsManagerId",
                table: "departments");

            migrationBuilder.DropTable(
                name: "Ins_Subject");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_studentSubjects",
                table: "studentSubjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_departmetSubjects",
                table: "departmetSubjects");

            migrationBuilder.DropIndex(
                name: "IX_departments_InsManagerId",
                table: "departments");

            migrationBuilder.DropColumn(
                name: "InsManagerId",
                table: "departments");

            migrationBuilder.AddColumn<int>(
                name: "StudSubID",
                table: "studentSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "NameEn",
                table: "students",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "DeptSubID",
                table: "departmetSubjects",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_studentSubjects",
                table: "studentSubjects",
                column: "StudSubID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_departmetSubjects",
                table: "departmetSubjects",
                column: "DeptSubID");

            migrationBuilder.CreateIndex(
                name: "IX_studentSubjects_SubID",
                table: "studentSubjects",
                column: "SubID");

            migrationBuilder.CreateIndex(
                name: "IX_departmetSubjects_SubID",
                table: "departmetSubjects",
                column: "SubID");
        }
    }
}
