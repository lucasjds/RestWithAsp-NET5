﻿using System.Collections.Generic;

namespace RestWithAsp_NET5.Hypermedia.Abstract
{
  public interface ISupportHypermedia
  {
    List<HyperMediaLink> Links { get; set; }
  }
}
