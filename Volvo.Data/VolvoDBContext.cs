using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Volvo.Data
{
    public class VolvoDBContext : DbContext
    {
        public VolvoDBContext() : base()
        {

        }
        public VolvoDBContext(DbContextOptions<VolvoDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseSerialColumns();
        }
        public DbSet<Caminhao> Caminhoes { get; set; }
    }
}
