using Microsoft.AspNetCore.Http;
using RestWithAsp_NET5.Data.VO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAsp_NET5.Business.Implementations
{
  public class FileBusiness : IFileBusiness
  {
    private readonly string _basePath;
    private readonly IHttpContextAccessor _context;

    public FileBusiness(IHttpContextAccessor context)
    {
      _context = context;
      _basePath = Directory.GetCurrentDirectory() + "\\UploadDir\\";
    }

    public byte[] GetFile(string fileName)
    {
      throw new NotImplementedException();
    }

    public Task<FileDetailVO> SaveFileToDisk(IFormFile file)
    {
      throw new NotImplementedException();
    }

    public Task<List<FileDetailVO>> SavesFileToDisk(IList<IFormFile> file)
    {
      throw new NotImplementedException();
    }
  }
}
