using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace vue_webApi.Entities
{
    /// <summary>
    /// 上下文
    /// </summary>
    public partial class AskquestionsContext : DbContext
    {
        public AskquestionsContext()
        {
        }

        public AskquestionsContext(DbContextOptions<AskquestionsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<CommentsPraise> CommentsPraise { get; set; }
        public virtual DbSet<QuestionPraise> QuestionPraise { get; set; }
        public virtual DbSet<Questions> Questions { get; set; }
        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=DESKTOP-E5UR13B;uid=sa;pwd=sa;database=Askquestions");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.ToTable("comments");

                entity.Property(e => e.Caicai)
                    .HasColumnName("caicai")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasComment("评论");

                entity.Property(e => e.Praise)
                    .HasColumnName("praise")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QuestionId).HasColumnName("questionId");
            });

            modelBuilder.Entity<CommentsPraise>(entity =>
            {
                entity.ToTable("commentsPraise");

                entity.Property(e => e.CommentId)
                    .HasColumnName("commentId")
                    .HasComment("评论id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId).HasComment("点赞人");
            });

            modelBuilder.Entity<QuestionPraise>(entity =>
            {
                entity.ToTable("questionPraise");

                entity.Property(e => e.QuestionsId).HasColumnName("questionsId");

                entity.Property(e => e.UserId).HasColumnName("userId");
            });

            modelBuilder.Entity<Questions>(entity =>
            {
                entity.ToTable("questions");

                entity.Property(e => e.Comment)
                    .HasColumnName("comment")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Contents).HasColumnName("contents");

                entity.Property(e => e.Created)
                    .HasColumnName("created")
                    .HasMaxLength(50);

                entity.Property(e => e.Praise)
                    .HasColumnName("praise")
                    .HasComment("赞数量");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasColumnName("title")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Tags>(entity =>
            {
                entity.Property(e => e.TagName)
                    .HasColumnName("tagName")
                    .HasMaxLength(50)
                    .HasComment("标签");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.CreateTime)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasDefaultValueSql("((123))");

                entity.Property(e => e.Integral)
                    .HasColumnName("integral")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PassWord)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(100);

                entity.Property(e => e.Token).HasMaxLength(100);

                entity.Property(e => e.Type)
                    .HasDefaultValueSql("((2))")
                    .HasComment("1商家，2 买家");

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
