﻿// <auto-generated />
using System;
using HR_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HR_Project.Migrations
{
    [DbContext(typeof(HRContext))]
    [Migration("20240317130040_v1")]
    partial class v1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HR_Project.Models.Attend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<TimeSpan>("AttendTime")
                        .HasColumnType("time");

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("Emp_id")
                        .HasColumnType("int");

                    b.Property<int?>("HR_id")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("LeaveTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("Emp_id");

                    b.HasIndex("HR_id");

                    b.ToTable("Attend");
                });

            modelBuilder.Entity("HR_Project.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("HR_Project.Models.Emp_Holiday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<int?>("Employee_id")
                        .HasColumnType("int");

                    b.Property<int?>("Holiday_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Employee_id");

                    b.HasIndex("Holiday_id");

                    b.ToTable("Emp_Holiday");
                });

            modelBuilder.Entity("HR_Project.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("AttendTime")
                        .HasColumnType("time");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<int?>("Dept_id")
                        .HasColumnType("int");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("HR_id")
                        .HasColumnType("int");

                    b.Property<DateOnly>("HireDate")
                        .HasColumnType("date");

                    b.Property<TimeSpan>("LeaveTime")
                        .HasColumnType("time");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rules_id")
                        .HasColumnType("int");

                    b.Property<long>("SSN")
                        .HasColumnType("bigint");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Dept_id");

                    b.HasIndex("HR_id");

                    b.HasIndex("Rules_id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("HR_Project.Models.General_Rules", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Bonus")
                        .HasColumnType("float");

                    b.Property<double>("Discound")
                        .HasColumnType("float");

                    b.Property<string>("OffDay1")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OffDay2")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("General_Rules");
                });

            modelBuilder.Entity("HR_Project.Models.HR", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Rules_id")
                        .HasColumnType("int");

                    b.Property<string>("UseName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Rules_id");

                    b.ToTable("HR");
                });

            modelBuilder.Entity("HR_Project.Models.Holiday", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("Date")
                        .HasColumnType("date");

                    b.Property<int?>("HR_id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("HR_id");

                    b.ToTable("Holiday");
                });

            modelBuilder.Entity("HR_Project.Models.Permissions_Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Dept_id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("Dept_id");

                    b.ToTable("Permissions_Department");
                });

            modelBuilder.Entity("HR_Project.Models.Permissions_HR", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("HR_id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("HR_id");

                    b.ToTable("Permissions_HR");
                });

            modelBuilder.Entity("HR_Project.Models.Attend", b =>
                {
                    b.HasOne("HR_Project.Models.Employee", "Employee")
                        .WithMany("Attend")
                        .HasForeignKey("Emp_id");

                    b.HasOne("HR_Project.Models.HR", "HRs")
                        .WithMany("Attend")
                        .HasForeignKey("HR_id");

                    b.Navigation("Employee");

                    b.Navigation("HRs");
                });

            modelBuilder.Entity("HR_Project.Models.Emp_Holiday", b =>
                {
                    b.HasOne("HR_Project.Models.Employee", "Employee")
                        .WithMany("EmpHolidays")
                        .HasForeignKey("Employee_id");

                    b.HasOne("HR_Project.Models.Holiday", "Holiday")
                        .WithMany("EmpHolidays")
                        .HasForeignKey("Holiday_id");

                    b.Navigation("Employee");

                    b.Navigation("Holiday");
                });

            modelBuilder.Entity("HR_Project.Models.Employee", b =>
                {
                    b.HasOne("HR_Project.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("Dept_id");

                    b.HasOne("HR_Project.Models.HR", "HRs")
                        .WithMany("Employees")
                        .HasForeignKey("HR_id");

                    b.HasOne("HR_Project.Models.General_Rules", "General_Rules")
                        .WithMany("Employees")
                        .HasForeignKey("Rules_id");

                    b.Navigation("Department");

                    b.Navigation("General_Rules");

                    b.Navigation("HRs");
                });

            modelBuilder.Entity("HR_Project.Models.HR", b =>
                {
                    b.HasOne("HR_Project.Models.General_Rules", "General_Rules")
                        .WithMany("HR")
                        .HasForeignKey("Rules_id");

                    b.Navigation("General_Rules");
                });

            modelBuilder.Entity("HR_Project.Models.Holiday", b =>
                {
                    b.HasOne("HR_Project.Models.HR", "HR")
                        .WithMany("Holiday")
                        .HasForeignKey("HR_id");

                    b.Navigation("HR");
                });

            modelBuilder.Entity("HR_Project.Models.Permissions_Department", b =>
                {
                    b.HasOne("HR_Project.Models.Department", "Department")
                        .WithMany("Permissions_Department")
                        .HasForeignKey("Dept_id");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("HR_Project.Models.Permissions_HR", b =>
                {
                    b.HasOne("HR_Project.Models.HR", "HR")
                        .WithMany("permissions_HRs")
                        .HasForeignKey("HR_id");

                    b.Navigation("HR");
                });

            modelBuilder.Entity("HR_Project.Models.Department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Permissions_Department");
                });

            modelBuilder.Entity("HR_Project.Models.Employee", b =>
                {
                    b.Navigation("Attend");

                    b.Navigation("EmpHolidays");
                });

            modelBuilder.Entity("HR_Project.Models.General_Rules", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("HR");
                });

            modelBuilder.Entity("HR_Project.Models.HR", b =>
                {
                    b.Navigation("Attend");

                    b.Navigation("Employees");

                    b.Navigation("Holiday");

                    b.Navigation("permissions_HRs");
                });

            modelBuilder.Entity("HR_Project.Models.Holiday", b =>
                {
                    b.Navigation("EmpHolidays");
                });
#pragma warning restore 612, 618
        }
    }
}
