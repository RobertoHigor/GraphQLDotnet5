using Microsoft.EntityFrameworkCore.Migrations;

namespace GraphQL.Migrations
{
    public partial class AddCommands : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {           
            migrationBuilder.InsertData(
                "Commands",
                             columns: new[] { "HowTo", "CommandLine", "PlatformId" },
                values: new object[,]
                {
                    {"Build a project", "dotnet build", 1},
                    {"Run a project", "dotnet run", 1},
                    {"Start a docker compose file", "docker-compose up -d", 2},
                    {"Stop a docker compose file", "docker-compose down", 2},
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
