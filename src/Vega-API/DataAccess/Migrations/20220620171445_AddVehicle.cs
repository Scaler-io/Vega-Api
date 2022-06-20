using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vega_API.DataAccess.Migrations
{
    public partial class AddVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VegaVehicles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    ModelId1 = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsRegistered = table.Column<bool>(type: "bit", nullable: false),
                    Contact_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contact_Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VegaVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VegaVehicles_VegaModels_ModelId1",
                        column: x => x.ModelId1,
                        principalTable: "VegaModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VegaVehicleFeatures",
                columns: table => new
                {
                    VehicleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VegaVehicleFeatures", x => new { x.VehicleId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_VegaVehicleFeatures_Features_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Features",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VegaVehicleFeatures_VegaVehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "VegaVehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VegaVehicleFeatures_FeatureId",
                table: "VegaVehicleFeatures",
                column: "FeatureId");

            migrationBuilder.CreateIndex(
                name: "IX_VegaVehicles_ModelId1",
                table: "VegaVehicles",
                column: "ModelId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VegaVehicleFeatures");

            migrationBuilder.DropTable(
                name: "VegaVehicles");
        }
    }
}
