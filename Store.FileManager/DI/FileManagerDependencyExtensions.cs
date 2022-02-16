using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Store.FileManager.Service;

namespace Store.FileManager.DI;
public static class FileManagerDependencyExtensions
{

    public static void AddFileManager(this IServiceCollection services, IConfiguration Configuration)
    {

        //services.Configure<FileSetting>(Configuration.GetSection(nameof(FileSetting)));
        services.AddSingleton<IFileService, DirectoryFileService>();
    }
}

