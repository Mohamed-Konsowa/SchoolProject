using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class configfluentapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departmetSubjects_departments_DID",
                table: "departmetSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_students_departments_DID",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_departmetSubjects_DID",
                table: "departmetSubjects");

            migrationBuilder.AddForeignKey(
                name: "FK_departmetSubjects_departments_SubID",
                table: "departmetSubjects",
                column: "SubID",
                principalTable: "departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_students_departments_DID",
                table: "students",
                column: "DID",
                principalTable: "departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_departmetSubjects_departments_SubID",
                table: "departmetSubjects");

            migrationBuilder.DropForeignKey(
                name: "FK_students_departments_DID",
                table: "students");

            migrationBuilder.CreateIndex(
                name: "IX_departmetSubjects_DID",
                table: "departmetSubjects",
                column: "DID");

            migrationBuilder.AddForeignKey(
                name: "FK_departmetSubjects_departments_DID",
                table: "departmetSubjects",
                column: "DID",
                principalTable: "departments",
                principalColumn: "DID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_students_departments_DID",
                table: "students",
                column: "DID",
                principalTable: "departments",
                principalColumn: "DID");
        }
    }
}
