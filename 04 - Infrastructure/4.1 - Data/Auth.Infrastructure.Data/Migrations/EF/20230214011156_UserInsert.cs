using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.Infrastructure.Data.Migrations.EF
{
    /// <inheritdoc />
    public partial class UserInsert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                USE [AuthAPI]
                GO
	                drop INDEX UserNameIndex ON AspNetUsers;
                GO               
            ");


            migrationBuilder.Sql(@"
                USE [AuthAPI]
                GO
	                INSERT INTO [dbo].[AspNetUsers] ([Status], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [Modified])
                         VALUES (1, 'gfmaurila', 'gfmaurila' ,'gfmaurila@gmail.com','gfmaurila@gmail.com' ,1 ,'AQAAAAIAAYagAAAAEPgSn4FLQQh6fa1gg+/JB0Qs8BPhkNmcdasDK/vj4VA4NyA5uU2c2cB6CCKef0bH6Q==' ,'Y62FAVRDQ36R57HZ544QUVJY6P5YSR4J' ,'4d296e19-5d87-44bd-a02c-8fff91d8419d' ,'51985623312' ,1 ,0 ,null ,1 ,0 , GETDATE())
                GO               
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
