#region Using
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
#endregion

namespace smart_table.Models.DataBase
{
    public partial class DataBaseContext : DbContext
    {

        public DataBaseContext()
        {
        }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bills> Bills { get; set; }
        public virtual DbSet<CustomerTables> CustomerTables { get; set; }
        public virtual DbSet<Discounts> Discounts { get; set; }
        public virtual DbSet<DishCategories> DishCategories { get; set; }
        public virtual DbSet<DishIngredients> DishIngredients { get; set; }
        public virtual DbSet<Dishes> Dishes { get; set; }
        public virtual DbSet<EventType> EventType { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<Ingredients> Ingredients { get; set; }
        public virtual DbSet<MenuDishes> MenuDishes { get; set; }
        public virtual DbSet<Menus> Menus { get; set; }
        public virtual DbSet<OrderDishes> OrderDishes { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<RegisteredUsers> RegisteredUsers { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bills>(entity =>
            {
                entity.ToTable("bills");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.DateTime)
                    .HasColumnName("date_time")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.Evaluation)
                    .IsRequired()
                    .HasColumnName("evaluation")
                    .HasMaxLength(255);

                entity.Property(e => e.FkDiscounts).HasColumnName("fk_discounts");

                entity.Property(e => e.IsPaid).HasColumnName("is_paid");

                entity.Property(e => e.Tips).HasColumnName("tips");

                entity.HasOne(d => d.FkDiscountsNavigation)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.FkDiscounts)
                    .HasConstraintName("fkc_discounts");
            });

            modelBuilder.Entity<CustomerTables>(entity =>
            {
                entity.ToTable("customer_tables");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IsTaken).HasColumnName("is_taken");

                entity.Property(e => e.JoinCode)
                    .HasColumnName("join_code")
                    .HasMaxLength(255);

                entity.Property(e => e.QrCode)
                    .HasColumnName("qr_code")
                    .HasMaxLength(255);

                entity.Property(e => e.SeatsCount).HasColumnName("seats_count");
            });

