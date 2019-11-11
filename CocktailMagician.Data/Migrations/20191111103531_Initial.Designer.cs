﻿// <auto-generated />
using System;
using CocktailMagician.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CocktailMagician.Data.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20191111103531_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CocktailMagician.Data.Models.BarCocktailEntity", b =>
                {
                    b.Property<int>("BarEntityId");

                    b.Property<int>("CocktailEntityId");

                    b.HasKey("BarEntityId", "CocktailEntityId");

                    b.HasIndex("CocktailEntityId");

                    b.ToTable("BarCocktails");

                    b.HasData(
                        new
                        {
                            BarEntityId = 1,
                            CocktailEntityId = 1
                        },
                        new
                        {
                            BarEntityId = 1,
                            CocktailEntityId = 2
                        },
                        new
                        {
                            BarEntityId = 1,
                            CocktailEntityId = 3
                        },
                        new
                        {
                            BarEntityId = 2,
                            CocktailEntityId = 1
                        },
                        new
                        {
                            BarEntityId = 2,
                            CocktailEntityId = 3
                        },
                        new
                        {
                            BarEntityId = 2,
                            CocktailEntityId = 4
                        },
                        new
                        {
                            BarEntityId = 3,
                            CocktailEntityId = 1
                        },
                        new
                        {
                            BarEntityId = 3,
                            CocktailEntityId = 2
                        },
                        new
                        {
                            BarEntityId = 4,
                            CocktailEntityId = 3
                        },
                        new
                        {
                            BarEntityId = 4,
                            CocktailEntityId = 4
                        },
                        new
                        {
                            BarEntityId = 5,
                            CocktailEntityId = 1
                        },
                        new
                        {
                            BarEntityId = 5,
                            CocktailEntityId = 2
                        },
                        new
                        {
                            BarEntityId = 5,
                            CocktailEntityId = 3
                        },
                        new
                        {
                            BarEntityId = 5,
                            CocktailEntityId = 4
                        },
                        new
                        {
                            BarEntityId = 5,
                            CocktailEntityId = 5
                        },
                        new
                        {
                            BarEntityId = 5,
                            CocktailEntityId = 6
                        },
                        new
                        {
                            BarEntityId = 5,
                            CocktailEntityId = 7
                        },
                        new
                        {
                            BarEntityId = 6,
                            CocktailEntityId = 5
                        },
                        new
                        {
                            BarEntityId = 6,
                            CocktailEntityId = 6
                        },
                        new
                        {
                            BarEntityId = 6,
                            CocktailEntityId = 7
                        });
                });

            modelBuilder.Entity("CocktailMagician.Data.Models.BarEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(120);

                    b.Property<string>("ImagePath");

                    b.Property<bool>("IsHidden");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<double?>("Rating");

                    b.HasKey("Id");

                    b.ToTable("Bars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "3483  Stratford Court, Fayetteville, North Carolina",
                            IsHidden = false,
                            Name = "Ace of Clubs",
                            Rating = 4.5
                        },
                        new
                        {
                            Id = 2,
                            Address = "3234  Mesa Drive, Las Vegas, Nevada",
                            IsHidden = false,
                            Name = "The Back Lane Bar"
                        },
                        new
                        {
                            Id = 3,
                            Address = "3292  Oak Lane, Jamesport, Missouri",
                            IsHidden = false,
                            Name = "The Brass Lantern",
                            Rating = 4.0
                        },
                        new
                        {
                            Id = 4,
                            Address = "1957  Braxton Street, Momence, Illinois",
                            IsHidden = false,
                            Name = "Blue Boar Inn",
                            Rating = 1.0
                        },
                        new
                        {
                            Id = 5,
                            Address = "3710  Hall Valley Drive, Stonewood, West Virginia",
                            IsHidden = false,
                            Name = "Dexter Lake Club",
                            Rating = 5.0
                        },
                        new
                        {
                            Id = 6,
                            Address = "1313  Jerome Avenue, Harlingen, Texas",
                            IsHidden = false,
                            Name = "The Lion and Unicorn "
                        });
                });

            modelBuilder.Entity("CocktailMagician.Data.Models.BarReviewEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BarEntityId");

                    b.Property<int>("Rating");

                    b.Property<string>("Review");

                    b.Property<string>("UserEntityId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("BarEntityId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("BarReviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BarEntityId = 1,
                            Rating = 5,
                            Review = "Great place :) I enjoyed myself a lot!!!",
                            UserEntityId = "3e4aab82-7dc1-4541-99e4-ade2523d95e9"
                        },
                        new
                        {
                            Id = 2,
                            BarEntityId = 3,
                            Rating = 3,
                            Review = "Grumpy barman. Will not recommend.",
                            UserEntityId = "3e4aab82-7dc1-4541-99e4-ade2523d95e9"
                        },
                        new
                        {
                            Id = 3,
                            BarEntityId = 1,
                            Rating = 4,
                            Review = "Fine place, but the music was too loud.",
                            UserEntityId = "dd6561c5-0244-4303-974b-bb9cdfc79d9a"
                        },
                        new
                        {
                            Id = 4,
                            BarEntityId = 4,
                            Rating = 1,
                            UserEntityId = "dd6561c5-0244-4303-974b-bb9cdfc79d9a"
                        },
                        new
                        {
                            Id = 5,
                            BarEntityId = 5,
                            Rating = 5,
                            Review = "Great! Loved it!",
                            UserEntityId = "dd6561c5-0244-4303-974b-bb9cdfc79d9a"
                        },
                        new
                        {
                            Id = 6,
                            BarEntityId = 5,
                            Rating = 5,
                            Review = "Really sweet spot!",
                            UserEntityId = "3e4aab82-7dc1-4541-99e4-ade2523d95e9"
                        });
                });

            modelBuilder.Entity("CocktailMagician.Data.Models.CocktailEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImagePath");

                    b.Property<bool>("IsHidden");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70);

                    b.Property<double?>("Rating");

                    b.Property<string>("Recipe")
                        .IsRequired()
                        .HasMaxLength(700);

                    b.HasKey("Id");

                    b.ToTable("Cocktails");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsHidden = false,
                            Name = "Black Russian",
                            Rating = 5.0,
                            Recipe = "Pour the ingredients directly in a lowball glass with ice. Top up with coke. Stir and serve. Simple - yet a classic."
                        },
                        new
                        {
                            Id = 2,
                            IsHidden = false,
                            Name = "Whiskey And Coke",
                            Rating = 4.0,
                            Recipe = "A classic combo, simply add the whisky into the bottom of a lowball glass with some ice cubes, then top up with the desired amount of coke. Classic and simple yet tasty!"
                        },
                        new
                        {
                            Id = 3,
                            IsHidden = false,
                            Name = "Cuba Libre",
                            Rating = 1.0,
                            Recipe = "Add the rum and lime juice into a highball glass with ice. Stir and top up with coke."
                        },
                        new
                        {
                            Id = 4,
                            IsHidden = false,
                            Name = "Iceberg Paralyzer",
                            Rating = 3.0,
                            Recipe = "Fill tall glass with ice to the top before adding the vodka and Kaluha. Next add the coke nearly to the top before adding in the milk to finish. Stir with a barspoon. Just remember to add a lot of ice or the milk can curdle with the coke."
                        },
                        new
                        {
                            Id = 5,
                            IsHidden = false,
                            Name = "Carribean Sunset Mocktail",
                            Recipe = "No one will miss the alcohol in this tasty family-friendly drink combining Sprite, orange juice, lemonade and grenadine"
                        },
                        new
                        {
                            Id = 6,
                            IsHidden = false,
                            Name = "Long Island Iced Tea Mocktail",
                            Rating = 4.5,
                            Recipe = "Coca-Cola, lemonade and black tea give this signature drink the taste of the original without the alcohol."
                        },
                        new
                        {
                            Id = 7,
                            IsHidden = false,
                            Name = "Coca-Cola Spice",
                            Recipe = "Add Coca-Cola, pineapple juice and Pibb Xtra to make a non-alcoholic take on a traditional holiday beverage."
                        });
                });

            modelBuilder.Entity("CocktailMagician.Data.Models.CocktailIngredientEntity", b =>
                {
                    b.Property<int>("IngredientEntityId");

                    b.Property<int>("CocktailEntityId");

                    b.HasKey("IngredientEntityId", "CocktailEntityId");

                    b.HasIndex("CocktailEntityId");

                    b.ToTable("CocktaiIngredients");

                    b.HasData(
                        new
                        {
                            IngredientEntityId = 1,
                            CocktailEntityId = 1
                        },
                        new
                        {
                            IngredientEntityId = 2,
                            CocktailEntityId = 1
                        },
                        new
                        {
                            IngredientEntityId = 8,
                            CocktailEntityId = 1
                        },
                        new
                        {
                            IngredientEntityId = 1,
                            CocktailEntityId = 2
                        },
                        new
                        {
                            IngredientEntityId = 7,
                            CocktailEntityId = 2
                        },
                        new
                        {
                            IngredientEntityId = 1,
                            CocktailEntityId = 3
                        },
                        new
                        {
                            IngredientEntityId = 3,
                            CocktailEntityId = 3
                        },
                        new
                        {
                            IngredientEntityId = 6,
                            CocktailEntityId = 3
                        },
                        new
                        {
                            IngredientEntityId = 1,
                            CocktailEntityId = 4
                        },
                        new
                        {
                            IngredientEntityId = 4,
                            CocktailEntityId = 4
                        },
                        new
                        {
                            IngredientEntityId = 5,
                            CocktailEntityId = 4
                        },
                        new
                        {
                            IngredientEntityId = 8,
                            CocktailEntityId = 4
                        },
                        new
                        {
                            IngredientEntityId = 9,
                            CocktailEntityId = 5
                        },
                        new
                        {
                            IngredientEntityId = 10,
                            CocktailEntityId = 5
                        },
                        new
                        {
                            IngredientEntityId = 11,
                            CocktailEntityId = 5
                        },
                        new
                        {
                            IngredientEntityId = 12,
                            CocktailEntityId = 5
                        },
                        new
                        {
                            IngredientEntityId = 1,
                            CocktailEntityId = 6
                        },
                        new
                        {
                            IngredientEntityId = 11,
                            CocktailEntityId = 6
                        },
                        new
                        {
                            IngredientEntityId = 13,
                            CocktailEntityId = 6
                        },
                        new
                        {
                            IngredientEntityId = 1,
                            CocktailEntityId = 7
                        },
                        new
                        {
                            IngredientEntityId = 14,
                            CocktailEntityId = 7
                        },
                        new
                        {
                            IngredientEntityId = 15,
                            CocktailEntityId = 7
                        });
                });

            modelBuilder.Entity("CocktailMagician.Data.Models.CocktailReviewEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CocktailEntityId");

                    b.Property<int>("Rating");

                    b.Property<string>("Review");

                    b.Property<string>("UserEntityId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("CocktailEntityId");

                    b.HasIndex("UserEntityId");

                    b.ToTable("CocktailReviews");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CocktailEntityId = 1,
                            Rating = 5,
                            Review = "My all time favorite drink...",
                            UserEntityId = "3e4aab82-7dc1-4541-99e4-ade2523d95e9"
                        },
                        new
                        {
                            Id = 2,
                            CocktailEntityId = 2,
                            Rating = 4,
                            Review = "The cocktail was prepared just the way I like it...",
                            UserEntityId = "3e4aab82-7dc1-4541-99e4-ade2523d95e9"
                        },
                        new
                        {
                            Id = 3,
                            CocktailEntityId = 3,
                            Rating = 1,
                            Review = "This cocktail was a disaster..",
                            UserEntityId = "dd6561c5-0244-4303-974b-bb9cdfc79d9a"
                        },
                        new
                        {
                            Id = 4,
                            CocktailEntityId = 4,
                            Rating = 3,
                            UserEntityId = "dd6561c5-0244-4303-974b-bb9cdfc79d9a"
                        },
                        new
                        {
                            Id = 5,
                            CocktailEntityId = 6,
                            Rating = 4,
                            Review = "Really refreshing!",
                            UserEntityId = "dd6561c5-0244-4303-974b-bb9cdfc79d9a"
                        },
                        new
                        {
                            Id = 6,
                            CocktailEntityId = 6,
                            Rating = 5,
                            Review = "Extremely nice taste ...for a non-alcoholic beverage!",
                            UserEntityId = "3e4aab82-7dc1-4541-99e4-ade2523d95e9"
                        });
                });

            modelBuilder.Entity("CocktailMagician.Data.Models.IngredientEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Coca-Cola"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Coffee Liqueur"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Lime Juice"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Milk"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Kahlua"
                        },
                        new
                        {
                            Id = 6,
                            Name = "White Rum"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Whiskey"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Vodka"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Sprite"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Orange Juice"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Lemonade"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Grenadine"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Black Tea"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Pineapple Juice"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Pibb Xtra"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Club Soda"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Fanta"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Yogurt"
                        });
                });

            modelBuilder.Entity("CocktailMagician.Data.Models.UserEntity", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "3e4aab82-7dc1-4541-99e4-ade2523d95e9",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "7860d092-2b7b-43f7-b786-b094814c32a5",
                            Email = "admin@admin.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN@ADMIN.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEPCgsKRJwJYsdiLjYUmnceNDmjGwBHAv2cWSFmPxWO6Nhdgcea6ae6Pema7tRusF+w==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "WDVY5A55O3W647HQWFALI6XUL3HGXVH5",
                            TwoFactorEnabled = false,
                            UserName = "admin@admin.com"
                        },
                        new
                        {
                            Id = "dd6561c5-0244-4303-974b-bb9cdfc79d9a",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "02257977-cd98-4987-890c-e043e5b11b7a",
                            Email = "user@user.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "PESHO@PORN.COM",
                            NormalizedUserName = "USER@USER.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEHjrAvA0Ww9M6riqiuVTSSn+bp0or8KFufgIuHh2t5MQBA3S7/O6xG3R3x33IbChyg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "7ESQYUICWBMY6LMQNHL7NOCQOF5V7ZNN",
                            TwoFactorEnabled = false,
                            UserName = "user@user.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "959596e5-93e4-4272-8cfb-6e71a4254370",
                            ConcurrencyStamp = "20d35162-b35c-4b2e-80c1-81a15bc1b2f3",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "5197310d-5d42-4337-bb59-2fd06e6a8fcd",
                            ConcurrencyStamp = "a3bc9d45-276b-442f-bc6b-b1a5763df30d",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = "3e4aab82-7dc1-4541-99e4-ade2523d95e9",
                            RoleId = "959596e5-93e4-4272-8cfb-6e71a4254370"
                        },
                        new
                        {
                            UserId = "dd6561c5-0244-4303-974b-bb9cdfc79d9a",
                            RoleId = "5197310d-5d42-4337-bb59-2fd06e6a8fcd"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasMaxLength(128);

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("CocktailMagician.Data.Models.BarCocktailEntity", b =>
                {
                    b.HasOne("CocktailMagician.Data.Models.BarEntity", "BarEntity")
                        .WithMany("BarCocktails")
                        .HasForeignKey("BarEntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CocktailMagician.Data.Models.CocktailEntity", "CocktailEntity")
                        .WithMany("BarCocktails")
                        .HasForeignKey("CocktailEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CocktailMagician.Data.Models.BarReviewEntity", b =>
                {
                    b.HasOne("CocktailMagician.Data.Models.BarEntity", "Bar")
                        .WithMany("BarReviews")
                        .HasForeignKey("BarEntityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CocktailMagician.Data.Models.UserEntity", "User")
                        .WithMany("BarReviews")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("CocktailMagician.Data.Models.CocktailIngredientEntity", b =>
                {
                    b.HasOne("CocktailMagician.Data.Models.CocktailEntity", "CocktailEntity")
                        .WithMany("CocktailIngredients")
                        .HasForeignKey("CocktailEntityId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CocktailMagician.Data.Models.IngredientEntity", "IngredientEntity")
                        .WithMany("CocktailIngredients")
                        .HasForeignKey("IngredientEntityId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CocktailMagician.Data.Models.CocktailReviewEntity", b =>
                {
                    b.HasOne("CocktailMagician.Data.Models.CocktailEntity", "Cocktail")
                        .WithMany("CocktailReviews")
                        .HasForeignKey("CocktailEntityId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CocktailMagician.Data.Models.UserEntity", "User")
                        .WithMany("CocktailReviews")
                        .HasForeignKey("UserEntityId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("CocktailMagician.Data.Models.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("CocktailMagician.Data.Models.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CocktailMagician.Data.Models.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("CocktailMagician.Data.Models.UserEntity")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
