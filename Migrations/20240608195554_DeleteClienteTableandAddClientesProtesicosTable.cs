using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IW7PP.Migrations
{
    /// <inheritdoc />
    public partial class DeleteClienteTableandAddClientesProtesicosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("03f6120a-5fe8-434f-83e5-82e50a4ce438"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("1a506915-7368-4947-a28d-97228f344662"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("37fe1f4e-058b-449a-a321-0112ad782c3d"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("5975536c-9837-44b5-bdaf-24edee8fd7fa"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("5c237fc7-25e6-4f4e-8881-dd80131c6169"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("704d785e-d24c-4832-9697-ade07716289a"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("96b8e4c0-c19f-45d6-9040-26bc4ad5b545"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("96d2bf06-e884-4df4-9a53-a8eddee5694f"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("9d18904a-3cd0-4701-8555-08c015874463"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("e056bf8b-b140-419e-b921-e6d5c0b7ebf2"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("e396ded0-1035-4b56-9782-d943a0341fd5"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("e4f15b72-d015-48e9-ac59-3ba806c92993"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("eb2fdb82-7434-4e4d-bdca-c53c66ff18d9"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("0d371bc7-cfdc-4a25-8a3f-831b521236ac"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("191af8c8-378f-48c7-a2b0-d4eab05fc649"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("6674355c-74c7-431a-b255-41a6e15d3f1f"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("8fe2e47b-68c0-48cd-a5e5-36e54e4864c2"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("cf4275bf-76fb-4183-a55e-ffbedca1398b"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("ec7c2d2b-849e-4f30-a11a-166f38d1d757"));

            migrationBuilder.CreateTable(
                name: "ClientesProtesicos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ProtesisId = table.Column<int>(type: "int", nullable: false),
                    LifeStyleId = table.Column<int>(type: "int", nullable: false),
                    ProsthesisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientesProtesicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientesProtesicos_LifeStyles_LifeStyleId",
                        column: x => x.LifeStyleId,
                        principalTable: "LifeStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientesProtesicos_Prostheses_ProsthesisId",
                        column: x => x.ProsthesisId,
                        principalTable: "Prostheses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LowerLimbAmputations",
                columns: new[] { "Id", "AmputationName" },
                values: new object[,]
                {
                    { new Guid("280952f0-7597-4e21-8f0b-7e3e91d037dc"), "KneeDisarticulation" },
                    { new Guid("2a9ac8a8-f9f4-4c54-99a4-598fb599647e"), "FootPartial" },
                    { new Guid("30f57670-f2e9-44da-8740-bfcc204e2f34"), "AnkleDisarticulation" },
                    { new Guid("39c5177f-915b-4b85-adf7-e6024ead7380"), "HipDisarticulation" },
                    { new Guid("3e9df86a-fc49-4b3e-be04-691f37f82d41"), "Transfemoral" },
                    { new Guid("4d8bc7bf-6f70-4ec1-aee7-d9eb12758ed9"), "Hemipelvectomy" },
                    { new Guid("6c6fe8da-437d-47b7-b1db-3e7fbcf785f4"), "Above Knee" },
                    { new Guid("a80b771f-3180-4b02-ad52-d9f534192050"), "ToeComplete" },
                    { new Guid("c554d246-03a1-4450-9932-5aae776e0d90"), "Chopart" },
                    { new Guid("cada66a1-816a-4327-8e1f-42be8f60aaed"), "Lisfranc" },
                    { new Guid("d85fc3c6-6ece-4e34-8133-41b7c96e41f8"), "Below Knee" },
                    { new Guid("dc198b8b-b03b-489d-bf29-8233b653a5a1"), "ToePartial" },
                    { new Guid("f33f5e0d-0d1f-40bb-a4d9-1acd43ca71f1"), "Transtibial" }
                });

            migrationBuilder.InsertData(
                table: "UpperLimbAmputations",
                columns: new[] { "Id", "AmputationName" },
                values: new object[,]
                {
                    { new Guid("0458f6af-d3f7-4b46-9322-cccb850f6a58"), "Wrist Disarticulation" },
                    { new Guid("244b1eec-9d43-4fd2-9b64-5dfd0d7c955b"), "Hand Partial" },
                    { new Guid("279863d0-972c-4e73-a9da-db9893d92fcb"), "Finger Complete" },
                    { new Guid("afa73303-0747-4886-bc20-7bd78d1450f4"), "Finger Partial" },
                    { new Guid("c3285bb6-b165-4691-8dc9-2191fb6aacf2"), "Elbow Disarticulation" },
                    { new Guid("f02adbc5-13b2-4bcc-8eb5-3ce0201fcd27"), "Transradial" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientesProtesicos_LifeStyleId",
                table: "ClientesProtesicos",
                column: "LifeStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientesProtesicos_ProsthesisId",
                table: "ClientesProtesicos",
                column: "ProsthesisId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClientesProtesicos");

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("280952f0-7597-4e21-8f0b-7e3e91d037dc"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("2a9ac8a8-f9f4-4c54-99a4-598fb599647e"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("30f57670-f2e9-44da-8740-bfcc204e2f34"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("39c5177f-915b-4b85-adf7-e6024ead7380"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("3e9df86a-fc49-4b3e-be04-691f37f82d41"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("4d8bc7bf-6f70-4ec1-aee7-d9eb12758ed9"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("6c6fe8da-437d-47b7-b1db-3e7fbcf785f4"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("a80b771f-3180-4b02-ad52-d9f534192050"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("c554d246-03a1-4450-9932-5aae776e0d90"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("cada66a1-816a-4327-8e1f-42be8f60aaed"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("d85fc3c6-6ece-4e34-8133-41b7c96e41f8"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("dc198b8b-b03b-489d-bf29-8233b653a5a1"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("f33f5e0d-0d1f-40bb-a4d9-1acd43ca71f1"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("0458f6af-d3f7-4b46-9322-cccb850f6a58"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("244b1eec-9d43-4fd2-9b64-5dfd0d7c955b"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("279863d0-972c-4e73-a9da-db9893d92fcb"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("afa73303-0747-4886-bc20-7bd78d1450f4"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("c3285bb6-b165-4691-8dc9-2191fb6aacf2"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("f02adbc5-13b2-4bcc-8eb5-3ce0201fcd27"));

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LifeStyleId = table.Column<int>(type: "int", nullable: false),
                    ProsthesisId = table.Column<int>(type: "int", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProtesisId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_LifeStyles_LifeStyleId",
                        column: x => x.LifeStyleId,
                        principalTable: "LifeStyles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clientes_Prostheses_ProsthesisId",
                        column: x => x.ProsthesisId,
                        principalTable: "Prostheses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LowerLimbAmputations",
                columns: new[] { "Id", "AmputationName" },
                values: new object[,]
                {
                    { new Guid("03f6120a-5fe8-434f-83e5-82e50a4ce438"), "ToePartial" },
                    { new Guid("1a506915-7368-4947-a28d-97228f344662"), "FootPartial" },
                    { new Guid("37fe1f4e-058b-449a-a321-0112ad782c3d"), "Hemipelvectomy" },
                    { new Guid("5975536c-9837-44b5-bdaf-24edee8fd7fa"), "ToeComplete" },
                    { new Guid("5c237fc7-25e6-4f4e-8881-dd80131c6169"), "Below Knee" },
                    { new Guid("704d785e-d24c-4832-9697-ade07716289a"), "AnkleDisarticulation" },
                    { new Guid("96b8e4c0-c19f-45d6-9040-26bc4ad5b545"), "KneeDisarticulation" },
                    { new Guid("96d2bf06-e884-4df4-9a53-a8eddee5694f"), "Transfemoral" },
                    { new Guid("9d18904a-3cd0-4701-8555-08c015874463"), "Chopart" },
                    { new Guid("e056bf8b-b140-419e-b921-e6d5c0b7ebf2"), "Lisfranc" },
                    { new Guid("e396ded0-1035-4b56-9782-d943a0341fd5"), "HipDisarticulation" },
                    { new Guid("e4f15b72-d015-48e9-ac59-3ba806c92993"), "Transtibial" },
                    { new Guid("eb2fdb82-7434-4e4d-bdca-c53c66ff18d9"), "Above Knee" }
                });

            migrationBuilder.InsertData(
                table: "UpperLimbAmputations",
                columns: new[] { "Id", "AmputationName" },
                values: new object[,]
                {
                    { new Guid("0d371bc7-cfdc-4a25-8a3f-831b521236ac"), "Hand Partial" },
                    { new Guid("191af8c8-378f-48c7-a2b0-d4eab05fc649"), "Wrist Disarticulation" },
                    { new Guid("6674355c-74c7-431a-b255-41a6e15d3f1f"), "Finger Complete" },
                    { new Guid("8fe2e47b-68c0-48cd-a5e5-36e54e4864c2"), "Transradial" },
                    { new Guid("cf4275bf-76fb-4183-a55e-ffbedca1398b"), "Finger Partial" },
                    { new Guid("ec7c2d2b-849e-4f30-a11a-166f38d1d757"), "Elbow Disarticulation" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_LifeStyleId",
                table: "Clientes",
                column: "LifeStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ProsthesisId",
                table: "Clientes",
                column: "ProsthesisId");
        }
    }
}
