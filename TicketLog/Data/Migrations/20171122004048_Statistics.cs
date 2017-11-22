using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TicketLog.Data.Migrations
{
    public partial class Statistics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Statistic");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Statistic",
                table: "Statistic",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Emails = table.Column<int>(nullable: false),
                    NewApplicaitons = table.Column<int>(nullable: false),
                    ToDo = table.Column<int>(nullable: false),
                    YearToDate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Statistic",
                table: "Statistic");

            migrationBuilder.RenameTable(
                name: "Statistic",
                newName: "Ticket");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ticket",
                table: "Ticket",
                column: "ID");
        }
    }
}
