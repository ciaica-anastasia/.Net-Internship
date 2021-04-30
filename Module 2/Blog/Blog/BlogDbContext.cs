using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Blog
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext()
        :base("mssql")
        {
            
        }
        
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime? Published { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }

    public class Comment
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Text { get; set; }
        public virtual Post Post { get; set; } //tells EF Core a one-to-many relation between posts and comments
    }
    
}