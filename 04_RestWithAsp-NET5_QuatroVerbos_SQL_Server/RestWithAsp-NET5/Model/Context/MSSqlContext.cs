using Microsoft.EntityFrameworkCore;

namespace RestWithAsp_NET5.Model.Context
{
  public class MSSqlContext : DbContext
  {
    public MSSqlContext() { }
    public MSSqlContext(DbContextOptions<MSSqlContext> options) : base(options) { }
    public DbSet<Person> Persons { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
  }
}
