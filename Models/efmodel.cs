using Microsoft.EntityFrameworkCore;
using System;
namespace quizartsocial_backend.Models
{
    public class efmodel : DbContext
    {
        public DbSet<category> category_table { get; set; }
        public DbSet<comments> comments_table{get; set;}
        public DbSet<post> post_table{get; set;}
        public DbSet<user> user_table{get; set;}


      public efmodel(DbContextOptions<efmodel> options): base(options){}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=ToDoNotes_4;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<category>().HasMany(n => n.posts).WithOne().HasForeignKey(c => c.CategoryForeignKey);
            modelBuilder.Entity<post>().HasMany(n=>n.comment_data).WithOne().HasForeignKey(c=> c.PostForeignKey);
            
            modelBuilder.Entity<user>().HasMany(n => n.posts).WithOne().HasForeignKey(c => c.UserForeignKey).OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<user>().HasMany(n=>n.comment_data).WithOne().HasForeignKey(c => c.UsercomForeignKey).OnDelete(DeleteBehavior.Restrict);



        } 
    }
}