using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Store.FileManager.Models;
using Store.FileManager.Service;

namespace Store.FileManager.Helper
{
    public class FileValidatorAttribute : ActionFilterAttribute
    {
        private int _maxFileSize;
        private string _validFileExtensionsInComaSeperate;
        private const int _defaultFileSizeInKB = 1024;
        private const string _defaultFileFormats = "png,jpg,jpeg,jfif,webp";

        public FileValidatorAttribute()
        {

        }

        private void InitializeFileSetting(IOptions<FileSettings> setting)
        {
            _maxFileSize = setting.Value.MaxFileSize;
            if (_maxFileSize == 0) _maxFileSize = _defaultFileSizeInKB;

            _validFileExtensionsInComaSeperate = setting.Value?.AcceptableFormat;
            if (string.IsNullOrEmpty(_validFileExtensionsInComaSeperate)) _validFileExtensionsInComaSeperate = _defaultFileFormats;
        }
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var setting = context.HttpContext.RequestServices.GetRequiredService<IOptions<FileSettings>>();
            var fileService = context.HttpContext.RequestServices.GetRequiredService<IFileService>();
            
            InitializeFileSetting(setting);

            var file = context.HttpContext.Request.Form.Files[0] as IFormFile;
            ValidateSize(file);
            ValidateFileExtension(file);
            await next();
        }


        private void ValidateSize(IFormFile file)
        {
            if (file != null)
            {
                if (file.Length > _maxFileSize * 1024)
                {
                    throw new Exception("ErrorCodeTypes.MaxFileSizeExceeded");
                }
            }
        }

        private void ValidateFileExtension(IFormFile file)
        {
            if (file != null)
            {
                var extension = GetExtension(file);
                if (!_validFileExtensionsInComaSeperate.Split(',').Contains(extension.Replace('.', ' ').Trim().ToLower()))
                {
                    throw new Exception("ErrorCodeTypes.AcceptableFileExtension, System.Net.HttpStatusCode.BadRequest");
                }
            }
        }

        public  string GetExtension( IFormFile file)
        {
            return Path.GetExtension(file.FileName);
        }
    }
}

