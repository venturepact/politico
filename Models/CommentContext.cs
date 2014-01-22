using System.Data.Entity;

namespace Politico.Models
{
    public class CommentContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<Politico.Models.CommentContext>());

        public CommentContext() : base("name=CommentContext")
        {
        }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<MP> MPs { get; set; }

        public DbSet<Sector> Sectors { get; set; }

        public DbSet<Member> Members { get; set; }
    }
}
