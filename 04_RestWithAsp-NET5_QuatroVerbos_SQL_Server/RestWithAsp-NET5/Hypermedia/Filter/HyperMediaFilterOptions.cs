using RestWithAsp_NET5.Hypermedia.Abstract;
using System.Collections.Generic;

namespace RestWithAsp_NET5.Hypermedia.Filter
{
  public class HyperMediaFilterOptions
  {
    public List<IResponseEnricher> ContentResponseEnricherList { get; set; } = new List<IResponseEnricher>();
  }
}
