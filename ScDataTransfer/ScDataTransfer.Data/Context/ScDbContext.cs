using ScDataTransfer.Data.Entities;
using System.Data.Entity;

namespace ScDataTransfer.Data.Context
{
    public class ScDbContext : DbContext
    {
        public ScDbContext(string connectionStr):base(connectionStr)
        {
            Database.SetInitializer<ScDbContext>(null);
        }
        
        public virtual DbSet<DescendantRow> Descendants { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<SharedField> SharedFields { get; set; }
        public virtual DbSet<UnversionedField> UnversionedFields { get; set; }
        public virtual DbSet<VersionedField> VersionedFields { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasMany<VersionedField>(i => i.VersionedFields).WithRequired(vf => vf.Item).HasForeignKey(vf => vf.ItemId);
            modelBuilder.Entity<Item>().HasMany<UnversionedField>(i => i.UnversionedFields).WithRequired(uf => uf.Item).HasForeignKey(uf => uf.ItemId);
            modelBuilder.Entity<Item>().HasMany<SharedField>(i => i.SharedFields).WithRequired(sf => sf.Item).HasForeignKey(sf => sf.ItemId);
            modelBuilder.Entity<Item>().HasMany<DescendantRow>(i => i.DescTableRowsByDescendantId).WithRequired(d => d.SelectedDescendantItem).HasForeignKey(d => d.Descendant);
        }
    }
}
