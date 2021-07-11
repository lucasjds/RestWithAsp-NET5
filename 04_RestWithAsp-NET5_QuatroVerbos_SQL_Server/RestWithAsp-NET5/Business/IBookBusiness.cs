﻿using RestWithAsp_NET5.Data.VO;
using RestWithAsp_NET5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAsp_NET5.Business
{
  public interface IBookBusiness
  {
    BookVO Create(BookVO book);
    BookVO FindByID(long id);
    List<BookVO> FindAll();
    BookVO Update(BookVO book);
    void Delete(long id);
  }
}
