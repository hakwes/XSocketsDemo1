using System.Data.Entity;
using XSocketsDemo.Core;

namespace XSocketsDemo.Data
{
    public class EfContext : DbContext
    {
        //Register entities
        public DbSet<Person> People { get; set; }
        public DbSet<Fruit> Fruits { get; set; }
        public DbSet<Color> Colors { get; set; }

        public EfContext()
            : this(true)
        {
        }

        public EfContext(bool proxyCreation = true)
        {
            this.Configuration.ProxyCreationEnabled = proxyCreation;

            //[DropAndReCreate if in debug and model is changed. ONLY FOR DEVELOPMENT!!!]			
            if (System.Diagnostics.Debugger.IsAttached)
                Database.SetInitializer(new DataSeeder());
        }
    }
}