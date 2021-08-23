namespace Nichicon_PrintLabel.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataConnection")
        {
        }

        public virtual DbSet<Nichicon_HistoriesSerial1> Nichicon_HistoriesSerial1 { get; set; }
        public virtual DbSet<Nichicon_HistoriesSerial2> Nichicon_HistoriesSerial2 { get; set; }
        public virtual DbSet<Nichicon_ItemSeiral1> Nichicon_ItemSeiral1 { get; set; }
        public virtual DbSet<Nichicon_ItemSerial2> Nichicon_ItemSerial2 { get; set; }
        public virtual DbSet<Nichicon_model> Nichicon_model { get; set; }
        public virtual DbSet<Nichicon_Users> Nichicon_Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
