using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.Infrastructure.Data.Migrations.EF
{
    /// <inheritdoc />
    public partial class InsertRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Roles 
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "Status", "Name", "NormalizedName", "ConcurrencyStamp", "Modified" },
                values: new object[,]
                {
                    // Sem essa permissão não mostra no menu
                    { 1, true, "config", "config".ToUpper(), Guid.NewGuid().ToString(), DateTime.Now }, 

                    // Crud usuarios
                    { 2, true, "config-user-list", "config-user-list".ToUpper(), Guid.NewGuid().ToString(), DateTime.Now },
                    { 3, true, "config-user-create", "config-user-create".ToUpper(), Guid.NewGuid().ToString(), DateTime.Now },
                    { 4, true, "config-user-edit", "config-user-edit".ToUpper(), Guid.NewGuid().ToString(), DateTime.Now },
                    { 5, true, "config-user-edit-password", "config-user-edit-password".ToUpper(), Guid.NewGuid().ToString(), DateTime.Now },
                    { 6, true, "config-user-delete", "config-user-delete".ToUpper(), Guid.NewGuid().ToString(), DateTime.Now },

                    { 7, true, "config-role-list", "config-role-list".ToUpper(), Guid.NewGuid().ToString(), DateTime.Now },
                    { 8, true, "config-role-create", "config-role-create".ToUpper(), Guid.NewGuid().ToString(), DateTime.Now },
                    { 9, true, "config-role-edit", "config-role-edit".ToUpper(), Guid.NewGuid().ToString(), DateTime.Now },
                    { 10, true, "config-role-delete", "config-role-delete".ToUpper(), Guid.NewGuid().ToString(), DateTime.Now },
                }
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
