using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailMagician.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bars",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 70, nullable: false),
                    Address = table.Column<string>(maxLength: 120, nullable: false),
                    Rating = table.Column<double>(nullable: true),
                    IsHidden = table.Column<bool>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bars", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cocktails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 70, nullable: false),
                    Recipe = table.Column<string>(maxLength: 700, nullable: false),
                    Rating = table.Column<double>(nullable: true),
                    IsHidden = table.Column<bool>(nullable: false),
                    ImagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cocktails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserEntityId = table.Column<string>(nullable: false),
                    BarEntityId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Review = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BarReviews_Bars_BarEntityId",
                        column: x => x.BarEntityId,
                        principalTable: "Bars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BarReviews_AspNetUsers_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BarCocktails",
                columns: table => new
                {
                    BarEntityId = table.Column<int>(nullable: false),
                    CocktailEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarCocktails", x => new { x.BarEntityId, x.CocktailEntityId });
                    table.ForeignKey(
                        name: "FK_BarCocktails_Bars_BarEntityId",
                        column: x => x.BarEntityId,
                        principalTable: "Bars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BarCocktails_Cocktails_CocktailEntityId",
                        column: x => x.CocktailEntityId,
                        principalTable: "Cocktails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CocktailReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserEntityId = table.Column<string>(nullable: false),
                    CocktailEntityId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Review = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktailReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CocktailReviews_Cocktails_CocktailEntityId",
                        column: x => x.CocktailEntityId,
                        principalTable: "Cocktails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CocktailReviews_AspNetUsers_UserEntityId",
                        column: x => x.UserEntityId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CocktaiIngredients",
                columns: table => new
                {
                    CocktailEntityId = table.Column<int>(nullable: false),
                    IngredientEntityId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CocktaiIngredients", x => new { x.IngredientEntityId, x.CocktailEntityId });
                    table.ForeignKey(
                        name: "FK_CocktaiIngredients_Cocktails_CocktailEntityId",
                        column: x => x.CocktailEntityId,
                        principalTable: "Cocktails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CocktaiIngredients_Ingredients_IngredientEntityId",
                        column: x => x.IngredientEntityId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5197310d-5d42-4337-bb59-2fd06e6a8fcd", "a3bc9d45-276b-442f-bc6b-b1a5763df30d", "User", "USER" },
                    { "959596e5-93e4-4272-8cfb-6e71a4254370", "20d35162-b35c-4b2e-80c1-81a15bc1b2f3", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "dd6561c5-0244-4303-974b-bb9cdfc79d9a", 0, "02257977-cd98-4987-890c-e043e5b11b7a", "user@user.com", false, false, null, "PESHO@PORN.COM", "USER@USER.COM", "AQAAAAEAACcQAAAAEHjrAvA0Ww9M6riqiuVTSSn+bp0or8KFufgIuHh2t5MQBA3S7/O6xG3R3x33IbChyg==", null, false, "7ESQYUICWBMY6LMQNHL7NOCQOF5V7ZNN", false, "user@user.com" },
                    { "3e4aab82-7dc1-4541-99e4-ade2523d95e9", 0, "7860d092-2b7b-43f7-b786-b094814c32a5", "admin@admin.com", false, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEPCgsKRJwJYsdiLjYUmnceNDmjGwBHAv2cWSFmPxWO6Nhdgcea6ae6Pema7tRusF+w==", null, false, "WDVY5A55O3W647HQWFALI6XUL3HGXVH5", false, "admin@admin.com" }
                });

            migrationBuilder.InsertData(
                table: "Bars",
                columns: new[] { "Id", "Address", "ImagePath", "IsHidden", "Name", "Rating" },
                values: new object[,]
                {
                    { 6, "1313  Jerome Avenue, Harlingen, Texas", null, false, "The Lion and Unicorn ", null },
                    { 1, "3483  Stratford Court, Fayetteville, North Carolina", "/images/bars/bar1.jpg", false, "Ace of Clubs", 4.5 },
                    { 3, "3292  Oak Lane, Jamesport, Missouri", null, false, "The Brass Lantern", 4.0 },
                    { 5, "3710  Hall Valley Drive, Stonewood, West Virginia", null, false, "Dexter Lake Club", 5.0 },
                    { 4, "1957  Braxton Street, Momence, Illinois", null, false, "Blue Boar Inn", 1.0 },
                    { 2, "3234  Mesa Drive, Las Vegas, Nevada", "/images/bars/bar2.jpg", false, "The Back Lane Bar", null }
                });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "ImagePath", "IsHidden", "Name", "Rating", "Recipe" },
                values: new object[,]
                {
                    { 7, "/images/cocktails/cocaColaSpice.jpg", false, "Coca-Cola Spice", null, "Add Coca-Cola, pineapple juice and Pibb Xtra to make a non-alcoholic take on a traditional holiday beverage." },
                    { 1, "/images/cocktails/blackRussian.jpg", false, "Black Russian", 5.0, "Pour the ingredients directly in a lowball glass with ice. Top up with coke. Stir and serve. Simple - yet a classic." },
                    { 5, "/images/cocktails/caribbeanSunsetMocktail.jpg", false, "Carribean Sunset Mocktail", null, "No one will miss the alcohol in this tasty family-friendly drink combining Sprite, orange juice, lemonade and grenadine" },
                    { 4, null, false, "Iceberg Paralyzer", 3.0, "Fill tall glass with ice to the top before adding the vodka and Kaluha. Next add the coke nearly to the top before adding in the milk to finish. Stir with a barspoon. Just remember to add a lot of ice or the milk can curdle with the coke." },
                    { 3, "/images/cocktails/cubaLibre.jpg", false, "Cuba Libre", 1.0, "Add the rum and lime juice into a highball glass with ice. Stir and top up with coke." },
                    { 2, "/images/cocktails/whiskeyAndCoke.jpg", false, "Whiskey And Coke", 4.0, "A classic combo, simply add the whisky into the bottom of a lowball glass with some ice cubes, then top up with the desired amount of coke. Classic and simple yet tasty!" },
                    { 6, "/images/cocktails/longIslandIcedTea.jpg", false, "Long Island Iced Tea Mocktail", 4.5, "Coca-Cola, lemonade and black tea give this signature drink the taste of the original without the alcohol." }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 13, "Black Tea" },
                    { 18, "Yogurt" },
                    { 17, "Fanta" },
                    { 16, "Club Soda" },
                    { 15, "Pibb Xtra" },
                    { 14, "Pineapple Juice" },
                    { 12, "Grenadine" },
                    { 8, "Vodka" },
                    { 10, "Orange Juice" },
                    { 9, "Sprite" },
                    { 7, "Whiskey" },
                    { 6, "White Rum" },
                    { 4, "Milk" },
                    { 3, "Lime Juice" },
                    { 2, "Coffee Liqueur" },
                    { 1, "Coca-Cola" },
                    { 11, "Lemonade" },
                    { 5, "Kahlua" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { "dd6561c5-0244-4303-974b-bb9cdfc79d9a", "5197310d-5d42-4337-bb59-2fd06e6a8fcd" },
                    { "3e4aab82-7dc1-4541-99e4-ade2523d95e9", "959596e5-93e4-4272-8cfb-6e71a4254370" }
                });

            migrationBuilder.InsertData(
                table: "BarCocktails",
                columns: new[] { "BarEntityId", "CocktailEntityId" },
                values: new object[,]
                {
                    { 6, 7 },
                    { 5, 7 },
                    { 6, 6 },
                    { 5, 6 },
                    { 6, 5 },
                    { 5, 5 },
                    { 5, 4 },
                    { 4, 4 },
                    { 2, 4 },
                    { 1, 1 },
                    { 4, 3 },
                    { 2, 3 },
                    { 1, 3 },
                    { 5, 2 },
                    { 3, 2 },
                    { 1, 2 },
                    { 5, 1 },
                    { 3, 1 },
                    { 2, 1 },
                    { 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "BarReviews",
                columns: new[] { "Id", "BarEntityId", "Rating", "Review", "UserEntityId" },
                values: new object[,]
                {
                    { 1, 1, 5, "Great place :) I enjoyed myself a lot!!!", "3e4aab82-7dc1-4541-99e4-ade2523d95e9" },
                    { 2, 3, 3, "Grumpy barman. Will not recommend.", "3e4aab82-7dc1-4541-99e4-ade2523d95e9" },
                    { 6, 5, 5, "Really sweet spot!", "3e4aab82-7dc1-4541-99e4-ade2523d95e9" },
                    { 4, 4, 1, null, "dd6561c5-0244-4303-974b-bb9cdfc79d9a" },
                    { 5, 5, 5, "Great! Loved it!", "dd6561c5-0244-4303-974b-bb9cdfc79d9a" },
                    { 3, 1, 4, "Fine place, but the music was too loud.", "dd6561c5-0244-4303-974b-bb9cdfc79d9a" }
                });

            migrationBuilder.InsertData(
                table: "CocktaiIngredients",
                columns: new[] { "IngredientEntityId", "CocktailEntityId" },
                values: new object[,]
                {
                    { 15, 7 },
                    { 14, 7 },
                    { 13, 6 },
                    { 12, 5 },
                    { 11, 6 },
                    { 11, 5 },
                    { 10, 5 },
                    { 8, 4 },
                    { 8, 1 },
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 9, 5 },
                    { 1, 4 },
                    { 1, 6 },
                    { 3, 3 },
                    { 2, 1 },
                    { 4, 4 },
                    { 5, 4 },
                    { 6, 3 },
                    { 7, 2 },
                    { 1, 7 }
                });

            migrationBuilder.InsertData(
                table: "CocktailReviews",
                columns: new[] { "Id", "CocktailEntityId", "Rating", "Review", "UserEntityId" },
                values: new object[,]
                {
                    { 2, 2, 4, "The cocktail was prepared just the way I like it...", "3e4aab82-7dc1-4541-99e4-ade2523d95e9" },
                    { 6, 6, 5, "Extremely nice taste ...for a non-alcoholic beverage!", "3e4aab82-7dc1-4541-99e4-ade2523d95e9" },
                    { 3, 3, 1, "This cocktail was a disaster..", "dd6561c5-0244-4303-974b-bb9cdfc79d9a" },
                    { 4, 4, 3, null, "dd6561c5-0244-4303-974b-bb9cdfc79d9a" },
                    { 5, 6, 4, "Really refreshing!", "dd6561c5-0244-4303-974b-bb9cdfc79d9a" },
                    { 1, 1, 5, "My all time favorite drink...", "3e4aab82-7dc1-4541-99e4-ade2523d95e9" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_BarCocktails_CocktailEntityId",
                table: "BarCocktails",
                column: "CocktailEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_BarReviews_BarEntityId",
                table: "BarReviews",
                column: "BarEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_BarReviews_UserEntityId",
                table: "BarReviews",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktaiIngredients_CocktailEntityId",
                table: "CocktaiIngredients",
                column: "CocktailEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailReviews_CocktailEntityId",
                table: "CocktailReviews",
                column: "CocktailEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_CocktailReviews_UserEntityId",
                table: "CocktailReviews",
                column: "UserEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BarCocktails");

            migrationBuilder.DropTable(
                name: "BarReviews");

            migrationBuilder.DropTable(
                name: "CocktaiIngredients");

            migrationBuilder.DropTable(
                name: "CocktailReviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Bars");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Cocktails");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
