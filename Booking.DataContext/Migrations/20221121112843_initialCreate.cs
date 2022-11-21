using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Booking.DataContext.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Citta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Stato = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lat = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Long = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Citta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Utenti",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cognome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utenti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Strutture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CittaId = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Indirizzo = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strutture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Strutture_Citta_CittaId",
                        column: x => x.CittaId,
                        principalTable: "Citta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stanze",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StrutturaId = table.Column<int>(type: "int", nullable: false),
                    Capienza = table.Column<int>(type: "int", nullable: false),
                    CostoUnitario = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stanze", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stanze_Strutture_StrutturaId",
                        column: x => x.StrutturaId,
                        principalTable: "Strutture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disponibilita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StanzaId = table.Column<int>(type: "int", nullable: false),
                    Dal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Al = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disponibilita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disponibilita_Stanze_StanzaId",
                        column: x => x.StanzaId,
                        principalTable: "Stanze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prenotazioni",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtenteId = table.Column<int>(type: "int", nullable: false),
                    StanzaId = table.Column<int>(type: "int", nullable: false),
                    Dal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Al = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroPersone = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prenotazioni", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prenotazioni_Stanze_StanzaId",
                        column: x => x.StanzaId,
                        principalTable: "Stanze",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prenotazioni_Utenti_UtenteId",
                        column: x => x.UtenteId,
                        principalTable: "Utenti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Utenti",
                columns: new[] { "Id", "Cognome", "Email", "Nome" },
                values: new object[,]
                {
                    { 1, "Supremo", "admin@booking.com", "Admin" },
                    { 2, "Rossi", "giovanni.rossi@gmail.com", "Giovanni" },
                    { 3, "Verdi", "pietro.verdi@gmail.com", "Pietro" },
                    { 4, "Bianchi", "luca.bianchi@gmail.com", "Luca" },
                    { 5, "Neri", "matteo.neri@gmail.com", "Matteo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disponibilita_StanzaId",
                table: "Disponibilita",
                column: "StanzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazioni_StanzaId",
                table: "Prenotazioni",
                column: "StanzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Prenotazioni_UtenteId",
                table: "Prenotazioni",
                column: "UtenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Stanze_StrutturaId",
                table: "Stanze",
                column: "StrutturaId");

            migrationBuilder.CreateIndex(
                name: "IX_Strutture_CittaId",
                table: "Strutture",
                column: "CittaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disponibilita");

            migrationBuilder.DropTable(
                name: "Prenotazioni");

            migrationBuilder.DropTable(
                name: "Stanze");

            migrationBuilder.DropTable(
                name: "Utenti");

            migrationBuilder.DropTable(
                name: "Strutture");

            migrationBuilder.DropTable(
                name: "Citta");
        }
    }
}
