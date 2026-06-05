using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace UCS.Database
{
    internal class ucrdbEntities : DbContext
    {
        public ucrdbEntities(string connectionString) : base(IsFullEntityConnectionString(connectionString) ? connectionString : "name=" + connectionString)
        {
        }

        private static bool IsFullEntityConnectionString(string cs)
        {
            if (string.IsNullOrEmpty(cs))
                return false;
            return cs.IndexOf("metadata=", StringComparison.OrdinalIgnoreCase) >= 0;
        }

        public virtual DbSet<clan> clan { get; set; }

        public virtual DbSet<player> player { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    }
}