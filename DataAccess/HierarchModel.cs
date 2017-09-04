using DataAccess.DataTypes;

namespace DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public partial class HierarchModel : DbContext
    {
        public HierarchModel()
            : base("name=HierarchModel")
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Standard> Standards { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
