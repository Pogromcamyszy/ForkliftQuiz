﻿// <auto-generated />
using ForkliftQuiz.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ForkliftQuiz.Infrastructure.Migrations
{
    [DbContext(typeof(ForkliftQuizDbContext))]
    [Migration("20240912153347_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ForkliftQuiz.Core.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("Answers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IsCorrect = true,
                            QuestionId = 1,
                            Text = "2000kg"
                        },
                        new
                        {
                            Id = 2,
                            IsCorrect = false,
                            QuestionId = 1,
                            Text = "5000kg"
                        },
                        new
                        {
                            Id = 3,
                            IsCorrect = true,
                            QuestionId = 2,
                            Text = "Daily"
                        },
                        new
                        {
                            Id = 4,
                            IsCorrect = false,
                            QuestionId = 2,
                            Text = "Weekly"
                        });
                });

            modelBuilder.Entity("ForkliftQuiz.Core.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("QuizId")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.ToTable("Questions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            QuizId = 1,
                            Text = "What is the maximum load a forklift can carry?"
                        },
                        new
                        {
                            Id = 2,
                            QuizId = 1,
                            Text = "How often should forklifts be inspected?"
                        });
                });

            modelBuilder.Entity("ForkliftQuiz.Core.Entities.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Quizzes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "A quiz about forklift safety practices.",
                            Title = "Forklift Safety Quiz",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "A quiz for advanced forklift operations.",
                            Title = "Advanced Forklift Operations",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("ForkliftQuiz.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "admin@example.com",
                            PasswordHash = "hashed_password",
                            Role = "Admin",
                            UserName = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "user1@example.com",
                            PasswordHash = "hashed_password1",
                            Role = "User",
                            UserName = "user1"
                        });
                });

            modelBuilder.Entity("ForkliftQuiz.Core.Entities.Answer", b =>
                {
                    b.HasOne("ForkliftQuiz.Core.Entities.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");
                });

            modelBuilder.Entity("ForkliftQuiz.Core.Entities.Question", b =>
                {
                    b.HasOne("ForkliftQuiz.Core.Entities.Quiz", "Quiz")
                        .WithMany("Questions")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");
                });

            modelBuilder.Entity("ForkliftQuiz.Core.Entities.Quiz", b =>
                {
                    b.HasOne("ForkliftQuiz.Core.Entities.User", "User")
                        .WithMany("Quizzes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ForkliftQuiz.Core.Entities.Question", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("ForkliftQuiz.Core.Entities.Quiz", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("ForkliftQuiz.Core.Entities.User", b =>
                {
                    b.Navigation("Quizzes");
                });
#pragma warning restore 612, 618
        }
    }
}
