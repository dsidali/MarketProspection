using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketProspection.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpworkSuiviTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UpworkSuivis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProposalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequiredConnects = table.Column<int>(type: "int", nullable: false),
                    Bid = table.Column<int>(type: "int", nullable: false),
                    ProjectLengthId = table.Column<int>(type: "int", nullable: false),
                    PricingTypeId = table.Column<int>(type: "int", nullable: false),
                    ClientPricing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pricing = table.Column<int>(type: "int", nullable: false),
                    SubmittingProfileId = table.Column<int>(type: "int", nullable: false),
                    JobLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TechnologyId = table.Column<int>(type: "int", nullable: false),
                    Viewed = table.Column<bool>(type: "bit", nullable: false),
                    ViewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Response = table.Column<bool>(type: "bit", nullable: false),
                    ResponseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Interview = table.Column<bool>(type: "bit", nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Hired = table.Column<bool>(type: "bit", nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UpworkSuivis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UpworkSuivis_PricingTypes_PricingTypeId",
                        column: x => x.PricingTypeId,
                        principalTable: "PricingTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UpworkSuivis_ProjectLengths_ProjectLengthId",
                        column: x => x.ProjectLengthId,
                        principalTable: "ProjectLengths",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UpworkSuivis_SubmittingProfiles_SubmittingProfileId",
                        column: x => x.SubmittingProfileId,
                        principalTable: "SubmittingProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UpworkSuivis_Technologies_TechnologyId",
                        column: x => x.TechnologyId,
                        principalTable: "Technologies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UpworkSuivis_PricingTypeId",
                table: "UpworkSuivis",
                column: "PricingTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_UpworkSuivis_ProjectLengthId",
                table: "UpworkSuivis",
                column: "ProjectLengthId");

            migrationBuilder.CreateIndex(
                name: "IX_UpworkSuivis_SubmittingProfileId",
                table: "UpworkSuivis",
                column: "SubmittingProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_UpworkSuivis_TechnologyId",
                table: "UpworkSuivis",
                column: "TechnologyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UpworkSuivis");
        }
    }
}
