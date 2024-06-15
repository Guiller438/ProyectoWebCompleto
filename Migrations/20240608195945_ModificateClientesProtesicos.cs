using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IW7PP.Migrations
{
    /// <inheritdoc />
    public partial class ModificateClientesProtesicos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientesProtesicos_Prostheses_ProsthesisId",
                table: "ClientesProtesicos");

            migrationBuilder.DropIndex(
                name: "IX_ClientesProtesicos_ProsthesisId",
                table: "ClientesProtesicos");

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

            migrationBuilder.DropColumn(
                name: "ProsthesisId",
                table: "ClientesProtesicos");

            migrationBuilder.InsertData(
                table: "LowerLimbAmputations",
                columns: new[] { "Id", "AmputationName" },
                values: new object[,]
                {
                    { new Guid("39fbcf8b-345b-424b-bc58-b964d57688f0"), "Transtibial" },
                    { new Guid("3c294313-7d66-45d7-92db-5b2698647549"), "FootPartial" },
                    { new Guid("4f3ccd91-4b59-421d-942d-38c774154c5a"), "Above Knee" },
                    { new Guid("4fd51f44-cca3-47c2-b7a2-562caa13f621"), "Transfemoral" },
                    { new Guid("61c38a75-2a85-4794-adbc-64905f7a5097"), "KneeDisarticulation" },
                    { new Guid("6b8e74a5-0f23-4747-8606-3932f6460aa3"), "Below Knee" },
                    { new Guid("765c2165-54b3-4383-8773-1c2aeda1e71a"), "AnkleDisarticulation" },
                    { new Guid("8336c87b-1fba-44ef-8cbe-b1bb56fb083b"), "Lisfranc" },
                    { new Guid("8df8a5d8-faa3-443f-968a-4b355e8cc002"), "ToePartial" },
                    { new Guid("b97a5175-4379-4a42-8347-0cfeb9bb649b"), "Hemipelvectomy" },
                    { new Guid("d323f068-7725-46b2-a9c9-c1bfab541159"), "ToeComplete" },
                    { new Guid("e97134ee-b571-43cb-b071-e6c1fb1ff823"), "HipDisarticulation" },
                    { new Guid("f6d40f1d-8147-4c52-a4b2-750f6e518afd"), "Chopart" }
                });

            migrationBuilder.InsertData(
                table: "UpperLimbAmputations",
                columns: new[] { "Id", "AmputationName" },
                values: new object[,]
                {
                    { new Guid("1b8e7f90-c686-47ec-b2ca-5256302d7214"), "Transradial" },
                    { new Guid("85b2714c-b346-4f24-9a05-e0ca0749b825"), "Finger Complete" },
                    { new Guid("c6e65429-24a1-424a-baa9-acecd37169df"), "Wrist Disarticulation" },
                    { new Guid("d315167b-8462-40c7-b62e-6c0db10ad656"), "Finger Partial" },
                    { new Guid("d58a37aa-9aed-478b-9efd-959f82110f05"), "Hand Partial" },
                    { new Guid("dfb07944-12fb-45ed-b693-57bf8d1301fa"), "Elbow Disarticulation" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClientesProtesicos_ProtesisId",
                table: "ClientesProtesicos",
                column: "ProtesisId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesProtesicos_Prostheses_ProtesisId",
                table: "ClientesProtesicos",
                column: "ProtesisId",
                principalTable: "Prostheses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientesProtesicos_Prostheses_ProtesisId",
                table: "ClientesProtesicos");

            migrationBuilder.DropIndex(
                name: "IX_ClientesProtesicos_ProtesisId",
                table: "ClientesProtesicos");

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("39fbcf8b-345b-424b-bc58-b964d57688f0"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("3c294313-7d66-45d7-92db-5b2698647549"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("4f3ccd91-4b59-421d-942d-38c774154c5a"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("4fd51f44-cca3-47c2-b7a2-562caa13f621"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("61c38a75-2a85-4794-adbc-64905f7a5097"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("6b8e74a5-0f23-4747-8606-3932f6460aa3"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("765c2165-54b3-4383-8773-1c2aeda1e71a"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("8336c87b-1fba-44ef-8cbe-b1bb56fb083b"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("8df8a5d8-faa3-443f-968a-4b355e8cc002"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("b97a5175-4379-4a42-8347-0cfeb9bb649b"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("d323f068-7725-46b2-a9c9-c1bfab541159"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("e97134ee-b571-43cb-b071-e6c1fb1ff823"));

            migrationBuilder.DeleteData(
                table: "LowerLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("f6d40f1d-8147-4c52-a4b2-750f6e518afd"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("1b8e7f90-c686-47ec-b2ca-5256302d7214"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("85b2714c-b346-4f24-9a05-e0ca0749b825"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("c6e65429-24a1-424a-baa9-acecd37169df"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("d315167b-8462-40c7-b62e-6c0db10ad656"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("d58a37aa-9aed-478b-9efd-959f82110f05"));

            migrationBuilder.DeleteData(
                table: "UpperLimbAmputations",
                keyColumn: "Id",
                keyValue: new Guid("dfb07944-12fb-45ed-b693-57bf8d1301fa"));

            migrationBuilder.AddColumn<int>(
                name: "ProsthesisId",
                table: "ClientesProtesicos",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                name: "IX_ClientesProtesicos_ProsthesisId",
                table: "ClientesProtesicos",
                column: "ProsthesisId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientesProtesicos_Prostheses_ProsthesisId",
                table: "ClientesProtesicos",
                column: "ProsthesisId",
                principalTable: "Prostheses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
