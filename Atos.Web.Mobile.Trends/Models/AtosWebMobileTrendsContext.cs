using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Atos.Web.Mobile.Trends.Models
{
    public class AtosWebMobileTrendsContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Atos.Web.Mobile.Trends.Models.AtosWebMobileTrendsContext>());

        public DbSet<Atos.Web.Mobile.Trends.Models.Answer> Answers { get; set; }

        public DbSet<Atos.Web.Mobile.Trends.Models.Question> Questions { get; set; }

        public DbSet<Atos.Web.Mobile.Trends.Models.Browser> Browsers { get; set; }

        public DbSet<Atos.Web.Mobile.Trends.Models.User> Users { get; set; }
    }
}