﻿// <auto-generated />
using System;
using ExchangeBook.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ExchangeBook.Migrations
{
    [DbContext(typeof(BookExchangeDbContext))]
    partial class BookExchangeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ExchangeBook.Data.Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("ExchangeBook.Data.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AuthorId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex(new[] { "Title" }, "IX_TITLE");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("ExchangeBook.Data.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<int?>("InterestedId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsSeen")
                        .IsRequired()
                        .HasColumnType("bit");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("InterestedId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("ExchangeBook.Data.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Firstname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Lastname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("ExchangeBook.Data.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique()
                        .HasFilter("[UserId] IS NOT NULL");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("ExchangeBook.Data.StoreBook", b =>
                {
                    b.Property<int?>("StoreId")
                        .HasColumnType("int");

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.HasKey("StoreId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("StoreBooks");
                });

            modelBuilder.Entity("ExchangeBook.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Username")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "UQ_EMAIL")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex(new[] { "Username" }, "UQ_USERNAME")
                        .IsUnique()
                        .HasFilter("[Username] IS NOT NULL");

                    b.ToTable("USERS", (string)null);
                });

            modelBuilder.Entity("Person_Book", b =>
                {
                    b.Property<int>("BooksId")
                        .HasColumnType("int");

                    b.Property<int>("PersonsId")
                        .HasColumnType("int");

                    b.HasKey("BooksId", "PersonsId");

                    b.HasIndex("PersonsId");

                    b.ToTable("Person_Book");
                });

            modelBuilder.Entity("ExchangeBook.Data.Book", b =>
                {
                    b.HasOne("ExchangeBook.Data.Author", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorId")
                        .HasConstraintName("FK_BOOK_AUTHOR");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("ExchangeBook.Data.Notification", b =>
                {
                    b.HasOne("ExchangeBook.Data.Book", "Book")
                        .WithMany("Notifications")
                        .HasForeignKey("BookId");

                    b.HasOne("ExchangeBook.Data.User", "InterestedUser")
                        .WithMany("NotificationsAsInterested")
                        .HasForeignKey("InterestedId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("ExchangeBook.Data.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Book");

                    b.Navigation("InterestedUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExchangeBook.Data.Person", b =>
                {
                    b.HasOne("ExchangeBook.Data.User", "User")
                        .WithOne("Person")
                        .HasForeignKey("ExchangeBook.Data.Person", "UserId")
                        .HasConstraintName("FK_PERSON_USER");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExchangeBook.Data.Store", b =>
                {
                    b.HasOne("ExchangeBook.Data.User", "User")
                        .WithOne("Store")
                        .HasForeignKey("ExchangeBook.Data.Store", "UserId")
                        .HasConstraintName("FK_STORE_USERS");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExchangeBook.Data.StoreBook", b =>
                {
                    b.HasOne("ExchangeBook.Data.Book", "Book")
                        .WithMany("StoreBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExchangeBook.Data.Store", "Store")
                        .WithMany("StoreBooks")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("Person_Book", b =>
                {
                    b.HasOne("ExchangeBook.Data.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ExchangeBook.Data.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ExchangeBook.Data.Author", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("ExchangeBook.Data.Book", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("StoreBooks");
                });

            modelBuilder.Entity("ExchangeBook.Data.Store", b =>
                {
                    b.Navigation("StoreBooks");
                });

            modelBuilder.Entity("ExchangeBook.Data.User", b =>
                {
                    b.Navigation("Notifications");

                    b.Navigation("NotificationsAsInterested");

                    b.Navigation("Person");

                    b.Navigation("Store");
                });
#pragma warning restore 612, 618
        }
    }
}
