
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.FileManager.Models;
using Store.FileManager.Service;

namespace Store.FileManager.DI;
public static class FileManagerDependencyExtensions
{
    public static void AddFileManager(this IServiceCollection services, IConfiguration Configuration)
    {
        //var key = Configuration["key"].ToString();
        var max = Configuration["FileSettings:MaxFileSize"].ToString();
        services.Configure<FileSettings>(Configuration.GetSection(nameof(FileSettings)));
        services.AddSingleton<IFileService, DirectoryFileService>();
    }
}

