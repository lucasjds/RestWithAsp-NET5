using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAsp_NET5.Model
{
  [Table("books")]
  public class Book
  {
    [Column("id")]
    public long Id { get; set; }
    [Column("author")]
    public string Author { get; set; }
    [Column("lauch_date")]
    public DateTime LauchTime { get; set; }
    [Column("price")]
    public decimal Price { get; set; }
    [Column("title")]
    public string Title { get; set; }
  }
}
