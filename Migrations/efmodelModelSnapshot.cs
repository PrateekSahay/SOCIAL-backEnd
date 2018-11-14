﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using quizartsocial_backend.Models;

namespace backEnd.Migrations
{
    [DbContext(typeof(efmodel))]
    partial class efmodelModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("quizartsocial_backend.Models.CommentC", b =>
                {
                    b.Property<int>("comment_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PostForeignKey");

                    b.Property<string>("UsercomForeignKey");

                    b.Property<string>("comment");

                    b.HasKey("comment_id");

                    b.HasIndex("PostForeignKey");

                    b.HasIndex("UsercomForeignKey");

                    b.ToTable("CommentT");
                });

            modelBuilder.Entity("quizartsocial_backend.Models.PostC", b =>
                {
                    b.Property<int>("post_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("TopicForeignKey");

                    b.Property<string>("UserForeignKey");

                    b.Property<string>("posts");

                    b.HasKey("post_id");

                    b.HasIndex("TopicForeignKey");

                    b.HasIndex("UserForeignKey");

                    b.ToTable("PostT");
                });

            modelBuilder.Entity("quizartsocial_backend.Models.TopicC", b =>
                {
                    b.Property<int>("topic_id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("topic_image");

                    b.Property<string>("topic_name");

                    b.HasKey("topic_id");

                    b.ToTable("TopicT");
                });

            modelBuilder.Entity("quizartsocial_backend.Models.UserC", b =>
                {
                    b.Property<string>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("image");

                    b.Property<string>("name");

                    b.Property<int>("score");

                    b.HasKey("id");

                    b.ToTable("UserT");
                });

            modelBuilder.Entity("quizartsocial_backend.Models.CommentC", b =>
                {
                    b.HasOne("quizartsocial_backend.Models.PostC")
                        .WithMany("comment_data")
                        .HasForeignKey("PostForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("quizartsocial_backend.Models.UserC")
                        .WithMany("comment_data")
                        .HasForeignKey("UsercomForeignKey")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("quizartsocial_backend.Models.PostC", b =>
                {
                    b.HasOne("quizartsocial_backend.Models.TopicC")
                        .WithMany("posts")
                        .HasForeignKey("TopicForeignKey")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("quizartsocial_backend.Models.UserC")
                        .WithMany("posts")
                        .HasForeignKey("UserForeignKey")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
