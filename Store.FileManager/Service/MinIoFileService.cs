using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.FileManager.Service
{
    internal class MinIoFileService : IFileService
    {
        public Task<FileInfo> GetFileByIdAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<string> SaveFileAsync(IFormFile file)
        {
            throw new NotImplementedException();
        }
    }
}
