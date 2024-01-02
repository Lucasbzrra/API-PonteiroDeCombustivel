using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class upandodatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_DepartureLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferencePoint = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_DepartureLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Destinations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferencePoint = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Destinations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Vehicles",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plate = table.Column<string>(type: "char(7)", maxLength: 7, nullable: false),
                    KmPerLiter = table.Column<double>(type: "float", nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Vehicles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Fuels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QuantityOfLiters = table.Column<double>(type: "float", nullable: false),
                    typeFuel = table.Column<int>(type: "int", nullable: false),
                    ValuePerLiter = table.Column<double>(type: "float", nullable: false),
                    SupplyDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DepartureLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DestinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Fuels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Fuels_Tb_DepartureLocations_DepartureLocationId",
                        column: x => x.DepartureLocationId,
                        principalTable: "Tb_DepartureLocations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_Fuels_Tb_Destinations_DestinationId",
                        column: x => x.DestinationId,
                        principalTable: "Tb_Destinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tb_Fuels_Tb_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Tb_Vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Fuels_DepartureLocationId",
                table: "Tb_Fuels",
                column: "DepartureLocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Fuels_DestinationId",
                table: "Tb_Fuels",
                column: "DestinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Fuels_VehicleId",
                table: "Tb_Fuels",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Vehicles_Plate",
                table: "Tb_Vehicles",
                column: "Plate",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Fuels");

            migrationBuilder.DropTable(
                name: "Tb_DepartureLocations");

            migrationBuilder.DropTable(
                name: "Tb_Destinations");

            migrationBuilder.DropTable(
                name: "Tb_Vehicles");
        }
    }
}