            modelBuilder.Entity<Discounts>(entity =>
            {
                entity.ToTable("discounts");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DiscountCode)
                    .IsRequired()
                    .HasColumnName("discount_code")
                    .HasMaxLength(255);

                entity.Property(e => e.DiscountProc).HasColumnName("discount_proc");

                entity.Property(e => e.StandUntil).HasColumnName("stand_until");
            });

            modelBuilder.Entity<DishCategories>(entity =>
            {
                entity.ToTable("dish_categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<DishIngredients>(entity =>
            {
                entity.HasKey(e => new { e.FkDishes, e.FkIngredients })
                    .HasName("dish_ingredients_pkey");

                entity.ToTable("dish_ingredients");

                entity.Property(e => e.FkDishes).HasColumnName("fk_dishes");

                entity.Property(e => e.FkIngredients).HasColumnName("fk_ingredients");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.FkDishesNavigation)
                    .WithMany(p => p.DishIngredients)
                    .HasForeignKey(d => d.FkDishes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkc_dishes");

                entity.HasOne(d => d.FkIngredientsNavigation)
                    .WithMany(p => p.DishIngredients)
                    .HasForeignKey(d => d.FkIngredients)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkc_ingredients");
            });

            modelBuilder.Entity<Dishes>(entity =>
            {
                entity.ToTable("dishes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Calories).HasColumnName("calories");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(255);

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.FkDishCategories).HasColumnName("fk_dish_categories");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255);

                entity.HasOne(d => d.FkDishCategoriesNavigation)
                    .WithMany(p => p.Dishes)
                    .HasForeignKey(d => d.FkDishCategories)
                    .HasConstraintName("fkc_dish_categories");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("event_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(12)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.ToTable("events");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FkOrders).HasColumnName("fk_orders");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.FkOrdersNavigation)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.FkOrders)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkc_orders");

                entity.HasOne(d => d.TypeNavigation)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.Type)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("events_type_fkey");
            });

            modelBuilder.Entity<Ingredients>(entity =>
            {
                entity.ToTable("ingredients");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<MenuDishes>(entity =>
            {
                entity.HasKey(e => new { e.FkDishes, e.FkMenus })
                    .HasName("menu_dishes_pkey");

                entity.ToTable("menu_dishes");

                entity.Property(e => e.FkDishes).HasColumnName("fk_dishes");

                entity.Property(e => e.FkMenus).HasColumnName("fk_menus");

                entity.Property(e => e.DateFrom).HasColumnName("date_from");

                entity.Property(e => e.DateUntil).HasColumnName("date_until");

                entity.HasOne(d => d.FkDishesNavigation)
                    .WithMany(p => p.MenuDishes)
                    .HasForeignKey(d => d.FkDishes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkc_dishes");

                entity.HasOne(d => d.FkMenusNavigation)
                    .WithMany(p => p.MenuDishes)
                    .HasForeignKey(d => d.FkMenus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkc_menus");
            });

            modelBuilder.Entity<Menus>(entity =>
            {
                entity.ToTable("menus");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("date");

                entity.Property(e => e.DateUntil)
                    .HasColumnName("date_until")
                    .HasColumnType("date");

                entity.Property(e => e.Fri).HasColumnName("fri");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Mon).HasColumnName("mon");

                entity.Property(e => e.Sat).HasColumnName("sat");

                entity.Property(e => e.Sun).HasColumnName("sun");

                entity.Property(e => e.Thu).HasColumnName("thu");

                entity.Property(e => e.TimeFrom)
                    .HasColumnName("time_from")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.TimeUntil)
                    .HasColumnName("time_until")
                    .HasColumnType("time without time zone");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(255);

                entity.Property(e => e.Tue).HasColumnName("tue");

                entity.Property(e => e.Wed).HasColumnName("wed");
            });

            modelBuilder.Entity<OrderDishes>(entity =>
            {
                entity.HasKey(e => new { e.FkDishes, e.FkOrders })
                    .HasName("order_dishes_pkey");

                entity.ToTable("order_dishes");

                entity.Property(e => e.FkDishes).HasColumnName("fk_dishes");

                entity.Property(e => e.FkOrders).HasColumnName("fk_orders");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasMaxLength(255);

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.FkDishesNavigation)
                    .WithMany(p => p.OrderDishes)
                    .HasForeignKey(d => d.FkDishes)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkc_dishes");

                entity.HasOne(d => d.FkOrdersNavigation)
                    .WithMany(p => p.OrderDishes)
                    .HasForeignKey(d => d.FkOrders)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkc_orders");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DateTime)
                    .HasColumnName("date_time")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.FkBills).HasColumnName("fk_bills");

                entity.Property(e => e.FkCustomerTables).HasColumnName("fk_customer_tables");

                entity.Property(e => e.FkRegisteredUsers).HasColumnName("fk_registered_users");

                entity.Property(e => e.Served).HasColumnName("served");

                entity.Property(e => e.Submitted).HasColumnName("submitted");

                entity.Property(e => e.Temperature).HasColumnName("temperature");

                entity.HasOne(d => d.FkBillsNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.FkBills)
                    .HasConstraintName("fkc_bills");

                entity.HasOne(d => d.FkCustomerTablesNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.FkCustomerTables)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fkc_customer_tables");

                entity.HasOne(d => d.FkRegisteredUsersNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.FkRegisteredUsers)
                    .HasConstraintName("fkc_registered_users");
            });

            modelBuilder.Entity<RegisteredUsers>(entity =>
            {
                entity.ToTable("registered_users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BirthDate)
                    .HasColumnName("birth_date")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(255);

                entity.Property(e => e.IsBlocked).HasColumnName("is_blocked");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(255);

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(255);

                entity.HasOne(d => d.RoleNavigation)
                    .WithMany(p => p.RegisteredUsers)
                    .HasForeignKey(d => d.Role)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("registered_users_role_fkey");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(13)
                    .IsFixedLength();
            });

            modelBuilder.Entity<EventType>().HasData(
                new EventType
                {
                    Id = 1,
                    Name = "bill_request"
                },
                new EventType
                {
                    Id = 2,
                    Name = "cancel_order"
                },
                new EventType
                {
                    Id = 3,
                    Name = "new_customer"
                },
                new EventType
                {
                    Id = 4,
                    Name = "new_order"
                }
                );

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole
                {
                    Id = 1,
                    Name = "administrator"
                },
                new UserRole
                {
                    Id = 2,
                    Name = "waiter"
                });
            modelBuilder.Entity<RegisteredUsers>().HasData(
                new RegisteredUsers
                {
                    Id = 1,
                    Name = "User1",
                    Surname = "User1",
                    Password = "Password123",
                    Phone = "860000000",
                    Email = "email@email.com",
                    BirthDate = DateTime.Parse("2000-01-01"),
                    IsBlocked = false,
                    Role = 1
                },
                new RegisteredUsers
                {
                    Id = 2,
                    Name = "User2",
                    Surname = "User2",
                    Password = "Password456",
                    Phone = "",
                    Email = "",
                    BirthDate = DateTime.Parse("2001-01-01"),
                    IsBlocked = true,
                    Role = 2
                });
            modelBuilder.Entity<Ingredients>().HasData(
                new Ingredients
                {
                    Id = 1,
                    Title = "Kumpis"
                },
                new Ingredients
                {
                    Id = 2,
                    Title = "Suris"
                });
            modelBuilder.Entity<DishCategories>().HasData(
                new DishCategories
                {
                    Id = 1,
                    Title = "Picos"
                },
                new DishCategories
                {
                    Id = 2,
                    Title = "Gerimai"
                });
            modelBuilder.Entity<Dishes>().HasData(
                new Dishes
                {
                    Id = 1,
                    Title = "Capriciosa",
                    Description = "Labai skani pica",
                    Price = 11.99,
                    Calories = 300,
                    Discount = 20,
                    FkDishCategories = 1
                },
                new Dishes
                {
                    Id = 2,
                    Title = "Cola",
                    Description = "Nesveika, bet skanu",
                    Price = 1.99,
                    Calories = -1,
                    Discount = 0,
                    FkDishCategories = 2
                });
            
            modelBuilder.Entity<Bills>().HasData(
                new Bills
                {
                    Id = 1,
                    DateTime = DateTime.Parse("2020-04-01"),
                    Tips = 10,
                    Amount = 50.45,
                    IsPaid = true,
                    Evaluation = "Labai skanus maistas",
                    FkDiscounts = 1
                },
                new Bills
                {
                    Id = 2,
                    DateTime = DateTime.Parse("2020-05-01"),
                    Tips = 0,
                    Amount = 5.39,
                    IsPaid = false,
                    Evaluation = "Malonus aptarnavimas",
                    FkDiscounts = 2
                });
                
            modelBuilder.Entity<Discounts>().HasData(
                new Discounts
                {
                    Id = 1,
                    DiscountCode = "ST101",
                    StandUntil = DateTime.Parse("2020-12-31"),
                    DiscountProc = 15
                },
                new Discounts
                {
                    Id = 2,
                    DiscountCode = "ST102",
                    StandUntil = DateTime.Parse("2020-01-31"),
                    DiscountProc = 25
                });
            
            modelBuilder.Entity<Orders>().HasData(
                new Orders
                {
                    Id = 1,
                    DateTime = DateTime.Parse("2020-04-01"),
                    Temperature = 15,
                    Submitted = true,
                    Served = true,
                    FkBills = 1,
                    FkRegisteredUsers = 2,
                    FkCustomerTables = 1
                },
                new Orders
                {
                    Id = 2,
                    DateTime = DateTime.Parse("2020-05-01"),
                    Temperature = 17,
                    Submitted = true,
                    Served = false,
                    FkBills = 2,
                    FkRegisteredUsers = 2,
                    FkCustomerTables = 2
                }
                );
                
            modelBuilder.Entity<CustomerTables>().HasData(
                new CustomerTables
                {
                    Id = 1,
                    SeatsCount = 6,
                    QrCode = "ABC",
                    IsTaken = true,
                    JoinCode = "DEF"
                },
                new CustomerTables
                {
                    Id = 2,
                    SeatsCount = 4,
                    QrCode = "qrt",
                    IsTaken = false,
                    JoinCode = "wxz"
                }
                );
            modelBuilder.Entity<OrderDishes>().HasData(
                new OrderDishes
                {
                    FkDishes = 1,
                    FkOrders = 1,
                    Quantity = 2,
                    Comment = "Viena pica be pado"
                },
                new OrderDishes
                {
                    FkDishes = 2,
                    FkOrders = 1,
                    Quantity = 2,
                    Comment = "Be cukraus"
                },
                new OrderDishes
                {
                    FkDishes = 1,
                    FkOrders = 2,
                    Quantity = 1,
                    Comment = ""
                }
                );
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}