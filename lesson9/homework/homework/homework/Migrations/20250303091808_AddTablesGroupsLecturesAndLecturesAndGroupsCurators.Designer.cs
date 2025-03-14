﻿// <auto-generated />
using AcademicLibrary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace homework.Migrations
{
    [DbContext(typeof(AcademicContext))]
    [Migration("20250303091808_AddTablesGroupsLecturesAndLecturesAndGroupsCurators")]
    partial class AddTablesGroupsLecturesAndLecturesAndGroupsCurators
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AcademicLibrary.Curators", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Curators");
                });

            modelBuilder.Entity("AcademicLibrary.Departments", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FacultyId")
                        .HasColumnType("int");

                    b.Property<int>("Financing")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("FacultyId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Departments", t =>
                        {
                            t.HasCheckConstraint("Financing", "Financing >= 0");
                        });
                });

            modelBuilder.Entity("AcademicLibrary.Faculties", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Financing")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(0);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Faculties", t =>
                        {
                            t.HasCheckConstraint("Financing", "Financing >= 0")
                                .HasName("Financing1");
                        });
                });

            modelBuilder.Entity("AcademicLibrary.Groups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Course")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Groups", t =>
                        {
                            t.HasCheckConstraint("Course", "Course >= 1 AND Course <= 5");
                        });
                });

            modelBuilder.Entity("AcademicLibrary.GroupsCurators", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CuratorId")
                        .HasColumnType("int");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CuratorId");

                    b.HasIndex("GroupId");

                    b.ToTable("GroupsCurators");
                });

            modelBuilder.Entity("AcademicLibrary.GroupsLectures", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("LectureId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("LectureId");

                    b.ToTable("GroupsLectures");
                });

            modelBuilder.Entity("AcademicLibrary.Lectures", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.Property<int>("TeacherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SubjectId");

                    b.HasIndex("TeacherId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("AcademicLibrary.Subjects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Subjects");
                });

            modelBuilder.Entity("AcademicLibrary.Teachers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Teachers", t =>
                        {
                            t.HasCheckConstraint("Salary", "Salary > 0");
                        });
                });

            modelBuilder.Entity("AcademicLibrary.Departments", b =>
                {
                    b.HasOne("AcademicLibrary.Faculties", "Faculty")
                        .WithMany("Departments")
                        .HasForeignKey("FacultyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Faculty");
                });

            modelBuilder.Entity("AcademicLibrary.Groups", b =>
                {
                    b.HasOne("AcademicLibrary.Departments", "Department")
                        .WithMany("Groups")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("AcademicLibrary.GroupsCurators", b =>
                {
                    b.HasOne("AcademicLibrary.Curators", "Curator")
                        .WithMany("GroupsCurator")
                        .HasForeignKey("CuratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcademicLibrary.Groups", "Group")
                        .WithMany("GroupsCurator")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curator");

                    b.Navigation("Group");
                });

            modelBuilder.Entity("AcademicLibrary.GroupsLectures", b =>
                {
                    b.HasOne("AcademicLibrary.Groups", "Group")
                        .WithMany("GroupsLecture")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcademicLibrary.Lectures", "Lecture")
                        .WithMany("GroupsLectures")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");

                    b.Navigation("Lecture");
                });

            modelBuilder.Entity("AcademicLibrary.Lectures", b =>
                {
                    b.HasOne("AcademicLibrary.Subjects", "Subject")
                        .WithMany("Lectures")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AcademicLibrary.Teachers", "Teacher")
                        .WithMany("Lectures")
                        .HasForeignKey("TeacherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Subject");

                    b.Navigation("Teacher");
                });

            modelBuilder.Entity("AcademicLibrary.Curators", b =>
                {
                    b.Navigation("GroupsCurator");
                });

            modelBuilder.Entity("AcademicLibrary.Departments", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("AcademicLibrary.Faculties", b =>
                {
                    b.Navigation("Departments");
                });

            modelBuilder.Entity("AcademicLibrary.Groups", b =>
                {
                    b.Navigation("GroupsCurator");

                    b.Navigation("GroupsLecture");
                });

            modelBuilder.Entity("AcademicLibrary.Lectures", b =>
                {
                    b.Navigation("GroupsLectures");
                });

            modelBuilder.Entity("AcademicLibrary.Subjects", b =>
                {
                    b.Navigation("Lectures");
                });

            modelBuilder.Entity("AcademicLibrary.Teachers", b =>
                {
                    b.Navigation("Lectures");
                });
#pragma warning restore 612, 618
        }
    }
}
