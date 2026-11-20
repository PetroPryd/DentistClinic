using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Clinic.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clinic_settings",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    logo_url = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    primary_color = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    accent_color = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false),
                    address = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    city = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    postal_code = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    country_code = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: false),
                    phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    email = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    map_embed_url = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    time_zone_id = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    default_language_code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    slot_minutes = table.Column<int>(type: "integer", nullable: false),
                    buffer_minutes = table.Column<int>(type: "integer", nullable: false),
                    max_booking_days_ahead = table.Column<int>(type: "integer", nullable: false),
                    cancellation_cutoff_hours = table.Column<int>(type: "integer", nullable: false),
                    max_group_size = table.Column<int>(type: "integer", nullable: false),
                    verification_window_minutes = table.Column<int>(type: "integer", nullable: false),
                    first_reminder_hours = table.Column<int>(type: "integer", nullable: false),
                    second_reminder_hours = table.Column<int>(type: "integer", nullable: false),
                    sms_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    max_active_waitlist_entries = table.Column<int>(type: "integer", nullable: false),
                    is_demo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_clinic_settings", x => x.id);
                    table.CheckConstraint("ck_clinic_settings_single_row", "id = 1");
                    table.CheckConstraint("ck_clinic_settings_values", "slot_minutes > 0 AND buffer_minutes >= 0 AND max_group_size >= 1 AND first_reminder_hours > second_reminder_hours AND second_reminder_hours > 0");
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    code = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    native_name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    is_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    is_default = table.Column<bool>(type: "boolean", nullable: false),
                    sort_order = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_languages", x => x.code);
                });

            migrationBuilder.CreateIndex(
                name: "ix_languages_is_default",
                table: "languages",
                column: "is_default",
                unique: true,
                filter: "is_default");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clinic_settings");

            migrationBuilder.DropTable(
                name: "languages");
        }
    }
}
