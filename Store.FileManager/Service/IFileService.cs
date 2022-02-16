using Microsoft.AspNetCore.Http;

namespace Store.FileManager.Service
{
    public interface IFileService
    {
        Task<string> SaveFileAsync(IFormFile file);
        Task<FileInfo> GetFileByIdAsync(string id);

    }
}
