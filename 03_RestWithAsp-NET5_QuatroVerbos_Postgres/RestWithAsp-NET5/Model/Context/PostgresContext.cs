using Microsoft.EntityFrameworkCore;

namespace RestWithAsp_NET5.Model.Context
{
  public class PostgresContext : DbContext
  {
    public PostgresContext() { }
    public PostgresContext(DbContextOptions<PostgresContext> options) : base(options) { }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
  }
}
