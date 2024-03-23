﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using movieSiteAgainAgain.Data;

#nullable disable

namespace movieSiteAgainAgain.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230516095138_final1")]
    partial class final1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("movieSiteAgainAgain.Models.Actor", b =>
                {
                    b.Property<int>("actorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("actorId"));

                    b.Property<string>("actorDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("actorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("actorPicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("actorId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("movieSiteAgainAgain.Models.ActorInMovie", b =>
                {
                    b.Property<int>("actorId")
                        .HasColumnType("int");

                    b.Property<int>("movieId")
                        .HasColumnType("int");

                    b.Property<string>("actName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("movName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("movYear")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("roleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("actorId", "movieId");

                    b.HasIndex("movieId");

                    b.ToTable("ActorInMovies");
                });

            modelBuilder.Entity("movieSiteAgainAgain.Models.Movie", b =>
                {
                    b.Property<int>("movieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("movieId"));

                    b.Property<double>("averageRating")
                        .HasColumnType("float");

                    b.Property<string>("date")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("directors")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("genre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("keyWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("movieMMPA")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("movieName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("poster")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("runTime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("trailer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("writers")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("movieId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("movieSiteAgainAgain.Models.User", b =>
                {
                    b.Property<string>("userEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userAccountName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("userAvatar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userEmail");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("movieSiteAgainAgain.Models.UserFavoriteMovief", b =>
                {
                    b.Property<string>("userEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("movieId")
                        .HasColumnType("int");

                    b.HasKey("userEmail", "movieId");

                    b.HasIndex("movieId");

                    b.ToTable("UserFavoriteMoviefs");
                });

            modelBuilder.Entity("movieSiteAgainAgain.Models.UserRatedMovie", b =>
                {
                    b.Property<string>("userEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("movieId")
                        .HasColumnType("int");

                    b.Property<string>("rate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userEmail", "movieId");

                    b.HasIndex("movieId");

                    b.ToTable("UserRatedMovies");
                });

            modelBuilder.Entity("movieSiteAgainAgain.Models.UserReviewMovie", b =>
                {
                    b.Property<string>("userEmail")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("movieId")
                        .HasColumnType("int");

                    b.Property<string>("headReview")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("movieReview")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("reviewDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userEmail", "movieId");

                    b.HasIndex("movieId");

                    b.ToTable("UserReviewMovies");
                });

            modelBuilder.Entity("movieSiteAgainAgain.Models.ActorInMovie", b =>
                {
                    b.HasOne("movieSiteAgainAgain.Models.Actor", "Actor")
                        .WithMany("ActorInMovies")
                        .HasForeignKey("actorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("movieSiteAgainAgain.Models.Movie", "Movie")
                        .WithMany("ActorInMovies")
                        .HasForeignKey("movieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("movieSiteAgainAgain.Models.UserFavoriteMovief", b =>
                {
                    b.HasOne("movieSiteAgainAgain.Models.Movie", "Movie")
                        .WithMany("UserFavoriteMoviefs")
                        .HasForeignKey("movieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("movieSiteAgainAgain.Models.User", "User")
                        .WithMany("UserFavoriteMoviefs")
                        .HasForeignKey("userEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("movieSiteAgainAgain.Models.UserRatedMovie", b =>
                {
                    b.HasOne("movieSiteAgainAgain.Models.Movie", "Movie")
                        .WithMany("UserRatedMovies")
                        .HasForeignKey("movieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("movieSiteAgainAgain.Models.User", "User")
                        .WithMany("UserRatedMovies")
                        .HasForeignKey("userEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("movieSiteAgainAgain.Models.UserReviewMovie", b =>
                {
                    b.HasOne("movieSiteAgainAgain.Models.Movie", "Movie")
                        .WithMany("UserReviewMovies")
                        .HasForeignKey("movieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("movieSiteAgainAgain.Models.User", "User")
                        .WithMany("UserReviewMovies")
                        .HasForeignKey("userEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("User");
                });

            modelBuilder.Entity("movieSiteAgainAgain.Models.Actor", b =>
                {
                    b.Navigation("ActorInMovies");
                });

            modelBuilder.Entity("movieSiteAgainAgain.Models.Movie", b =>
                {
                    b.Navigation("ActorInMovies");

                    b.Navigation("UserFavoriteMoviefs");

                    b.Navigation("UserRatedMovies");

                    b.Navigation("UserReviewMovies");
                });

            modelBuilder.Entity("movieSiteAgainAgain.Models.User", b =>
                {
                    b.Navigation("UserFavoriteMoviefs");

                    b.Navigation("UserRatedMovies");

                    b.Navigation("UserReviewMovies");
                });
#pragma warning restore 612, 618
        }
    }
}
