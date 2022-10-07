using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnergyControl.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectricalEnergyMeters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    VerificationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricalEnergyMeters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PowerTransformers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    VerificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransformationRatio = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerTransformers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SettlementMeters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SettlementMeters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VoltageTransformers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    VerificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TransformationRatio = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoltageTransformers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subsidiaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OrganizationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subsidiaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subsidiaries_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConsumptionObjects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubsidiaryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsumptionObjects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsumptionObjects_Subsidiaries_SubsidiaryId",
                        column: x => x.SubsidiaryId,
                        principalTable: "Subsidiaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityMeasuringPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConsumptionObjectId = table.Column<int>(type: "int", nullable: true),
                    SettlementMeterId = table.Column<int>(type: "int", nullable: true),
                    ElectricalEnergyMeterId = table.Column<int>(type: "int", nullable: false),
                    PowerTransformerId = table.Column<int>(type: "int", nullable: false),
                    VoltageTransformerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityMeasuringPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricityMeasuringPoints_ConsumptionObjects_ConsumptionObjectId",
                        column: x => x.ConsumptionObjectId,
                        principalTable: "ConsumptionObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElectricityMeasuringPoints_ElectricalEnergyMeters_ElectricalEnergyMeterId",
                        column: x => x.ElectricalEnergyMeterId,
                        principalTable: "ElectricalEnergyMeters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectricityMeasuringPoints_PowerTransformers_PowerTransformerId",
                        column: x => x.PowerTransformerId,
                        principalTable: "PowerTransformers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectricityMeasuringPoints_SettlementMeters_SettlementMeterId",
                        column: x => x.SettlementMeterId,
                        principalTable: "SettlementMeters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ElectricityMeasuringPoints_VoltageTransformers_VoltageTransformerId",
                        column: x => x.VoltageTransformerId,
                        principalTable: "VoltageTransformers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ElectricitySupplyPoints",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxPower = table.Column<float>(type: "real", nullable: false),
                    ConsumptionObjectId = table.Column<int>(type: "int", nullable: false),
                    SettlementMeterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricitySupplyPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricitySupplyPoints_ConsumptionObjects_ConsumptionObjectId",
                        column: x => x.ConsumptionObjectId,
                        principalTable: "ConsumptionObjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ElectricitySupplyPoints_SettlementMeters_SettlementMeterId",
                        column: x => x.SettlementMeterId,
                        principalTable: "SettlementMeters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ElectricalEnergyMeters",
                columns: new[] { "Id", "Number", "Type", "VerificationDate" },
                values: new object[,]
                {
                    { 1, "FirstElectricalEnergyMeterNumber", 0, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "SecondElectricalEnergyMetersNumber", 1, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Address", "Name" },
                values: new object[] { 1, "DefaultAddress", "FirstOrganization" });

            migrationBuilder.InsertData(
                table: "PowerTransformers",
                columns: new[] { "Id", "Number", "TransformationRatio", "Type", "VerificationDate" },
                values: new object[,]
                {
                    { 1, "FirstPowerTransformerNumber", 1.5f, 0, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "SecondPowerTransformerNumber", 2.5f, 1, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "SettlementMeters",
                columns: new[] { "Id", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2017, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2017, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2018, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2018, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "VoltageTransformers",
                columns: new[] { "Id", "Number", "TransformationRatio", "Type", "VerificationDate" },
                values: new object[,]
                {
                    { 1, "FirstVoltageTransformerNumber", 0.5f, 2, new DateTime(2022, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "SecondVoltageTransformerNumber", 0.75f, 0, new DateTime(2023, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Subsidiaries",
                columns: new[] { "Id", "Address", "Name", "OrganizationId" },
                values: new object[] { 1, "DefaultAddress", "FirstSubsidiary", 1 });

            migrationBuilder.InsertData(
                table: "ConsumptionObjects",
                columns: new[] { "Id", "Address", "Name", "SubsidiaryId" },
                values: new object[] { 1, "DefaultAddress", "FirstConsumptionObject", 1 });

            migrationBuilder.InsertData(
                table: "ElectricityMeasuringPoints",
                columns: new[] { "Id", "ConsumptionObjectId", "ElectricalEnergyMeterId", "Name", "PowerTransformerId", "SettlementMeterId", "VoltageTransformerId" },
                values: new object[,]
                {
                    { 1, 1, 1, "FirstElectricityMeasuringPoint", 1, 1, 1 },
                    { 2, 1, 2, "SecondElectricityMeasuringPoint", 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ElectricitySupplyPoints",
                columns: new[] { "Id", "ConsumptionObjectId", "MaxPower", "Name", "SettlementMeterId" },
                values: new object[,]
                {
                    { 1, 1, 100f, "FirstElectricitySupplyPoint", 1 },
                    { 2, 1, 200f, "SecondElectricitySupplyPoint", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsumptionObjects_SubsidiaryId",
                table: "ConsumptionObjects",
                column: "SubsidiaryId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeasuringPoints_ConsumptionObjectId",
                table: "ElectricityMeasuringPoints",
                column: "ConsumptionObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeasuringPoints_ElectricalEnergyMeterId",
                table: "ElectricityMeasuringPoints",
                column: "ElectricalEnergyMeterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeasuringPoints_PowerTransformerId",
                table: "ElectricityMeasuringPoints",
                column: "PowerTransformerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeasuringPoints_SettlementMeterId",
                table: "ElectricityMeasuringPoints",
                column: "SettlementMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeasuringPoints_VoltageTransformerId",
                table: "ElectricityMeasuringPoints",
                column: "VoltageTransformerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ElectricitySupplyPoints_ConsumptionObjectId",
                table: "ElectricitySupplyPoints",
                column: "ConsumptionObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricitySupplyPoints_SettlementMeterId",
                table: "ElectricitySupplyPoints",
                column: "SettlementMeterId");

            migrationBuilder.CreateIndex(
                name: "IX_Subsidiaries_OrganizationId",
                table: "Subsidiaries",
                column: "OrganizationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricityMeasuringPoints");

            migrationBuilder.DropTable(
                name: "ElectricitySupplyPoints");

            migrationBuilder.DropTable(
                name: "ElectricalEnergyMeters");

            migrationBuilder.DropTable(
                name: "PowerTransformers");

            migrationBuilder.DropTable(
                name: "VoltageTransformers");

            migrationBuilder.DropTable(
                name: "ConsumptionObjects");

            migrationBuilder.DropTable(
                name: "SettlementMeters");

            migrationBuilder.DropTable(
                name: "Subsidiaries");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
