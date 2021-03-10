using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;

namespace RestWithAsp_NET5.Hypermedia.Abstract
{
  public interface IResponseEnricher
  {
    bool CanEnrich(ResultExecutedContext context);
    Task Enrich(ResultExecutedContext context);
  }
}
