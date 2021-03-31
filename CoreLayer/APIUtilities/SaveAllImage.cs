using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Attendleave.Erp.Core.APIUtilities
{
    public class SaveAllImage : ISaveAllImage
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public SaveAllImage(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public string SaveImage(string imgStr,string folderName, string imgName)
        {
            try
            {
                var path = _hostingEnvironment.WebRootPath;

                //var file = System.IO.Path.Combine(path, "test.txt");
                if (!Directory.Exists(path.ToString()))
                {
                    Directory.CreateDirectory(path ?? throw new InvalidOperationException());
                }
                string imageName = imgName + ".png";
                string imgPath = Path.Combine(path , "Images", folderName, imageName);
                string convert = imgStr;
                if (imgStr.Contains("data:image/jpeg;base64")) convert = imgStr.Replace("data:image/jpeg;base64,/9j/", string.Empty);
                else if (imgStr.Contains("data:image/Png;base64")) convert = imgStr.Replace("data:image/Png;base64,", string.Empty);
                else if (imgStr.Contains("data:image/Gif;base64")) convert = imgStr.Replace("data:image/Gif;base64,", string.Empty);
                else if (imgStr.Contains("data:application/pdf;base64")) convert = imgStr.Replace("data:application/pdf;base64,", string.Empty);
                else if (imgStr.Contains("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document; base64")) convert = imgStr.Replace("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document; base64,", string.Empty);

                byte[] imageBytes = Convert.FromBase64String(convert);
                File.WriteAllBytes(imgPath, imageBytes);
                return imageName;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

       
        public byte[] SaveImageindataBase(string imgStr, string imgName)
        {
            try
            {
                string convert = imgStr;
                if (imgStr.Contains("data:image/jpeg;base64")) convert = imgStr.Replace("data:image/jpeg;base64,/9j/", string.Empty);
                else if (imgStr.Contains("data:image/Png;base64")) convert = imgStr.Replace("data:image/Png;base64,", string.Empty);
                else if (imgStr.Contains("data:image/Gif;base64")) convert = imgStr.Replace("data:image/Gif;base64,", string.Empty);
                byte[] imageBytes = Convert.FromBase64String(convert);
                return imageBytes;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public bool IsBase64Encoded(String imgStr)
        {
            try
            {
                string convert = imgStr;
                if (imgStr.Contains("data:image/jpeg;base64")) convert = imgStr.Replace("data:image/jpeg;base64,/9j/", string.Empty);
                else if (imgStr.Contains("data:image/Png;base64")) convert = imgStr.Replace("data:image/Png;base64,", string.Empty);
                else if (imgStr.Contains("data:image/Gif;base64")) convert = imgStr.Replace("data:image/Gif;base64,", string.Empty);
                else if (imgStr.Contains("data:application/pdf;base64")) convert = imgStr.Replace("data:application/pdf;base64,", string.Empty);
                else if (imgStr.Contains("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document; base64")) convert = imgStr.Replace("data:application/vnd.openxmlformats-officedocument.wordprocessingml.document; base64,", string.Empty);

                // If no exception is caught, then it is possibly a base64 encoded string
                byte[] data = Convert.FromBase64String(convert);
                // The part that checks if the string was properly padded to the
                // correct length was borrowed from d@anish's solution
                return (convert.Replace(" ", "").Length % 4 == 0);
            }
            catch
            {
                // If exception is caught, then it is not a base64 encoded string
                return false;
            }
        }

    }
}
