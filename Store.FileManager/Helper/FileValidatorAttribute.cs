using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

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

        /*private void InitializeFileSetting(IOptions<FileSetting> setting)
        {
            _maxFileSize = setting.Value.MaxFileSizeInKB;
            if (_maxFileSize == 0) _maxFileSize = _defaultFileSizeInKB;

            _validFileExtensionsInComaSeperate = setting.Value.AcceptableImageFormats;
            if (string.IsNullOrEmpty(_validFileExtensionsInComaSeperate)) _validFileExtensionsInComaSeperate = _defaultFileFormats;
        }*/
        public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
           /* var setting = context.HttpContext.RequestServices.GetRequiredService<IOptions<FileSetting>>();
            InitializeFileSetting(setting);*/

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

