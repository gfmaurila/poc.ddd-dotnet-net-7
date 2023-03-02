using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.Infrastructure.Data.Migrations.EF
{
    /// <inheritdoc />
    public partial class AddUserRolesInserts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // permissões
            migrationBuilder.Sql(@"
                USE [AuthAPI]
                GO  
                    INSERT INTO [dbo].[AspNetUserRoles] (UserId, RoleId, Status, Modified, Discriminator)
                    (SELECT 1, 
                            Id as RoleId, 
	                        1, 
	                        Modified, 
	                        name as Discriminator
                    FROM [AuthAPI].[dbo].[AspNetRoles])
                GO               
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
