using Microsoft.EntityFrameworkCore.Migrations;

namespace SportTracker.Migrations
{
    public partial class sportPlan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SportPlanId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SportPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DifficultyLevel = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    CaloriesPerWeek = table.Column<int>(type: "int", nullable: false),
                    SportZones = table.Column<int>(type: "int", nullable: false),
                    NumberOfSportsDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PlanWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WeekDay = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlannedDistance = table.Column<double>(type: "float", nullable: false),
                    PlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlanWorkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlanWorkouts_SportPlans_PlanId",
                        column: x => x.PlanId,
                        principalTable: "SportPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SportPlanId",
                table: "AspNetUsers",
                column: "SportPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_PlanWorkouts_PlanId",
                table: "PlanWorkouts",
                column: "PlanId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_SportPlans_SportPlanId",
                table: "AspNetUsers",
                column: "SportPlanId",
                principalTable: "SportPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_SportPlans_SportPlanId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "PlanWorkouts");

            migrationBuilder.DropTable(
                name: "SportPlans");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SportPlanId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SportPlanId",
                table: "AspNetUsers");
        }
    }
}
