using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.FileManager.Service
{
    internal class MinIoFileService : IFileService
    {
        private readonly ILogger<MinIoFileService> _logger;


        //stack  
        //heap


        /*private const string str = "123";
        private readonly  string str2 = "123";*/
        public MinIoFileService(IServiceProvider serviceProvider)
        {
            _logger = serviceProvider.GetService<ILogger<MinIoFileService>>();            
        }
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
