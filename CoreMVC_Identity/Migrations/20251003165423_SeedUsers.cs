using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoreMVC_Identity.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'fd2ba441-88cd-448b-9b09-ef946745e9fe', N'Admin', N'ADMIN', NULL)

INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName]) VALUES (N'088c2a9a-a324-46f4-ac50-f9769ac97670', N'admin@ya.ru', N'ADMIN@YA.RU', N'admin@ya.ru', N'ADMIN@YA.RU', 0, N'AQAAAAIAAYagAAAAEOQTCFd4F6eXeZfXc4AM02XCGXrkOyTbhmRvYb/0iy3OXxnFQWpVZ0CwyoikEulYog==', N'JREESKMOQDCJ5ZSPUTHOG6DM667Q2YPR', N'd13d5096-577d-4d19-b349-8bedfc6c96be', NULL, 0, 0, NULL, 1, 0, N'Alex', N'Petrov')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName]) VALUES (N'aa47afb3-b132-42fd-b1db-39cb47186908', N'ivan@ya.ru', N'IVAN@YA.RU', N'ivan@ya.ru', N'IVAN@YA.RU', 0, N'AQAAAAIAAYagAAAAEDOcv6icP0y0n9zGboKVd9Lgtv3Is0QCHJt7cYp3W3QljiR7G26z7rSm5aXsz8zaGg==', N'H2C4NU4GT7ZUUKRNJ7ZBQMOZXJ6TAQQ7', N'860a55e5-c1fc-482a-8e91-94884c11c0c1', NULL, 0, 0, NULL, 1, 0, N'Ivan', N'Kozlov')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'088c2a9a-a324-46f4-ac50-f9769ac97670', N'fd2ba441-88cd-448b-9b09-ef946745e9fe')

SET IDENTITY_INSERT [dbo].[AspNetUserClaims] ON
INSERT INTO [dbo].[AspNetUserClaims] ([Id], [UserId], [ClaimType], [ClaimValue]) VALUES (1, N'088c2a9a-a324-46f4-ac50-f9769ac97670', N'Position', N'Admin')
SET IDENTITY_INSERT [dbo].[AspNetUserClaims] OFF");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
