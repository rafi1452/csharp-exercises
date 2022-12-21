using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Exercises.DataObjects
{
    public partial class sampleContext : DbContext
    {
        public sampleContext()
        {
        }

        public sampleContext(DbContextOptions<sampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Article> Articles { get; set; } = null!;
        public virtual DbSet<ArticleChat> ArticleChats { get; set; } = null!;
        public virtual DbSet<ArticleDraft> ArticleDrafts { get; set; } = null!;
        public virtual DbSet<ArticleStat> ArticleStats { get; set; } = null!;
        public virtual DbSet<ArticleTag> ArticleTags { get; set; } = null!;
        public virtual DbSet<ArticleVersion> ArticleVersions { get; set; } = null!;
        public virtual DbSet<Tag> Tags { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserProfile> UserProfiles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=8080;user=root;password=1234;database=sample", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("articles");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Access, "idx_access");

                entity.HasIndex(e => e.Alias, "idx_alias")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 191 });

                entity.HasIndex(e => e.Catid, "idx_catid");

                entity.HasIndex(e => e.CheckedOut, "idx_checkout");

                entity.HasIndex(e => e.CreatedBy, "idx_createdby");

                entity.HasIndex(e => new { e.Featured, e.Catid }, "idx_featured_catid");

                entity.HasIndex(e => e.Language, "idx_language");

                entity.HasIndex(e => e.State, "idx_state");

                entity.HasIndex(e => e.Xreference, "idx_xreference");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Access).HasColumnName("access");

                entity.Property(e => e.Alias)
                    .HasMaxLength(400)
                    .HasColumnName("alias")
                    .HasDefaultValueSql("''")
                    .UseCollation("utf8mb4_bin");

                entity.Property(e => e.AssetId)
                    .HasColumnName("asset_id")
                    .HasComment("FK to the #__assets table.");

                entity.Property(e => e.Attribs)
                    .HasMaxLength(5120)
                    .HasColumnName("attribs");

                entity.Property(e => e.Catid).HasColumnName("catid");

                entity.Property(e => e.CheckedOut).HasColumnName("checked_out");

                entity.Property(e => e.CheckedOutTime)
                    .HasColumnType("datetime")
                    .HasColumnName("checked_out_time")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.CreatedBy).HasColumnName("created_by");

                entity.Property(e => e.CreatedByAlias)
                    .HasMaxLength(255)
                    .HasColumnName("created_by_alias")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Featured)
                    .HasColumnName("featured")
                    .HasComment("Set if article is featured.");

                entity.Property(e => e.Fulltext)
                    .HasColumnType("mediumtext")
                    .HasColumnName("fulltext");

                entity.Property(e => e.Hits).HasColumnName("hits");

                entity.Property(e => e.Images)
                    .HasColumnType("text")
                    .HasColumnName("images");

                entity.Property(e => e.Introtext)
                    .HasColumnType("mediumtext")
                    .HasColumnName("introtext");

                entity.Property(e => e.Language)
                    .HasMaxLength(7)
                    .HasColumnName("language")
                    .IsFixedLength()
                    .HasComment("The language code for the article.");

                entity.Property(e => e.Metadata)
                    .HasColumnType("text")
                    .HasColumnName("metadata");

                entity.Property(e => e.Metadesc)
                    .HasColumnType("text")
                    .HasColumnName("metadesc");

                entity.Property(e => e.Metakey)
                    .HasColumnType("text")
                    .HasColumnName("metakey");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasColumnName("modified")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .HasColumnName("note")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Ordering).HasColumnName("ordering");

                entity.Property(e => e.PublishDown)
                    .HasColumnType("datetime")
                    .HasColumnName("publish_down")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.PublishUp)
                    .HasColumnType("datetime")
                    .HasColumnName("publish_up")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Urls)
                    .HasColumnType("text")
                    .HasColumnName("urls");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Xreference)
                    .HasMaxLength(50)
                    .HasColumnName("xreference")
                    .HasDefaultValueSql("''")
                    .HasComment("A reference to enable linkages to external data sets.");
            });

            modelBuilder.Entity<ArticleChat>(entity =>
            {
                entity.ToTable("article_chats");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.ContentId, "idx_content_id");

                entity.HasIndex(e => e.UserId, "idx_user_id");

                entity.HasIndex(e => e.VersionId, "idx_version_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Primary Key");

                entity.Property(e => e.ContentId).HasColumnName("content_id");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasColumnName("modified")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Msg)
                    .HasColumnType("text")
                    .HasColumnName("msg");

                entity.Property(e => e.Section)
                    .HasMaxLength(255)
                    .HasColumnName("section")
                    .HasDefaultValueSql("'All Sections'");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.VersionId).HasColumnName("version_id");
            });

            modelBuilder.Entity<ArticleDraft>(entity =>
            {
                entity.ToTable("article_drafts");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasComment("Primary Key");

                entity.Property(e => e.ContentId).HasColumnName("content_id");

                entity.Property(e => e.Introtext)
                    .HasColumnType("mediumtext")
                    .HasColumnName("introtext");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasColumnName("modified")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.ModifiedBy).HasColumnName("modified_by");

                entity.Property(e => e.State)
                    .HasColumnType("enum('Private','Review Pending','Approved','Rejected')")
                    .HasColumnName("state")
                    .HasDefaultValueSql("'Private'");

                entity.Property(e => e.Tags)
                    .HasMaxLength(255)
                    .HasColumnName("tags")
                    .HasDefaultValueSql("''")
                    .HasComment("Comma-separated list of tag IDs");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasComment("Base article version");

                entity.Property(e => e.VersionNote)
                    .HasMaxLength(255)
                    .HasColumnName("version_note")
                    .HasDefaultValueSql("''")
                    .HasComment("Optional version name");
            });

            modelBuilder.Entity<ArticleStat>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("article_stats");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.ItemId, e.Type }, "idx_item_id_type")
                    .IsUnique();

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .HasComment("fkd5g_content.id");

                entity.Property(e => e.Type)
                    .HasColumnType("enum('SummaryWords','DiscussionWords','MilestonesWords','SummaryCitations','DiscussionCitations','MilestonesCitations','Milestones','Questions','References','SeeAlso','FurtherReading','SampleCode','SampleCodeLines','Images','Videos','Audios','Quotes','Warnings')")
                    .HasColumnName("type");
            });

            modelBuilder.Entity<ArticleTag>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("article_tags");

                entity.HasComment("Maps items from content tables to tags")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.CoreContentId, "idx_core_content_id");

                entity.HasIndex(e => new { e.TagDate, e.TagId }, "idx_date_id");

                entity.HasIndex(e => new { e.TagId, e.TypeId }, "idx_tag_type");

                entity.HasIndex(e => new { e.TypeId, e.ContentItemId, e.TagId }, "uc_ItemnameTagid")
                    .IsUnique();

                entity.Property(e => e.ContentItemId)
                    .HasColumnName("content_item_id")
                    .HasComment("PK from the content type table");

                entity.Property(e => e.CoreContentId)
                    .HasColumnName("core_content_id")
                    .HasComment("PK from the core content table");

                entity.Property(e => e.TagDate)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasColumnName("tag_date")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP")
                    .HasComment("Date of most recent save for this tag-item");

                entity.Property(e => e.TagId)
                    .HasColumnName("tag_id")
                    .HasComment("PK from the tag table");

                entity.Property(e => e.TypeAlias)
                    .HasMaxLength(255)
                    .HasColumnName("type_alias")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.TypeId)
                    .HasColumnType("mediumint")
                    .HasColumnName("type_id")
                    .HasComment("PK from the content_type table");
            });

            modelBuilder.Entity<ArticleVersion>(entity =>
            {
                entity.HasKey(e => e.VersionId)
                    .HasName("PRIMARY");

                entity.ToTable("article_versions");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.SaveDate, "idx_save_date");

                entity.HasIndex(e => new { e.UcmTypeId, e.UcmItemId }, "idx_ucm_item_id");

                entity.Property(e => e.VersionId).HasColumnName("version_id");

                entity.Property(e => e.CharacterCount)
                    .HasColumnName("character_count")
                    .HasComment("Number of characters in this version.");

                entity.Property(e => e.EditorUserId).HasColumnName("editor_user_id");

                entity.Property(e => e.KeepForever)
                    .HasColumnName("keep_forever")
                    .HasComment("0=auto delete; 1=keep");

                entity.Property(e => e.SaveDate)
                    .HasColumnType("datetime")
                    .HasColumnName("save_date")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Sha1Hash)
                    .HasMaxLength(50)
                    .HasColumnName("sha1_hash")
                    .HasDefaultValueSql("''")
                    .HasComment("SHA1 hash of the version_data column.");

                entity.Property(e => e.UcmItemId).HasColumnName("ucm_item_id");

                entity.Property(e => e.UcmTypeId).HasColumnName("ucm_type_id");

                entity.Property(e => e.VersionData)
                    .HasColumnType("mediumtext")
                    .HasColumnName("version_data")
                    .HasComment("json-encoded string of version data");

                entity.Property(e => e.VersionNote)
                    .HasMaxLength(255)
                    .HasColumnName("version_note")
                    .HasDefaultValueSql("''")
                    .HasComment("Optional version name");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.ToTable("tags");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Access, "idx_access");

                entity.HasIndex(e => e.Alias, "idx_alias")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 100 });

                entity.HasIndex(e => e.CheckedOut, "idx_checkout");

                entity.HasIndex(e => e.Language, "idx_language");

                entity.HasIndex(e => new { e.Lft, e.Rgt }, "idx_left_right");

                entity.HasIndex(e => e.Path, "idx_path")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 100 });

                entity.HasIndex(e => new { e.Published, e.Access }, "tag_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Access).HasColumnName("access");

                entity.Property(e => e.Alias)
                    .HasMaxLength(400)
                    .HasColumnName("alias")
                    .HasDefaultValueSql("''")
                    .UseCollation("utf8mb4_bin");

                entity.Property(e => e.CheckedOut).HasColumnName("checked_out");

                entity.Property(e => e.CheckedOutTime)
                    .HasColumnType("datetime")
                    .HasColumnName("checked_out_time")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.CreatedByAlias)
                    .HasMaxLength(255)
                    .HasColumnName("created_by_alias")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CreatedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("created_time")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.CreatedUserId).HasColumnName("created_user_id");

                entity.Property(e => e.Description)
                    .HasColumnType("mediumtext")
                    .HasColumnName("description");

                entity.Property(e => e.Hits).HasColumnName("hits");

                entity.Property(e => e.Images)
                    .HasColumnType("text")
                    .HasColumnName("images");

                entity.Property(e => e.Language)
                    .HasMaxLength(7)
                    .HasColumnName("language")
                    .IsFixedLength();

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Lft).HasColumnName("lft");

                entity.Property(e => e.Metadata)
                    .HasMaxLength(2048)
                    .HasColumnName("metadata")
                    .HasComment("JSON encoded metadata properties.");

                entity.Property(e => e.Metadesc)
                    .HasMaxLength(1024)
                    .HasColumnName("metadesc")
                    .HasComment("The meta description for the page.");

                entity.Property(e => e.Metakey)
                    .HasMaxLength(1024)
                    .HasColumnName("metakey")
                    .HasComment("The meta keywords for the page.");

                entity.Property(e => e.ModifiedTime)
                    .HasColumnType("datetime")
                    .HasColumnName("modified_time")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.ModifiedUserId).HasColumnName("modified_user_id");

                entity.Property(e => e.Note)
                    .HasMaxLength(255)
                    .HasColumnName("note")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Params)
                    .HasColumnType("text")
                    .HasColumnName("params");

                entity.Property(e => e.ParentId).HasColumnName("parent_id");

                entity.Property(e => e.Path)
                    .HasMaxLength(400)
                    .HasColumnName("path")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PublishDown)
                    .HasColumnType("datetime")
                    .HasColumnName("publish_down")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.PublishUp)
                    .HasColumnType("datetime")
                    .HasColumnName("publish_up")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Published).HasColumnName("published");

                entity.Property(e => e.Rgt).HasColumnName("rgt");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .HasColumnName("title");

                entity.Property(e => e.Urls)
                    .HasColumnType("text")
                    .HasColumnName("urls");

                entity.Property(e => e.Version)
                    .HasColumnName("version")
                    .HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => e.Email, "email");

                entity.HasIndex(e => e.Block, "idx_block");

                entity.HasIndex(e => e.Name, "idx_name")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 100 });

                entity.HasIndex(e => e.Username, "username");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Activation)
                    .HasMaxLength(100)
                    .HasColumnName("activation")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Block).HasColumnName("block");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("email")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.LastResetTime)
                    .HasColumnType("datetime")
                    .HasColumnName("lastResetTime")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'")
                    .HasComment("Date of last password reset");

                entity.Property(e => e.LastvisitDate)
                    .HasColumnType("datetime")
                    .HasColumnName("lastvisitDate")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.Name)
                    .HasMaxLength(400)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Otep)
                    .HasMaxLength(1000)
                    .HasColumnName("otep")
                    .HasDefaultValueSql("''")
                    .HasComment("One time emergency passwords");

                entity.Property(e => e.OtpKey)
                    .HasMaxLength(1000)
                    .HasColumnName("otpKey")
                    .HasDefaultValueSql("''")
                    .HasComment("Two factor authentication encrypted keys");

                entity.Property(e => e.Params)
                    .HasColumnType("text")
                    .HasColumnName("params");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.RegisterDate)
                    .HasColumnType("datetime")
                    .HasColumnName("registerDate")
                    .HasDefaultValueSql("'0000-00-00 00:00:00'");

                entity.Property(e => e.RequireReset)
                    .HasColumnName("requireReset")
                    .HasComment("Require user to reset password on next login");

                entity.Property(e => e.ResetCount)
                    .HasColumnName("resetCount")
                    .HasComment("Count of password resets since lastResetTime");

                entity.Property(e => e.SendEmail)
                    .HasColumnName("sendEmail")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Username)
                    .HasMaxLength(150)
                    .HasColumnName("username")
                    .HasDefaultValueSql("''");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("user_profiles");

                entity.HasComment("Simple user profile storage table")
                    .UseCollation("utf8mb4_unicode_ci");

                entity.HasIndex(e => new { e.UserId, e.ProfileKey }, "idx_user_id_profile_key")
                    .IsUnique();

                entity.Property(e => e.Ordering).HasColumnName("ordering");

                entity.Property(e => e.ProfileKey)
                    .HasMaxLength(100)
                    .HasColumnName("profile_key");

                entity.Property(e => e.ProfileValue)
                    .HasColumnType("text")
                    .HasColumnName("profile_value");

                entity.Property(e => e.UserId).HasColumnName("user_id");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
