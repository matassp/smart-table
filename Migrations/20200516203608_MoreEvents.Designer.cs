﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using smart_table.Models.DataBase;

namespace smart_table.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20200516203608_MoreEvents")]
    partial class MoreEvents
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("smart_table.Models.Bills", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<double>("Amount")
                        .HasColumnName("amount")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("DateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("date_time")
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<string>("Evaluation")
                        .IsRequired()
                        .HasColumnName("evaluation")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<long?>("FkDiscounts")
                        .HasColumnName("fk_discounts")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsPaid")
                        .HasColumnName("is_paid")
                        .HasColumnType("boolean");

                    b.Property<double?>("Tips")
                        .HasColumnName("tips")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("FkDiscounts");

                    b.ToTable("bills");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Amount = 50.450000000000003,
                            DateTime = new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Evaluation = "Labai skanus maistas",
                            FkDiscounts = 1L,
                            IsPaid = true,
                            Tips = 10.0
                        },
                        new
                        {
                            Id = 2L,
                            Amount = 5.3899999999999997,
                            DateTime = new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Evaluation = "Malonus aptarnavimas",
                            FkDiscounts = 2L,
                            IsPaid = false,
                            Tips = 0.0
                        });
                });

            modelBuilder.Entity("smart_table.Models.CustomerTables", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsTaken")
                        .HasColumnName("is_taken")
                        .HasColumnType("boolean");

                    b.Property<string>("JoinCode")
                        .HasColumnName("join_code")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("QrCode")
                        .HasColumnName("qr_code")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int>("SeatsCount")
                        .HasColumnName("seats_count")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("customer_tables");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            IsTaken = true,
                            JoinCode = "DEF",
                            QrCode = "ABC",
                            SeatsCount = 6
                        },
                        new
                        {
                            Id = 2L,
                            IsTaken = false,
                            JoinCode = "wxz",
                            QrCode = "qrt",
                            SeatsCount = 4
                        });
                });

            modelBuilder.Entity("smart_table.Models.Discounts", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("DiscountCode")
                        .IsRequired()
                        .HasColumnName("discount_code")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int>("DiscountProc")
                        .HasColumnName("discount_proc")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("StandUntil")
                        .HasColumnName("stand_until")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("discounts");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DiscountCode = "ST101",
                            DiscountProc = 15,
                            StandUntil = new DateTime(2020, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2L,
                            DiscountCode = "ST102",
                            DiscountProc = 25,
                            StandUntil = new DateTime(2020, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("smart_table.Models.DishCategories", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("dish_categories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Title = "Picos"
                        },
                        new
                        {
                            Id = 2L,
                            Title = "Gerimai"
                        });
                });

            modelBuilder.Entity("smart_table.Models.DishIngredients", b =>
                {
                    b.Property<long>("FkDishes")
                        .HasColumnName("fk_dishes")
                        .HasColumnType("bigint");

                    b.Property<long>("FkIngredients")
                        .HasColumnName("fk_ingredients")
                        .HasColumnType("bigint");

                    b.Property<double>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("double precision");

                    b.HasKey("FkDishes", "FkIngredients")
                        .HasName("dish_ingredients_pkey");

                    b.HasIndex("FkIngredients");

                    b.ToTable("dish_ingredients");
                });

            modelBuilder.Entity("smart_table.Models.Dishes", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("Calories")
                        .HasColumnName("calories")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<double?>("Discount")
                        .HasColumnName("discount")
                        .HasColumnType("double precision");

                    b.Property<long?>("FkDishCategories")
                        .HasColumnName("fk_dish_categories")
                        .HasColumnType("bigint");

                    b.Property<double>("Price")
                        .HasColumnName("price")
                        .HasColumnType("double precision");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("FkDishCategories");

                    b.ToTable("dishes");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Calories = 300,
                            Description = "Labai skani pica",
                            Discount = 20.0,
                            FkDishCategories = 1L,
                            Price = 11.99,
                            Title = "Capriciosa"
                        },
                        new
                        {
                            Id = 2L,
                            Calories = -1,
                            Description = "Nesveika, bet skanu",
                            Discount = 0.0,
                            FkDishCategories = 2L,
                            Price = 1.99,
                            Title = "Cola"
                        },
                        new
                        {
                            Id = 3L,
                            Calories = 20,
                            Description = "Zalioji arbata, rytine",
                            Discount = 0.0,
                            FkDishCategories = 2L,
                            Price = 1.0,
                            Title = "Arbata"
                        });
                });

            modelBuilder.Entity("smart_table.Models.EventType", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character(12)")
                        .IsFixedLength(true)
                        .HasMaxLength(12);

                    b.HasKey("Id");

                    b.ToTable("event_type");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Saskaita"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Atsaukimas"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Klientas"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Uzsakymas"
                        });
                });

            modelBuilder.Entity("smart_table.Models.Events", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("FkOrders")
                        .HasColumnName("fk_orders")
                        .HasColumnType("bigint");

                    b.Property<long>("Type")
                        .HasColumnName("type")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("FkOrders");

                    b.HasIndex("Type");

                    b.ToTable("events");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            FkOrders = 1L,
                            Type = 3L
                        },
                        new
                        {
                            Id = 2L,
                            FkOrders = 1L,
                            Type = 4L
                        },
                        new
                        {
                            Id = 3L,
                            FkOrders = 1L,
                            Type = 1L
                        },
                        new
                        {
                            Id = 4L,
                            FkOrders = 2L,
                            Type = 3L
                        },
                        new
                        {
                            Id = 5L,
                            FkOrders = 2L,
                            Type = 4L
                        },
                        new
                        {
                            Id = 6L,
                            FkOrders = 3L,
                            Type = 4L
                        });
                });

            modelBuilder.Entity("smart_table.Models.Ingredients", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.ToTable("ingredients");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Title = "Kumpis"
                        },
                        new
                        {
                            Id = 2L,
                            Title = "Suris"
                        });
                });

            modelBuilder.Entity("smart_table.Models.MenuDishes", b =>
                {
                    b.Property<long>("FkDishes")
                        .HasColumnName("fk_dishes")
                        .HasColumnType("bigint");

                    b.Property<long>("FkMenus")
                        .HasColumnName("fk_menus")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DateFrom")
                        .HasColumnName("date_from")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("DateUntil")
                        .HasColumnName("date_until")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("FkDishes", "FkMenus")
                        .HasName("menu_dishes_pkey");

                    b.HasIndex("FkMenus");

                    b.ToTable("menu_dishes");

                    b.HasData(
                        new
                        {
                            FkDishes = 1L,
                            FkMenus = 1L
                        },
                        new
                        {
                            FkDishes = 2L,
                            FkMenus = 1L
                        },
                        new
                        {
                            FkDishes = 3L,
                            FkMenus = 1L
                        },
                        new
                        {
                            FkDishes = 1L,
                            FkMenus = 2L
                        },
                        new
                        {
                            FkDishes = 2L,
                            FkMenus = 2L
                        });
                });

            modelBuilder.Entity("smart_table.Models.Menus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("DateFrom")
                        .HasColumnName("date_from")
                        .HasColumnType("date");

                    b.Property<DateTime?>("DateUntil")
                        .HasColumnName("date_until")
                        .HasColumnType("date");

                    b.Property<bool>("Fri")
                        .HasColumnName("fri")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsActive")
                        .HasColumnName("is_active")
                        .HasColumnType("boolean");

                    b.Property<bool>("Mon")
                        .HasColumnName("mon")
                        .HasColumnType("boolean");

                    b.Property<bool>("Sat")
                        .HasColumnName("sat")
                        .HasColumnType("boolean");

                    b.Property<bool>("Sun")
                        .HasColumnName("sun")
                        .HasColumnType("boolean");

                    b.Property<bool>("Thu")
                        .HasColumnName("thu")
                        .HasColumnType("boolean");

                    b.Property<TimeSpan?>("TimeFrom")
                        .HasColumnName("time_from")
                        .HasColumnType("time without time zone");

                    b.Property<TimeSpan?>("TimeUntil")
                        .HasColumnName("time_until")
                        .HasColumnType("time without time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("title")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("Tue")
                        .HasColumnName("tue")
                        .HasColumnType("boolean");

                    b.Property<bool>("Wed")
                        .HasColumnName("wed")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("menus");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Fri = true,
                            IsActive = true,
                            Mon = true,
                            Sat = true,
                            Sun = true,
                            Thu = true,
                            TimeFrom = new TimeSpan(0, 6, 0, 0, 0),
                            TimeUntil = new TimeSpan(0, 10, 0, 0, 0),
                            Title = "Pusryciu meniu",
                            Tue = true,
                            Wed = true
                        },
                        new
                        {
                            Id = 2L,
                            Fri = true,
                            IsActive = true,
                            Mon = true,
                            Sat = true,
                            Sun = true,
                            Thu = true,
                            Title = "Pagrindinis meniu",
                            Tue = true,
                            Wed = true
                        });
                });

            modelBuilder.Entity("smart_table.Models.OrderDishes", b =>
                {
                    b.Property<long>("FkDishes")
                        .HasColumnName("fk_dishes")
                        .HasColumnType("bigint");

                    b.Property<long>("FkOrders")
                        .HasColumnName("fk_orders")
                        .HasColumnType("bigint");

                    b.Property<string>("Comment")
                        .HasColumnName("comment")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity")
                        .HasColumnType("integer");

                    b.HasKey("FkDishes", "FkOrders")
                        .HasName("order_dishes_pkey");

                    b.HasIndex("FkOrders");

                    b.ToTable("order_dishes");

                    b.HasData(
                        new
                        {
                            FkDishes = 1L,
                            FkOrders = 1L,
                            Comment = "Viena pica be pado",
                            Quantity = 2
                        },
                        new
                        {
                            FkDishes = 2L,
                            FkOrders = 1L,
                            Comment = "Be cukraus",
                            Quantity = 2
                        },
                        new
                        {
                            FkDishes = 1L,
                            FkOrders = 2L,
                            Comment = "",
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("smart_table.Models.Orders", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("DateTime")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("date_time")
                        .HasColumnType("timestamp without time zone")
                        .HasDefaultValueSql("CURRENT_DATE");

                    b.Property<long?>("FkBills")
                        .HasColumnName("fk_bills")
                        .HasColumnType("bigint");

                    b.Property<long>("FkCustomerTables")
                        .HasColumnName("fk_customer_tables")
                        .HasColumnType("bigint");

                    b.Property<long?>("FkRegisteredUsers")
                        .HasColumnName("fk_registered_users")
                        .HasColumnType("bigint");

                    b.Property<bool>("Served")
                        .HasColumnName("served")
                        .HasColumnType("boolean");

                    b.Property<bool>("Submitted")
                        .HasColumnName("submitted")
                        .HasColumnType("boolean");

                    b.Property<double?>("Temperature")
                        .HasColumnName("temperature")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("FkBills");

                    b.HasIndex("FkCustomerTables");

                    b.HasIndex("FkRegisteredUsers");

                    b.ToTable("orders");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DateTime = new DateTime(2020, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FkBills = 1L,
                            FkCustomerTables = 1L,
                            FkRegisteredUsers = 2L,
                            Served = true,
                            Submitted = true,
                            Temperature = 15.0
                        },
                        new
                        {
                            Id = 2L,
                            DateTime = new DateTime(2020, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FkBills = 2L,
                            FkCustomerTables = 2L,
                            FkRegisteredUsers = 2L,
                            Served = false,
                            Submitted = true,
                            Temperature = 17.0
                        },
                        new
                        {
                            Id = 3L,
                            DateTime = new DateTime(2020, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FkCustomerTables = 1L,
                            Served = false,
                            Submitted = true,
                            Temperature = 19.0
                        });
                });

            modelBuilder.Entity("smart_table.Models.RegisteredUsers", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("BirthDate")
                        .HasColumnName("birth_date")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("email")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<bool>("IsBlocked")
                        .HasColumnName("is_blocked")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("password")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<string>("Phone")
                        .HasColumnName("phone")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.Property<long>("Role")
                        .HasColumnName("role")
                        .HasColumnType("bigint");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnName("surname")
                        .HasColumnType("character varying(255)")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Role");

                    b.ToTable("registered_users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BirthDate = new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "email@email.com",
                            IsBlocked = false,
                            Name = "User1",
                            Password = "Password123",
                            Phone = "860000000",
                            Role = 1L,
                            Surname = "User1"
                        },
                        new
                        {
                            Id = 2L,
                            BirthDate = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "",
                            IsBlocked = false,
                            Name = "User2",
                            Password = "Password456",
                            Phone = "",
                            Role = 2L,
                            Surname = "User2"
                        },
                        new
                        {
                            Id = 3L,
                            BirthDate = new DateTime(2002, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "",
                            IsBlocked = false,
                            Name = "User3",
                            Password = "Secret123",
                            Phone = "",
                            Role = 2L,
                            Surname = "User3"
                        });
                });

            modelBuilder.Entity("smart_table.Models.UserRole", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("bigint")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasColumnType("character(13)")
                        .IsFixedLength(true)
                        .HasMaxLength(13);

                    b.HasKey("Id");

                    b.ToTable("user_role");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "administrator"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "waiter"
                        });
                });

            modelBuilder.Entity("smart_table.Models.Bills", b =>
                {
                    b.HasOne("smart_table.Models.Discounts", "FkDiscountsNavigation")
                        .WithMany("Bills")
                        .HasForeignKey("FkDiscounts")
                        .HasConstraintName("fkc_discounts");
                });

            modelBuilder.Entity("smart_table.Models.DishIngredients", b =>
                {
                    b.HasOne("smart_table.Models.Dishes", "FkDishesNavigation")
                        .WithMany("DishIngredients")
                        .HasForeignKey("FkDishes")
                        .HasConstraintName("fkc_dishes")
                        .IsRequired();

                    b.HasOne("smart_table.Models.Ingredients", "FkIngredientsNavigation")
                        .WithMany("DishIngredients")
                        .HasForeignKey("FkIngredients")
                        .HasConstraintName("fkc_ingredients")
                        .IsRequired();
                });

            modelBuilder.Entity("smart_table.Models.Dishes", b =>
                {
                    b.HasOne("smart_table.Models.DishCategories", "FkDishCategoriesNavigation")
                        .WithMany("Dishes")
                        .HasForeignKey("FkDishCategories")
                        .HasConstraintName("fkc_dish_categories");
                });

            modelBuilder.Entity("smart_table.Models.Events", b =>
                {
                    b.HasOne("smart_table.Models.Orders", "FkOrdersNavigation")
                        .WithMany("Events")
                        .HasForeignKey("FkOrders")
                        .HasConstraintName("fkc_orders")
                        .IsRequired();

                    b.HasOne("smart_table.Models.EventType", "TypeNavigation")
                        .WithMany("Events")
                        .HasForeignKey("Type")
                        .HasConstraintName("events_type_fkey")
                        .IsRequired();
                });

            modelBuilder.Entity("smart_table.Models.MenuDishes", b =>
                {
                    b.HasOne("smart_table.Models.Dishes", "FkDishesNavigation")
                        .WithMany("MenuDishes")
                        .HasForeignKey("FkDishes")
                        .HasConstraintName("fkc_dishes")
                        .IsRequired();

                    b.HasOne("smart_table.Models.Menus", "FkMenusNavigation")
                        .WithMany("MenuDishes")
                        .HasForeignKey("FkMenus")
                        .HasConstraintName("fkc_menus")
                        .IsRequired();
                });

            modelBuilder.Entity("smart_table.Models.OrderDishes", b =>
                {
                    b.HasOne("smart_table.Models.Dishes", "FkDishesNavigation")
                        .WithMany("OrderDishes")
                        .HasForeignKey("FkDishes")
                        .HasConstraintName("fkc_dishes")
                        .IsRequired();

                    b.HasOne("smart_table.Models.Orders", "FkOrdersNavigation")
                        .WithMany("OrderDishes")
                        .HasForeignKey("FkOrders")
                        .HasConstraintName("fkc_orders")
                        .IsRequired();
                });

            modelBuilder.Entity("smart_table.Models.Orders", b =>
                {
                    b.HasOne("smart_table.Models.Bills", "FkBillsNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("FkBills")
                        .HasConstraintName("fkc_bills");

                    b.HasOne("smart_table.Models.CustomerTables", "FkCustomerTablesNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("FkCustomerTables")
                        .HasConstraintName("fkc_customer_tables")
                        .IsRequired();

                    b.HasOne("smart_table.Models.RegisteredUsers", "FkRegisteredUsersNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("FkRegisteredUsers")
                        .HasConstraintName("fkc_registered_users");
                });

            modelBuilder.Entity("smart_table.Models.RegisteredUsers", b =>
                {
                    b.HasOne("smart_table.Models.UserRole", "RoleNavigation")
                        .WithMany("RegisteredUsers")
                        .HasForeignKey("Role")
                        .HasConstraintName("registered_users_role_fkey")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
