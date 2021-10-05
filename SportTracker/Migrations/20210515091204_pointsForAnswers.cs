using Microsoft.EntityFrameworkCore.Migrations;

namespace SportTracker.Migrations
{
    public partial class pointsForAnswers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "QuestionNumber",
                table: "QuestionnaireQuestions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<double>(
                name: "Points",
                table: "Answers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Points",
                table: "Answers");

            migrationBuilder.AlterColumn<int>(
                name: "QuestionNumber",
                table: "QuestionnaireQuestions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
