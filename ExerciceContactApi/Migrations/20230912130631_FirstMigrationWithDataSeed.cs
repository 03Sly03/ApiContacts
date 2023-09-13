using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExerciceContactApi.Migrations
{
    public partial class FirstMigrationWithDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fullname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Avatar", "Firstname", "Fullname", "Lastname", "Sexe" },
                values: new object[] { 1, "https://sm.ign.com/ign_fr/cover/a/avatar-gen/avatar-generations_bssq.jpg", "Babouche", "Babouche Mig", "Mig", "M" });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Avatar", "Firstname", "Fullname", "Lastname", "Sexe" },
                values: new object[] { 2, "https://media.gqmagazine.fr/photos/63c9247a35fc113fac34f877/16:9/w_1280,c_limit/maxresdefault.jpg", "King", "King Kong", "Kong", "M" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
