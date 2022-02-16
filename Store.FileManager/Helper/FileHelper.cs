using Microsoft.AspNetCore.Http;
using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography;

namespace Store.FileManager.Helper
{
    public class FileHelper
    {
        public static void WriteThumbnailImage(string filename, string path, int width, int height, IFormFile imageFile)
        {
            try
            {
                var resourceImage = imageFile.OpenReadStream();
                var image = Image.FromStream(resourceImage);
                var thumb = image.GetThumbnailImage(width, height, () => false, IntPtr.Zero);
                thumb.Save($"{path}\\thumb_{filename}", ImageFormat.Jpeg);
            }
            catch (Exception e)
            {
            }
        }


        public static string GetFileHashMd5(IFormFile file)
        {
            string hashCode = "";
            using (var md5 = SHA256.Create())
            {
                using (var stream = file.OpenReadStream())
                {
                    var hash = md5.ComputeHash(stream);
                    hashCode = BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }

            return hashCode;
        }
    }
}