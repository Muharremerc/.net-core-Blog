using Blog.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.DAL
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        {
        }
        //private static BlogDbContext testDb;

        //public static BlogDbContext testInstance()
        //{
        //    if (testDb == null)
        //        testDb = new BlogDbContext();
        //    return testDb;
        //}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasOne(x => x.Member).WithMany(x => x.Comments).HasForeignKey(x => x.MemberID);
            modelBuilder.Entity<Comment>().HasOne(x => x.Subject).WithMany(x => x.Comments).HasForeignKey(x => x.SubjectID);
        }

        public virtual DbSet<Member> Members{ get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<SubjectCategory> SubjectCategories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
    }
}