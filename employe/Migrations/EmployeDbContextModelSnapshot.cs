﻿// <auto-generated />
using Employe.data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Employe.Migrations
{
    [DbContext(typeof(EmployeDbContext))]
    partial class EmployeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Employe.Model.Employ", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeId")
                        .HasColumnType("int");

                    b.Property<string>("Sarly")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeId")
                        .IsUnique();

                    b.ToTable("Employs");
                });

            modelBuilder.Entity("Employe.Model.Saralydata", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EmployeId")
                        .HasColumnType("int");

                    b.Property<string>("Employename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Prince")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Saralydata");
                });

            modelBuilder.Entity("Employe.Model.Employ", b =>
                {
                    b.HasOne("Employe.Model.Saralydata", "Saralydata")
                        .WithOne("Employ")
                        .HasForeignKey("Employe.Model.Employ", "EmployeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Saralydata");
                });

            modelBuilder.Entity("Employe.Model.Saralydata", b =>
                {
                    b.Navigation("Employ");
                });
#pragma warning restore 612, 618
        }
    }
}
