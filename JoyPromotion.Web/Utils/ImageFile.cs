using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace JoyPromotion.Web.Utils
{
    public class ImageFile
    {
        public void Upload(IFormFile image, out string imageUrl)
        {
            var imageName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            var path = Directory.GetCurrentDirectory() + "/wwwroot/img/" + imageName;
            var stream = new FileStream(path, FileMode.Create);
            image.CopyTo(stream);
            imageUrl = imageName;
        }
    }
}
