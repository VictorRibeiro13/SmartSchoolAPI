using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchool.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Registration = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    BirthdayDate = table.Column<DateTime>(nullable: false),
                    InitialDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Registration = table.Column<int>(nullable: false),
                    InitialDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Active = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentsCourses",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    InitialDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Grade = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsCourses", x => new { x.StudentId, x.CourseId });
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UpdatedAt = table.Column<DateTime>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Workload = table.Column<int>(nullable: false),
                    TeacherId = table.Column<int>(nullable: false),
                    CourseId = table.Column<int>(nullable: false),
                    PrerequisiteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subjects_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subjects_Subjects_PrerequisiteId",
                        column: x => x.PrerequisiteId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Subjects_Teachers_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "Teachers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentsSubjects",
                columns: table => new
                {
                    StudentId = table.Column<int>(nullable: false),
                    SubjectId = table.Column<int>(nullable: false),
                    InitialDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: true),
                    Grade = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentsSubjects", x => new { x.StudentId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_StudentsSubjects_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentsSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 22, 20, 53, 18, 671, DateTimeKind.Local).AddTicks(8709), "Tecnologia da Informação", new DateTime(2021, 8, 22, 20, 53, 18, 671, DateTimeKind.Local).AddTicks(8627) },
                    { 2, new DateTime(2021, 8, 22, 20, 53, 18, 671, DateTimeKind.Local).AddTicks(9437), "Sistemas de Informação", new DateTime(2021, 8, 22, 20, 53, 18, 671, DateTimeKind.Local).AddTicks(9429) },
                    { 3, new DateTime(2021, 8, 22, 20, 53, 18, 671, DateTimeKind.Local).AddTicks(9453), "Ciência da Computação", new DateTime(2021, 8, 22, 20, 53, 18, 671, DateTimeKind.Local).AddTicks(9451) }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Active", "BirthdayDate", "CreatedAt", "EndDate", "InitialDate", "LastName", "Name", "Phone", "Registration", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, false, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(2290), null, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(2267), "Kent", "Marta", "33225555", 1, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(2288) },
                    { 2, false, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(4546), null, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(4540), "Isabela", "Paula", "3354288", 2, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(4544) },
                    { 3, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(4616), null, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(4614), "Antonia", "Laura", "55668899", 3, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(4615) },
                    { 4, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(4626), null, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(4623), "Maria", "Luiza", "6565659", 4, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(4625) },
                    { 5, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(4634), null, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(4631), "Machado", "Lucas", "565685415", 5, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(4633) },
                    { 6, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(4645), null, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(4643), "Alvares", "Pedro", "456454545", 6, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(4644) },
                    { 7, true, new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(4653), null, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(4651), "José", "Paulo", "9874512", 7, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(4652) }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "Active", "CreatedAt", "EndDate", "InitialDate", "LastName", "Name", "Phone", "Registration", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2021, 8, 22, 20, 53, 18, 670, DateTimeKind.Local).AddTicks(1392), null, new DateTime(2021, 8, 22, 20, 53, 18, 669, DateTimeKind.Local).AddTicks(4398), "Oliveira", "Lauro", null, 1, new DateTime(2021, 8, 22, 20, 53, 18, 670, DateTimeKind.Local).AddTicks(1371) },
                    { 2, true, new DateTime(2021, 8, 22, 20, 53, 18, 670, DateTimeKind.Local).AddTicks(2903), null, new DateTime(2021, 8, 22, 20, 53, 18, 670, DateTimeKind.Local).AddTicks(2887), "Soares", "Roberto", null, 2, new DateTime(2021, 8, 22, 20, 53, 18, 670, DateTimeKind.Local).AddTicks(2902) },
                    { 3, true, new DateTime(2021, 8, 22, 20, 53, 18, 670, DateTimeKind.Local).AddTicks(2938), null, new DateTime(2021, 8, 22, 20, 53, 18, 670, DateTimeKind.Local).AddTicks(2936), "Marconi", "Ronaldo", null, 3, new DateTime(2021, 8, 22, 20, 53, 18, 670, DateTimeKind.Local).AddTicks(2937) },
                    { 4, true, new DateTime(2021, 8, 22, 20, 53, 18, 670, DateTimeKind.Local).AddTicks(2943), null, new DateTime(2021, 8, 22, 20, 53, 18, 670, DateTimeKind.Local).AddTicks(2941), "Carvalho", "Rodrigo", null, 4, new DateTime(2021, 8, 22, 20, 53, 18, 670, DateTimeKind.Local).AddTicks(2942) },
                    { 5, true, new DateTime(2021, 8, 22, 20, 53, 18, 670, DateTimeKind.Local).AddTicks(2948), null, new DateTime(2021, 8, 22, 20, 53, 18, 670, DateTimeKind.Local).AddTicks(2945), "Montanha", "Alexandre", null, 5, new DateTime(2021, 8, 22, 20, 53, 18, 670, DateTimeKind.Local).AddTicks(2947) }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "Id", "CourseId", "CreatedAt", "Name", "PrerequisiteId", "TeacherId", "UpdatedAt", "Workload" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(2054), "Matemática", null, 1, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(2040), 0 },
                    { 2, 3, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(3557), "Matemática", null, 1, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(3547), 0 },
                    { 3, 3, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(3601), "Física", null, 2, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(3600), 0 },
                    { 4, 1, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(3605), "Português", null, 3, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(3603), 0 },
                    { 5, 1, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(3608), "Inglês", null, 4, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(3606), 0 },
                    { 6, 2, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(3619), "Inglês", null, 4, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(3617), 0 },
                    { 7, 3, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(3622), "Inglês", null, 4, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(3621), 0 },
                    { 8, 1, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(3625), "Programação", null, 5, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(3623), 0 },
                    { 9, 2, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(3628), "Programação", null, 5, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(3626), 0 },
                    { 10, 3, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(3632), "Programação", null, 5, new DateTime(2021, 8, 22, 20, 53, 18, 672, DateTimeKind.Local).AddTicks(3631), 0 }
                });

            migrationBuilder.InsertData(
                table: "StudentsSubjects",
                columns: new[] { "StudentId", "SubjectId", "EndDate", "Grade", "InitialDate" },
                values: new object[,]
                {
                    { 2, 1, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7223) },
                    { 4, 5, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7242) },
                    { 2, 5, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7230) },
                    { 1, 5, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7221) },
                    { 7, 4, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7261) },
                    { 6, 4, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7254) },
                    { 5, 4, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7243) },
                    { 4, 4, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7240) },
                    { 1, 4, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7181) },
                    { 7, 3, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7259) },
                    { 5, 5, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7245) },
                    { 6, 3, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7250) },
                    { 7, 2, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7258) },
                    { 6, 2, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7248) },
                    { 3, 2, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7233) },
                    { 2, 2, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7225) },
                    { 1, 2, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(6456) },
                    { 7, 1, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7256) },
                    { 6, 1, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7247) },
                    { 4, 1, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7238) },
                    { 3, 1, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7232) },
                    { 3, 3, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7235) },
                    { 7, 5, null, 0, new DateTime(2021, 8, 22, 20, 53, 18, 674, DateTimeKind.Local).AddTicks(7263) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentsCourses_CourseId",
                table: "StudentsCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentsSubjects_SubjectId",
                table: "StudentsSubjects",
                column: "SubjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_CourseId",
                table: "Subjects",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_PrerequisiteId",
                table: "Subjects",
                column: "PrerequisiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Subjects_TeacherId",
                table: "Subjects",
                column: "TeacherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentsCourses");

            migrationBuilder.DropTable(
                name: "StudentsSubjects");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
