using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SearchFill.Migrations
{
    public partial class search3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 

            migrationBuilder.CreateTable(
                name: "UserRs",
                columns: table => new
                {
                    UserName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRs", x => x.UserName);
                });

            migrationBuilder.CreateTable(
                name: "Connections",
                columns: table => new
                {
                    ConnectionID = table.Column<string>(nullable: false),
                    UserAgent = table.Column<string>(nullable: true),
                    Connected = table.Column<bool>(nullable: false),
                    UserRUserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Connections", x => x.ConnectionID);
                    table.ForeignKey(
                        name: "FK_Connections_UserRs_UserRUserName",
                        column: x => x.UserRUserName,
                        principalTable: "UserRs",
                        principalColumn: "UserName",
                        onDelete: ReferentialAction.Restrict);
                });

  
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
