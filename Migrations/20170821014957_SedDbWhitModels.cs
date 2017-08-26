using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace IOTLabWebApi.Migrations
{
    public partial class SedDbWhitModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Models (Name,ImgUrl,MoreInfo,Microcontroller,DigitalIOPins,AnalogInputPins,PWMDigitalIOPins)" +
            " VALUES ('Arduino Uno','https://store-cdn.arduino.cc/usa/catalog/product/cache/1/image/1800x/ea1ef423b933d797cfca49bc5855eef6/A/0/A000066_front_2.jpg','https://store.arduino.cc/usa/arduino-uno-rev3','ATmega328P','14','6','6')");

            migrationBuilder.Sql("INSERT INTO Models (Name,ImgUrl,MoreInfo,Microcontroller,DigitalIOPins,AnalogInputPins,PWMDigitalIOPins)" +
" VALUES ('Arduino Nano','https://store-cdn.arduino.cc/usa/catalog/product/cache/1/image/1800x/ea1ef423b933d797cfca49bc5855eef6/A/0/A000005_front_2.jpg','https://store.arduino.cc/usa/arduino-nano','ATmega328','22','8','6')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Models WHERE Name IN ('Arduino Uno', 'Arduino Nano')");
        }
    }
}
