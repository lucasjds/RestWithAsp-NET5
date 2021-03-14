using System.Collections.Generic;

namespace RestWithAsp_NET5.Hypermedia.Abstract
{
  public interface ISupportsHypermedia
  {
    List<HyperMediaLink> Links { get; set; }
  }
}
