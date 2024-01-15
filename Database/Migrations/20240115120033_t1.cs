using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Database.Migrations
{
    /// <inheritdoc />
    public partial class t1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_charge_points",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    charge_point_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    username = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    password = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    client_cert_thumb = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    latitude = table.Column<double>(type: "double precision", nullable: false),
                    longitude = table.Column<double>(type: "double precision", nullable: false),
                    street = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    landmark = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    status = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tb_charge_points", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_connector_statuses",
                columns: table => new
                {
                    charge_point_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    connector_id = table.Column<int>(type: "integer", nullable: false),
                    connector_type_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    status_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    throughput = table.Column<int>(type: "integer", nullable: true),
                    meter_value_time = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    charge_rate_kw = table.Column<double>(type: "double precision", nullable: true),
                    meter_kwh = table.Column<double>(type: "double precision", nullable: true),
                    soc = table.Column<double>(type: "double precision", nullable: true),
                    transaction_id = table.Column<int>(type: "integer", nullable: true),
                    driver_user_id = table.Column<Guid>(type: "uuid", nullable: true),
                    driver_user_name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tb_connector_statuses", x => new { x.charge_point_id, x.connector_id });
                });

            migrationBuilder.CreateTable(
                name: "tb_connectors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    charge_point_id = table.Column<int>(type: "integer", nullable: false),
                    connector_id = table.Column<int>(type: "integer", nullable: false),
                    connector_type_id = table.Column<int>(type: "integer", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    throughput = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_tb_connectors", x => x.id);
                    table.ForeignKey(
                        name: "fk_tb_connectors_tb_charge_points_charge_point_id",
                        column: x => x.charge_point_id,
                        principalTable: "tb_charge_points",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_tb_charge_points_charge_point_id",
                table: "tb_charge_points",
                column: "charge_point_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_tb_charge_points_status",
                table: "tb_charge_points",
                column: "status");

            migrationBuilder.CreateIndex(
                name: "ix_tb_connectors_charge_point_id",
                table: "tb_connectors",
                column: "charge_point_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_connector_statuses");

            migrationBuilder.DropTable(
                name: "tb_connectors");

            migrationBuilder.DropTable(
                name: "tb_charge_points");
        }
    }
}
