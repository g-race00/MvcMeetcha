using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MvcMeetcha.Pages
{
    public static class CustomHelper
    {
        public static string UrlPart(PageModel pageModel, int i)
        {
            var parts = pageModel.HttpContext.Request.Path.Value.Split('/');

            if (i >= parts.Length)
            {
                return "";
            }

            return parts[i];
        }

        public static async Task<string> SaveImageAsync(string webRootPath, IFormFile? imageFile)
        {
            if (imageFile == null)
            {
                return "";
            }

            if (imageFile.Length <= 0)
            {
                return "";
            }

            var imageName = Path.GetRandomFileName().Replace(".", "")
                + Path.GetExtension(imageFile.FileName);

            var filePath = Path.Combine($"{webRootPath}/data/images/{imageName}");

            using (var stream = File.Create(filePath))
            {
                await imageFile.CopyToAsync(stream);
            }

            return imageName;
        }

        public static void DeleteImage(string webRootPath, string imageName)
        {
            string filePath = $"{webRootPath}/data/images/{imageName}";

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }
        }
    }
}
