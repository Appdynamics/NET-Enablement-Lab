namespace JobManagement
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class JobsModel : DbContext
    {
        public JobsModel(string cs)
            : base(cs)
        {
        }

        static JobsModel()
        {
            Database.SetInitializer(new NullDatabaseInitializer<JobsModel>()); // Call once.
            // Equivalent to: Database.SetInitializer<AdventureWorks>(null);
        }

        public virtual DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Job>()
                .Property(e => e.guid)
                .IsFixedLength();

            modelBuilder.Entity<Job>()
                .Property(e => e.data)
                .IsUnicode(false);

            modelBuilder.Entity<Job>()
                .Property(e => e.jobid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }
}
