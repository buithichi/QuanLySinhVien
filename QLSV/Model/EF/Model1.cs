namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<Lop> Lops { get; set; }
        public virtual DbSet<Nganh> Nganhs { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Khoa>()
                .HasMany(e => e.Nganhs)
                .WithOptional(e => e.Khoa)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Lop>()
                .HasMany(e => e.SinhViens)
                .WithOptional(e => e.Lop)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Nganh>()
                .HasMany(e => e.SinhViens)
                .WithOptional(e => e.Nganh)
                .WillCascadeOnDelete();

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.SoDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.Email)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PassWords)
                .IsUnicode(false);
        }
    }
}
