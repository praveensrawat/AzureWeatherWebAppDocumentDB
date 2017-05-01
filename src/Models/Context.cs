namespace weather.Models
{
    using System.Data.Entity;

    public class Context : DbContext
    {
        public Context() : base("name=Context")
        {
        }

        public DbSet<Weather> Items { get; set; }
    }
}
