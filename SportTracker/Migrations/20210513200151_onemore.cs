using Microsoft.EntityFrameworkCore.Migrations;

namespace SportTracker.Migrations
{
    public partial class onemore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerQuestion_Answers_AnswerId",
                table: "AnswerQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerQuestion_Questions_QuestionId",
                table: "AnswerQuestion");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerQuestion",
                table: "AnswerQuestion");

            migrationBuilder.RenameTable(
                name: "AnswerQuestion",
                newName: "AnswerQuestions");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerQuestion_QuestionId",
                table: "AnswerQuestions",
                newName: "IX_AnswerQuestions_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerQuestion_AnswerId",
                table: "AnswerQuestions",
                newName: "IX_AnswerQuestions_AnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerQuestions",
                table: "AnswerQuestions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerQuestions_Answers_AnswerId",
                table: "AnswerQuestions",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerQuestions_Questions_QuestionId",
                table: "AnswerQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AnswerQuestions_Answers_AnswerId",
                table: "AnswerQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_AnswerQuestions_Questions_QuestionId",
                table: "AnswerQuestions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AnswerQuestions",
                table: "AnswerQuestions");

            migrationBuilder.RenameTable(
                name: "AnswerQuestions",
                newName: "AnswerQuestion");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerQuestions_QuestionId",
                table: "AnswerQuestion",
                newName: "IX_AnswerQuestion_QuestionId");

            migrationBuilder.RenameIndex(
                name: "IX_AnswerQuestions_AnswerId",
                table: "AnswerQuestion",
                newName: "IX_AnswerQuestion_AnswerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AnswerQuestion",
                table: "AnswerQuestion",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerQuestion_Answers_AnswerId",
                table: "AnswerQuestion",
                column: "AnswerId",
                principalTable: "Answers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AnswerQuestion_Questions_QuestionId",
                table: "AnswerQuestion",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");
        }
    }
}
