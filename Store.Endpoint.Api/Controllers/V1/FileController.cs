using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.FileManager.Helper;
using Store.FileManager.Service;

namespace Store.Endpoint.Api.Controllers.V1
{
    [ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class FileController : ControllerBase
    {
        private readonly ILogger<FileController> _logger;
        private readonly IFileService _fileService;

        public FileController(ILogger<FileController> logger, IFileService fileService )
        {
            _logger = logger;
            _fileService = fileService;
        }



        [HttpPost("Upload")]
        [FileValidator]
        public async Task<ActionResult<string>> UploadFileAsync(IFormFile file)
        {            
            var id = await _fileService.SaveFileAsync(file);
            return Ok(id);
        }

        [HttpGet("Download/{id}")]
        public async Task<FileContentResult> DownloadFile(string id)
        {
            var fileInfo = await _fileService.GetFileByIdAsync(id);
            byte[] fileBytes = System.IO.File.ReadAllBytes(fileInfo?.FullName);
            return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileInfo.Name);

        }


    }
}
