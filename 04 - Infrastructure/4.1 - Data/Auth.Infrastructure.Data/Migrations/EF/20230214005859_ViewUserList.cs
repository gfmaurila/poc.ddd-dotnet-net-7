using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auth.Infrastructure.Data.Migrations.EF
{
    /// <inheritdoc />
    public partial class ViewUserList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                USE [AuthAPI]
                GO

                /****** Object:  View [dbo].[ViewUserList]    Script Date: 25/01/2023 00:13:25 ******/
                SET ANSI_NULLS ON
                GO

                SET QUOTED_IDENTIFIER ON
                GO

                CREATE VIEW [dbo].[ViewUserList]
                AS
                SELECT        Id, Status, UserName, Email, PhoneNumber, Modified
                FROM          dbo.AspNetUsers
                GO                
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
