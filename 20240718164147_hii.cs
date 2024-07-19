using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MVCProject.Migrations
{
    /// <inheritdoc />
    public partial class hii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Designation",
                columns: table => new
                {
                    DesignationIdRef = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation", x => x.DesignationIdRef);
                });

            migrationBuilder.CreateTable(
                name: "DesignationGrade",
                columns: table => new
                {
                    GradeIdRef = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesignationIdRef = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DesignationGrade", x => x.GradeIdRef);
                    table.ForeignKey(
                        name: "FK_DesignationGrade_Designation_DesignationIdRef",
                        column: x => x.DesignationIdRef,
                        principalTable: "Designation",
                        principalColumn: "DesignationIdRef",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesignationIdRef = table.Column<int>(type: "int", nullable: false),
                    GradeIdRef = table.Column<int>(type: "int", nullable: false),
                    GradeIdRef1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_DesignationGrade_GradeIdRef1",
                        column: x => x.GradeIdRef1,
                        principalTable: "DesignationGrade",
                        principalColumn: "GradeIdRef",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employee_Designation_DesignationIdRef",
                        column: x => x.DesignationIdRef,
                        principalTable: "Designation",
                        principalColumn: "DesignationIdRef",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DesignationGrade_DesignationIdRef",
                table: "DesignationGrade",
                column: "DesignationIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DesignationIdRef",
                table: "Employee",
                column: "DesignationIdRef");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_GradeIdRef1",
                table: "Employee",
                column: "GradeIdRef1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "DesignationGrade");

            migrationBuilder.DropTable(
                name: "Designation");
        }
    }
}
