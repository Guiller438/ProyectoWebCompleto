using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IW7PP.Migrations
{
    /// <inheritdoc />
    public partial class AddandSeedDataForAmputationsModelsProsthesisModelsandClienteModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feet",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Durability = table.Column<double>(type: "float", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KneeArticulates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Durability = table.Column<double>(type: "float", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KneeArticulates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LifeStyles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    promedioDesgaste = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeStyles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Liners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Durability = table.Column<double>(type: "float", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Liners", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LowerLimbAmputations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmputationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LowerLimbAmputations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sockets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Durability = table.Column<double>(type: "float", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sockets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tubes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Durability = table.Column<double>(type: "float", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tubes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnionSockets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Durability = table.Column<double>(type: "float", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnionSockets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UpperLimbAmputations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmputationName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpperLimbAmputations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prostheses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocketId = table.Column<int>(type: "int", nullable: true),
                    LinerId = table.Column<int>(type: "int", nullable: true),
                    TubeId = table.Column<int>(type: "int", nullable: true),
                    FootId = table.Column<int>(type: "int", nullable: true),
                    UnionSocketId = table.Column<int>(type: "int", nullable: true),
                    KneeArticulateId = table.Column<int>(type: "int", nullable: true),
                    UpperLimbAmputationsiD = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LowerLimbAmputationsiD = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Durability = table.Column<double>(type: "float", nullable: false),
                    AverageDurability = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prostheses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prostheses_Feet_FootId",
                        column: x => x.FootId,
                        principalTable: "Feet",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prostheses_KneeArticulates_KneeArticulateId",
                        column: x => x.KneeArticulateId,
                        principalTable: "KneeArticulates",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prostheses_Liners_LinerId",
                        column: x => x.LinerId,
                        principalTable: "Liners",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prostheses_LowerLimbAmputations_LowerLimbAmputationsiD",
                        column: x => x.LowerLimbAmputationsiD,
                        principalTable: "LowerLimbAmputations",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prostheses_Sockets_SocketId",
                        column: x => x.SocketId,
                        principalTable: "Sockets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prostheses_Tubes_TubeId",
                        column: x => x.TubeId,
                        principalTable: "Tubes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prostheses_UnionSockets_UnionSocketId",
                        column: x => x.UnionSocketId,
                        principalTable: "UnionSockets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Prostheses_UpperLimbAmputations_UpperLimbAmputationsiD",
                        column: x => x.UpperLimbAmputationsiD,
                        principalTable: "UpperLimbAmputations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProtesisId = table.Column<int>(type: "int", nullable: false),
                    ProsthesisId = table.Column<int>(type: "int", nullable: false),
                    LifeStyleId = table.Column<int>(type: "int", nullable: false)
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
                table: "Feet",
                columns: new[] { "Id", "Description", "Durability", "Name" },
                values: new object[,]
                {
                    { 1, "Foot 1 Description", 6.0, "Foot 1" },
                    { 2, "Foot 2 Description", 12.0, "Foot 2" },
                    { 3, "Foot 3 Description", 18.0, "Foot 3" },
                    { 4, "Foot 4 Description", 24.0, "Foot 4" },
                    { 5, "Foot 5 Description", 30.0, "Foot 5" }
                });

            migrationBuilder.InsertData(
                table: "KneeArticulates",
                columns: new[] { "Id", "Description", "Durability", "Name" },
                values: new object[,]
                {
                    { 1, "KneeArticulate 1 Description", 6.0, "KneeArticulate 1" },
                    { 2, "KneeArticulate 2 Description", 12.0, "KneeArticulate 2" },
                    { 3, "KneeArticulate 3 Description", 18.0, "KneeArticulate 3" },
                    { 4, "KneeArticulate 4 Description", 24.0, "KneeArticulate 4" },
                    { 5, "KneeArticulate 5 Description", 30.0, "KneeArticulate 5" }
                });

            migrationBuilder.InsertData(
                table: "LifeStyles",
                columns: new[] { "Id", "Description", "Name", "promedioDesgaste" },
                values: new object[,]
                {
                    { 1, "El estilo de vida sedentario implica baja actividad física y largos periodos sentados, a menudo por trabajo o uso de dispositivos", "Sedentary", 0.5 },
                    { 2, "Un estilo de vida activo incluye actividad física moderada y regular, con ejercicios de intensidad moderada", "Activo", 1.0 },
                    { 3, "El estilo de vida de un deportista se enfoca en alta actividad física y rendimiento, dedicando mucho tiempo al entrenamiento", "Deportista", 1.5 }
                });

            migrationBuilder.InsertData(
                table: "Liners",
                columns: new[] { "Id", "Description", "Durability", "Name" },
                values: new object[,]
                {
                    { 1, "Liner 1 Description", 6.0, "Liner 1" },
                    { 2, "Liner 2 Description", 12.0, "Liner 2" },
                    { 3, "Liner 3 Description", 18.0, "Liner 3" },
                    { 4, "Liner 4 Description", 24.0, "Liner 4" },
                    { 5, "Liner 5 Description", 30.0, "Liner 5" }
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
                table: "Sockets",
                columns: new[] { "Id", "Description", "Durability" },
                values: new object[,]
                {
                    { 1, "Socket 1", 6.0 },
                    { 2, "Socket 2", 12.0 },
                    { 3, "Socket 3", 18.0 },
                    { 4, "Socket 4", 24.0 },
                    { 5, "Socket 5", 30.0 }
                });

            migrationBuilder.InsertData(
                table: "Tubes",
                columns: new[] { "Id", "Description", "Durability", "Name" },
                values: new object[,]
                {
                    { 1, "Tube 1 Description", 6.0, "Tube 1" },
                    { 2, "Tube 2 Description", 12.0, "Tube 2" },
                    { 3, "Tube 3 Description", 18.0, "Tube 3" },
                    { 4, "Tube 4 Description", 24.0, "Tube 4" },
                    { 5, "Tube 5 Description", 30.0, "Tube 5" }
                });

            migrationBuilder.InsertData(
                table: "UnionSockets",
                columns: new[] { "Id", "Description", "Durability", "Name" },
                values: new object[,]
                {
                    { 1, "UnionSocket 1 Description", 6.0, "UnionSocket 1" },
                    { 2, "UnionSocket 2 Description", 12.0, "UnionSocket 2" },
                    { 3, "UnionSocket 3 Description", 18.0, "UnionSocket 3" },
                    { 4, "UnionSocket 4 Description", 24.0, "UnionSocket 4" },
                    { 5, "UnionSocket 5 Description", 30.0, "UnionSocket 5" }
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

            migrationBuilder.CreateIndex(
                name: "IX_Prostheses_FootId",
                table: "Prostheses",
                column: "FootId");

            migrationBuilder.CreateIndex(
                name: "IX_Prostheses_KneeArticulateId",
                table: "Prostheses",
                column: "KneeArticulateId");

            migrationBuilder.CreateIndex(
                name: "IX_Prostheses_LinerId",
                table: "Prostheses",
                column: "LinerId");

            migrationBuilder.CreateIndex(
                name: "IX_Prostheses_LowerLimbAmputationsiD",
                table: "Prostheses",
                column: "LowerLimbAmputationsiD");

            migrationBuilder.CreateIndex(
                name: "IX_Prostheses_SocketId",
                table: "Prostheses",
                column: "SocketId");

            migrationBuilder.CreateIndex(
                name: "IX_Prostheses_TubeId",
                table: "Prostheses",
                column: "TubeId");

            migrationBuilder.CreateIndex(
                name: "IX_Prostheses_UnionSocketId",
                table: "Prostheses",
                column: "UnionSocketId");

            migrationBuilder.CreateIndex(
                name: "IX_Prostheses_UpperLimbAmputationsiD",
                table: "Prostheses",
                column: "UpperLimbAmputationsiD");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "LifeStyles");

            migrationBuilder.DropTable(
                name: "Prostheses");

            migrationBuilder.DropTable(
                name: "Feet");

            migrationBuilder.DropTable(
                name: "KneeArticulates");

            migrationBuilder.DropTable(
                name: "Liners");

            migrationBuilder.DropTable(
                name: "LowerLimbAmputations");

            migrationBuilder.DropTable(
                name: "Sockets");

            migrationBuilder.DropTable(
                name: "Tubes");

            migrationBuilder.DropTable(
                name: "UnionSockets");

            migrationBuilder.DropTable(
                name: "UpperLimbAmputations");
        }
    }
}
