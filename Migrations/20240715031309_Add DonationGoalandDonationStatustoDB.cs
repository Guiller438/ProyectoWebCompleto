using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IW7PP.Migrations
{
    /// <inheritdoc />
    public partial class AddDonationGoalandDonationStatustoDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("2dae067d-6c3d-4f8e-b3f3-483a8533018f"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("483d0c9a-1eb3-48c3-904b-216605da822e"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("6a6f43be-f71d-4ed9-a512-55d1f5d7fb55"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("6e5d7e10-9965-4fe4-9710-541771a3ffc5"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("726032b7-2ba7-4bf0-b9c9-ec0f80a0f8c6"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("72817246-52b0-4dfc-8f73-ac1cea389920"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("8325217a-f6f9-4dbf-a9af-dee84de8b134"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("9fdbf2de-7e96-4a2b-a6ce-919771370e64"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("a62ecd08-8a7a-45ac-b8f8-4a0591407e24"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("ad5e417e-9d6c-4f07-8e00-4c0f2ddd089a"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("d50b111f-baed-46b0-83ba-99f86f5d3020"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("eb200c07-2140-4188-b6a0-5df2d57035f9"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("f50e6372-5eca-438a-9531-3185efd7d6ba"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("399ae274-a9dd-4e1a-a435-10c253a63656"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("74b031da-f6a8-4f4e-9369-074709cf2cfd"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("8be1bf1b-cdf7-4e75-a176-7470358e1455"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("b09e6d24-f6ed-4ebc-af07-738ce1f55a81"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("c85d09d2-8198-4a37-84a1-65f5770e348e"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("d24e8451-a681-4efb-9ec6-535d6dea6d32"));

            migrationBuilder.AddColumn<double>(
                name: "DonationGoal",
                table: "ClientesProtesicos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "DonationStatus",
                table: "ClientesProtesicos",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "Donaciones",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donaciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donaciones_ClientesProtesicos_ClientId",
                        column: x => x.ClientId,
                        principalTable: "ClientesProtesicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LowerLimbAmputations",
                columns: new[] { "Id", "AmputationName" },
                values: new object[,]
                {
                    { new Guid("0c7c01f7-dfba-4e12-bf04-515fba8d9c6b"), "Transfemoral" },
                    { new Guid("25770321-f4a7-4ea9-8080-72134817d47b"), "AnkleDisarticulation" },
                    { new Guid("34bd7a89-317a-4896-a4fd-e4960a83489f"), "Chopart" },
                    { new Guid("47a33437-85b3-42ca-903c-5bfb721e4e00"), "HipDisarticulation" },
                    { new Guid("6670260f-8642-4bff-ab5d-bdb84e0fe4c8"), "Below Knee" },
                    { new Guid("86475f13-e322-4005-bbf3-4a6e35b063c2"), "Transtibial" },
                    { new Guid("89357f5b-21ef-47db-bf72-026a8a283985"), "FootPartial" },
                    { new Guid("8d07d801-534f-4797-bab9-aa15092137cc"), "KneeDisarticulation" },
                    { new Guid("b0c7e32a-9656-4b06-b341-31c5d1daff27"), "Hemipelvectomy" },
                    { new Guid("be30fa41-a407-4513-86df-fc324ec26b4f"), "Above Knee" },
                    { new Guid("ce308975-11ab-44fa-bb47-20c2dce23b01"), "ToePartial" },
                    { new Guid("e3dceca1-5770-475f-9fc9-09a6f4dc172b"), "ToeComplete" },
                    { new Guid("e9ca84ba-2062-4e9e-b8fc-b3cec97ecc32"), "Lisfranc" }
                });

            migrationBuilder.InsertData(
                table: "UpperLimbAmputations",
                columns: new[] { "Id", "AmputationName" },
                values: new object[,]
                {
                    { new Guid("351a6431-fe32-4093-b09b-b24bc9544d33"), "Wrist Disarticulation" },
                    { new Guid("54249b85-baa2-4b1a-a2bb-bc1fbbc13543"), "Elbow Disarticulation" },
                    { new Guid("55e86cce-be8a-4b7f-b1a5-8ca0e9519a8c"), "Finger Partial" },
                    { new Guid("92404917-a2ec-44f1-b174-158a03b4819f"), "Hand Partial" },
                    { new Guid("a5dae8da-f5be-4a45-84ef-5f9c5fc21da4"), "Transradial" },
                    { new Guid("dd696325-64b8-4f80-8f2a-549243511143"), "Finger Complete" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Donaciones_ClientId",
                table: "Donaciones",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donaciones");

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("0c7c01f7-dfba-4e12-bf04-515fba8d9c6b"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("25770321-f4a7-4ea9-8080-72134817d47b"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("34bd7a89-317a-4896-a4fd-e4960a83489f"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("47a33437-85b3-42ca-903c-5bfb721e4e00"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("6670260f-8642-4bff-ab5d-bdb84e0fe4c8"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("86475f13-e322-4005-bbf3-4a6e35b063c2"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("89357f5b-21ef-47db-bf72-026a8a283985"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("8d07d801-534f-4797-bab9-aa15092137cc"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("b0c7e32a-9656-4b06-b341-31c5d1daff27"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("be30fa41-a407-4513-86df-fc324ec26b4f"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("ce308975-11ab-44fa-bb47-20c2dce23b01"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("e3dceca1-5770-475f-9fc9-09a6f4dc172b"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("e9ca84ba-2062-4e9e-b8fc-b3cec97ecc32"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("351a6431-fe32-4093-b09b-b24bc9544d33"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("54249b85-baa2-4b1a-a2bb-bc1fbbc13543"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("55e86cce-be8a-4b7f-b1a5-8ca0e9519a8c"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("92404917-a2ec-44f1-b174-158a03b4819f"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("a5dae8da-f5be-4a45-84ef-5f9c5fc21da4"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("dd696325-64b8-4f80-8f2a-549243511143"));

            migrationBuilder.DropColumn(
                name: "DonationGoal",
                table: "ClientesProtesicos");

            migrationBuilder.DropColumn(
                name: "DonationStatus",
                table: "ClientesProtesicos");

            migrationBuilder.InsertData(
                table: "LowerLimbAmputations",
                columns: new[] { "Id", "AmputationName" },
                values: new object[,]
                {
                    { new Guid("2dae067d-6c3d-4f8e-b3f3-483a8533018f"), "Hemipelvectomy" },
                    { new Guid("483d0c9a-1eb3-48c3-904b-216605da822e"), "HipDisarticulation" },
                    { new Guid("6a6f43be-f71d-4ed9-a512-55d1f5d7fb55"), "Chopart" },
                    { new Guid("6e5d7e10-9965-4fe4-9710-541771a3ffc5"), "ToePartial" },
                    { new Guid("726032b7-2ba7-4bf0-b9c9-ec0f80a0f8c6"), "ToeComplete" },
                    { new Guid("72817246-52b0-4dfc-8f73-ac1cea389920"), "FootPartial" },
                    { new Guid("8325217a-f6f9-4dbf-a9af-dee84de8b134"), "Transfemoral" },
                    { new Guid("9fdbf2de-7e96-4a2b-a6ce-919771370e64"), "KneeDisarticulation" },
                    { new Guid("a62ecd08-8a7a-45ac-b8f8-4a0591407e24"), "Above Knee" },
                    { new Guid("ad5e417e-9d6c-4f07-8e00-4c0f2ddd089a"), "Below Knee" },
                    { new Guid("d50b111f-baed-46b0-83ba-99f86f5d3020"), "AnkleDisarticulation" },
                    { new Guid("eb200c07-2140-4188-b6a0-5df2d57035f9"), "Transtibial" },
                    { new Guid("f50e6372-5eca-438a-9531-3185efd7d6ba"), "Lisfranc" }
                });

            migrationBuilder.InsertData(
                table: "UpperLimbAmputations",
                columns: new[] { "Id", "AmputationName" },
                values: new object[,]
                {
                    { new Guid("399ae274-a9dd-4e1a-a435-10c253a63656"), "Hand Partial" },
                    { new Guid("74b031da-f6a8-4f4e-9369-074709cf2cfd"), "Wrist Disarticulation" },
                    { new Guid("8be1bf1b-cdf7-4e75-a176-7470358e1455"), "Elbow Disarticulation" },
                    { new Guid("b09e6d24-f6ed-4ebc-af07-738ce1f55a81"), "Finger Partial" },
                    { new Guid("c85d09d2-8198-4a37-84a1-65f5770e348e"), "Finger Complete" },
                    { new Guid("d24e8451-a681-4efb-9ec6-535d6dea6d32"), "Transradial" }
                });
        }
    }
}
