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

    public async Task<FileDetailVO> SaveFileToDisk(IFormFile file)
    {
      FileDetailVO fileDetail = new FileDetailVO();
      var fileType = Path.GetExtension(file.FileName);
      var baseUrl = _context.HttpContext.Request.Host;

      if (fileType.ToLower() == ".pdf" || fileType.ToLower() == ".jpg"
        || fileType.ToLower() == ".png" || fileType.ToLower() == ".jpeg")
      {
        var docName = Path.GetFileName(file.FileName);
        if (file != null && file.Length > 0)
        {
          var destination = Path.Combine(_basePath, "", docName);
          fileDetail.DocumentName = docName;
          fileDetail.DocType = fileType;
          fileDetail.DocUrl = Path.Combine(baseUrl + "/api/file/v1/" + fileDetail.DocumentName);

          using var stream = new FileStream(destination, FileMode.Create);
          await file.CopyToAsync(stream);
        }
      }
      return fileDetail;
    }

    public Task<List<FileDetailVO>> SavesFileToDisk(IList<IFormFile> file)
    {
      throw new NotImplementedException();
    }
  }
}
