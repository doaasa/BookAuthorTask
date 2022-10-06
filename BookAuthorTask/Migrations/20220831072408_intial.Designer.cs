﻿// <auto-generated />
using BookAuthorTask;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookAuthorTask.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20220831072408_intial")]
    partial class intial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookAuthorTask.Author", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("age")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("authors");
                });

            modelBuilder.Entity("BookAuthorTask.Book", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("authorID")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pages")
                        .HasColumnType("int");

                    b.Property<int>("sectionid")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("authorID");

                    b.HasIndex("sectionid");

                    b.ToTable("book");
                });

            modelBuilder.Entity("BookAuthorTask.section", b =>
                {
                    b.Property<int>("sectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("sectionID");

                    b.ToTable("sections");
                });

            modelBuilder.Entity("BookAuthorTask.Book", b =>
                {
                    b.HasOne("BookAuthorTask.Author", "author")
                        .WithMany("books")
                        .HasForeignKey("authorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookAuthorTask.section", "Section")
                        .WithMany("books")
                        .HasForeignKey("sectionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");

                    b.Navigation("Section");
                });

            modelBuilder.Entity("BookAuthorTask.Author", b =>
                {
                    b.Navigation("books");
                });

            modelBuilder.Entity("BookAuthorTask.section", b =>
                {
                    b.Navigation("books");
                });
#pragma warning restore 612, 618
        }
    }
}