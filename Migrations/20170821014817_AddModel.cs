using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IOTLabWebApi.Migrations
{
    public partial class AddModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ModelId",
                table: "Devices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Models",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AnalogInputPins = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    DigitalIOPins = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Microcontroller = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    MoreInfo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PWMDigitalIOPins = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Models", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Devices_ModelId",
                table: "Devices",
                column: "ModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devices_Models_ModelId",
                table: "Devices",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devices_Models_ModelId",
                table: "Devices");

            migrationBuilder.DropTable(
                name: "Models");

            migrationBuilder.DropIndex(
                name: "IX_Devices_ModelId",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "ModelId",
                table: "Devices");
        }
    }
}
