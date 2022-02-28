using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Store.FileManager.Helper;
using System.Net.Http.Headers;

namespace Store.FileManager.Service
{
    internal class DirectoryFileService : IFileService
    {

        private readonly ILogger<DirectoryFileService> _logger;
        //private readonly IOptions<FileSetting> _setting;
        private readonly string BasePath = Path.Combine(Directory.GetCurrentDirectory(), "Contents\\Images\\");
        private string smsProviderAddress;

        public DirectoryFileService(ILogger<DirectoryFileService> logger/*, IConfiguration configuration*/)
        {
            _logger = logger;
            /*smsProviderAddress = configuration["smsProviderAddress"];*/
        }


        public async Task<FileInfo> GetFileByIdAsync(string id)
        {
            var isThumbnailRequested = id.StartsWith("thumb_");
            var uid = isThumbnailRequested ? id.Substring("thumb_".Length) : id;
            var filelist = Directory.EnumerateDirectories($"{BasePath}{uid}");
            var files = new DirectoryInfo($"{BasePath}{uid}").GetFiles();

            var filetoDownload = files.FirstOrDefault(f => isThumbnailRequested ? f.Name.StartsWith("thumb_") : !f.Name.StartsWith("thumb_"));
            //if (filetoDownload == null) throw new AppFileException(ErrorCodeTypes.FileNotFound, HttpStatusCode.NotFound);
            return filetoDownload;
        }

        public async Task<string> SaveFileAsync(IFormFile file)
        {


            var fileId = FileHelper.GetFileHashMd5(file);
            

            var fileName = ContentDispositionHeaderValue
                        .Parse(file.ContentDisposition)
                        .FileName?
                        .Trim('"');
            var storeFilesPath = $"{BasePath}{fileId}";


            // if exist dont save repeative file
            if (Directory.Exists(storeFilesPath)) return fileId;

            CreatePathIfNotExist(storeFilesPath);


            string filePath = Path.Combine(storeFilesPath, fileName);
            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            FileHelper.WriteThumbnailImage(fileName, storeFilesPath, 120, 120, file);
            return fileId;
        }


        private static void CreatePathIfNotExist(string path)
        {
            bool exists = Directory.Exists(path);
            if (!exists)
                Directory.CreateDirectory(path);

        }
    }
}
