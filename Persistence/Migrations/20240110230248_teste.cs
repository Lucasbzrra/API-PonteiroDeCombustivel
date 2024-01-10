using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class teste : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdFuel = table.Column<int>(type: "int", nullable: false),
                    QuantityOfLiters = table.Column<double>(type: "float", nullable: false),
                    typeFuel = table.Column<int>(type: "int", nullable: false),
                    ValuePerLiter = table.Column<double>(type: "float", nullable: false),
                    SupplyDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    departureLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    destinationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Vehicleid = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateUpdate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateDeleted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Fuels", x => x.id);
                    table.ForeignKey(
                        name: "FK_Tb_Fuels_Tb_Vehicles_Vehicleid",
                        column: x => x.Vehicleid,
                        principalTable: "Tb_Vehicles",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Tb_DepartureLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferencePoint = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_DepartureLocations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_DepartureLocations_Tb_Fuels_FuelId",
                        column: x => x.FuelId,
                        principalTable: "Tb_Fuels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Destinations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FuelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UF = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferencePoint = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Destinations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Destinations_Tb_Fuels_FuelId",
                        column: x => x.FuelId,
                        principalTable: "Tb_Fuels",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_DepartureLocations_FuelId",
                table: "Tb_DepartureLocations",
                column: "FuelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Destinations_FuelId",
                table: "Tb_Destinations",
                column: "FuelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Fuels_IdFuel",
                table: "Tb_Fuels",
                column: "IdFuel",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Fuels_Vehicleid",
                table: "Tb_Fuels",
                column: "Vehicleid");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Vehicles_Plate",
                table: "Tb_Vehicles",
                column: "Plate",
                unique: true);

            migrationBuilder.Sql("CREATE VIEW vw_CostofFuel AS SELECT A.QuantityOfLiters * A.ValuePerLiter AS TotalCost FROM Tb_Fuels AS A; ");

            migrationBuilder.Sql("CREATE VIEW vw_FuelConsumption AS SELECT A.QuantityOfLiters * B.KmPerLiter AS TotalkmToBeCovered FROM Tb_Fuels AS A JOIN Tb_Vehicles AS B ON A.Vehicleid = B.id;");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_DepartureLocations");

            migrationBuilder.DropTable(
                name: "Tb_Destinations");

            migrationBuilder.DropTable(
                name: "Tb_Fuels");

            migrationBuilder.DropTable(
                name: "Tb_Vehicles");

            migrationBuilder.Sql("vw_CostofFuel");

            migrationBuilder.Sql("vw_FuelConsumption");
        }
    }
}
