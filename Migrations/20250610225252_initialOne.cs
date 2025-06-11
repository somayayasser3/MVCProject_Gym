using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    /// <inheritdoc />
    public partial class initialOne : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Coach",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Specialization = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    Experience = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Certification = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Coach__3214EC27AC46CA0E", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DietPlan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__DietPlan__3214EC2727E6130F", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MembershipType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Membersh__3214EC27A1C99DD9", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Program",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CoachID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Program__3214EC275666752F", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Program__CoachID__4222D4EF",
                        column: x => x.CoachID,
                        principalTable: "Coach",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Capacity = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: true),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: true),
                    DayOfWeek = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    ProgramID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Class__3214EC279EF0D6B6", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Class__ProgramID__44FF419A",
                        column: x => x.ProgramID,
                        principalTable: "Program",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Trainee",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Gender = table.Column<string>(type: "char(1)", unicode: false, fixedLength: true, maxLength: 1, nullable: true),
                    JoinDate = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "(CONVERT([date],getdate()))"),
                    DOB = table.Column<DateOnly>(type: "date", nullable: true),
                    MembershipTypeID = table.Column<int>(type: "int", nullable: true),
                    DietPlanID = table.Column<int>(type: "int", nullable: true),
                    ClassID = table.Column<int>(type: "int", nullable: true),
                    CoachID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Trainee__3214EC279E231CF1", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Trainee__ClassID__4AB81AF0",
                        column: x => x.ClassID,
                        principalTable: "Class",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Trainee__CoachID__4BAC3F29",
                        column: x => x.CoachID,
                        principalTable: "Coach",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Trainee__DietPla__49C3F6B7",
                        column: x => x.DietPlanID,
                        principalTable: "DietPlan",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Trainee__Members__3F466844",
                        column: x => x.MembershipTypeID,
                        principalTable: "MembershipType",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "InBodyTest",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateOnly>(type: "date", nullable: true, defaultValueSql: "(CONVERT([date],getdate()))"),
                    Height = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Fats = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    MuscleMass = table.Column<decimal>(type: "decimal(5,2)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TraineeID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__InBodyTe__3214EC273F6719C6", x => x.ID);
                    table.ForeignKey(
                        name: "FK__InBodyTes__Train__48CFD27E",
                        column: x => x.TraineeID,
                        principalTable: "Trainee",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IDX_Class_Program",
                table: "Class",
                column: "ProgramID");

            migrationBuilder.CreateIndex(
                name: "IDX_InBodyTest_Trainee",
                table: "InBodyTest",
                column: "TraineeID");

            migrationBuilder.CreateIndex(
                name: "IDX_Program_Coach",
                table: "Program",
                column: "CoachID");

            migrationBuilder.CreateIndex(
                name: "IDX_Trainee_Class",
                table: "Trainee",
                column: "ClassID");

            migrationBuilder.CreateIndex(
                name: "IDX_Trainee_Coach",
                table: "Trainee",
                column: "CoachID");

            migrationBuilder.CreateIndex(
                name: "IDX_Trainee_DietPlan",
                table: "Trainee",
                column: "DietPlanID");

            migrationBuilder.CreateIndex(
                name: "IDX_Trainee_MembershipType",
                table: "Trainee",
                column: "MembershipTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InBodyTest");

            migrationBuilder.DropTable(
                name: "Trainee");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "DietPlan");

            migrationBuilder.DropTable(
                name: "MembershipType");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "Coach");
        }
    }
}
