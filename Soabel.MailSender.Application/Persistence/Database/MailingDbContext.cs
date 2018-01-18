using Soabel.MailSender.Application.Entitties;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soabel.MailSender.Application.Persistence.Database
{
    public class MailingDbContext: DbContext
    {
        public MailingDbContext() {
            
        }

        public DbSet<Parametro> Parametro { get; set; }
        public DbSet<Template> Template { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);            
        }

       

    }
}
