using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GymApp.Migrations
{
    /// <inheritdoc />
    public partial class Identity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Class__ProgramID__44FF419A",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK__InBodyTes__Train__48CFD27E",
                table: "InBodyTest");

            migrationBuilder.DropForeignKey(
                name: "FK__Program__CoachID__4222D4EF",
                table: "Program");

            migrationBuilder.DropForeignKey(
                name: "FK__Trainee__ClassID__4AB81AF0",
                table: "Trainee");

            migrationBuilder.DropForeignKey(
                name: "FK__Trainee__CoachID__4BAC3F29",
                table: "Trainee");

            migrationBuilder.DropForeignKey(
                name: "FK__Trainee__DietPla__49C3F6B7",
                table: "Trainee");

            migrationBuilder.DropForeignKey(
                name: "FK__Trainee__Members__3F466844",
                table: "Trainee");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Trainee__3214EC279E231CF1",
                table: "Trainee");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Program__3214EC275666752F",
                table: "Program");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Membersh__3214EC27A1C99DD9",
                table: "MembershipType");

            migrationBuilder.DropPrimaryKey(
                name: "PK__InBodyTe__3214EC273F6719C6",
                table: "InBodyTest");

            migrationBuilder.DropPrimaryKey(
                name: "PK__DietPlan__3214EC2727E6130F",
                table: "DietPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Coach__3214EC27AC46CA0E",
                table: "Coach");

            migrationBuilder.DropPrimaryKey(
                name: "PK__Class__3214EC279EF0D6B6",
                table: "Class");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "JoinDate",
                table: "Trainee",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true,
                oldDefaultValueSql: "(CONVERT([date],getdate()))");

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Trainee",
                type: "varchar(1)",
                unicode: false,
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "char(1)",
                oldUnicode: false,
                oldFixedLength: true,
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "InBodyTest",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true,
                oldDefaultValueSql: "(CONVERT([date],getdate()))");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "DietPlan",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true,
                oldDefaultValueSql: "(getdate())");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trainee",
                table: "Trainee",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Program",
                table: "Program",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembershipType",
                table: "MembershipType",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InBodyTest",
                table: "InBodyTest",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DietPlan",
                table: "DietPlan",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Coach",
                table: "Coach",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Class",
                table: "Class",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Class_Program_ProgramID",
                table: "Class",
                column: "ProgramID",
                principalTable: "Program",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_InBodyTest_Trainee_TraineeID",
                table: "InBodyTest",
                column: "TraineeID",
                principalTable: "Trainee",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Program_Coach_CoachID",
                table: "Program",
                column: "CoachID",
                principalTable: "Coach",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_Class_ClassID",
                table: "Trainee",
                column: "ClassID",
                principalTable: "Class",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_Coach_CoachID",
                table: "Trainee",
                column: "CoachID",
                principalTable: "Coach",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_DietPlan_DietPlanID",
                table: "Trainee",
                column: "DietPlanID",
                principalTable: "DietPlan",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Trainee_MembershipType_MembershipTypeID",
                table: "Trainee",
                column: "MembershipTypeID",
                principalTable: "MembershipType",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Class_Program_ProgramID",
                table: "Class");

            migrationBuilder.DropForeignKey(
                name: "FK_InBodyTest_Trainee_TraineeID",
                table: "InBodyTest");

            migrationBuilder.DropForeignKey(
                name: "FK_Program_Coach_CoachID",
                table: "Program");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_Class_ClassID",
                table: "Trainee");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_Coach_CoachID",
                table: "Trainee");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_DietPlan_DietPlanID",
                table: "Trainee");

            migrationBuilder.DropForeignKey(
                name: "FK_Trainee_MembershipType_MembershipTypeID",
                table: "Trainee");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trainee",
                table: "Trainee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Program",
                table: "Program");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MembershipType",
                table: "MembershipType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InBodyTest",
                table: "InBodyTest");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DietPlan",
                table: "DietPlan");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Coach",
                table: "Coach");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Class",
                table: "Class");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "JoinDate",
                table: "Trainee",
                type: "date",
                nullable: true,
                defaultValueSql: "(CONVERT([date],getdate()))",
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "Trainee",
                type: "char(1)",
                unicode: false,
                fixedLength: true,
                maxLength: 1,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(1)",
                oldUnicode: false,
                oldMaxLength: 1,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "InBodyTest",
                type: "date",
                nullable: true,
                defaultValueSql: "(CONVERT([date],getdate()))",
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                table: "DietPlan",
                type: "datetime",
                nullable: true,
                defaultValueSql: "(getdate())",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__Trainee__3214EC279E231CF1",
                table: "Trainee",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Program__3214EC275666752F",
                table: "Program",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Membersh__3214EC27A1C99DD9",
                table: "MembershipType",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__InBodyTe__3214EC273F6719C6",
                table: "InBodyTest",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__DietPlan__3214EC2727E6130F",
                table: "DietPlan",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Coach__3214EC27AC46CA0E",
                table: "Coach",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK__Class__3214EC279EF0D6B6",
                table: "Class",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK__Class__ProgramID__44FF419A",
                table: "Class",
                column: "ProgramID",
                principalTable: "Program",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK__InBodyTes__Train__48CFD27E",
                table: "InBodyTest",
                column: "TraineeID",
                principalTable: "Trainee",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK__Program__CoachID__4222D4EF",
                table: "Program",
                column: "CoachID",
                principalTable: "Coach",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK__Trainee__ClassID__4AB81AF0",
                table: "Trainee",
                column: "ClassID",
                principalTable: "Class",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK__Trainee__CoachID__4BAC3F29",
                table: "Trainee",
                column: "CoachID",
                principalTable: "Coach",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK__Trainee__DietPla__49C3F6B7",
                table: "Trainee",
                column: "DietPlanID",
                principalTable: "DietPlan",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK__Trainee__Members__3F466844",
                table: "Trainee",
                column: "MembershipTypeID",
                principalTable: "MembershipType",
                principalColumn: "ID");
        }
    }
}
