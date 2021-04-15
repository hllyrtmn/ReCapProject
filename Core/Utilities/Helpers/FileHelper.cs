using System;
using System.IO;
using Microsoft.AspNetCore.Http;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {

            var tempPath = Path.GetTempFileName();
            var fileNewPath = newPath(file);

            if (file.Length > 0)
            {
                using (FileStream fileStream = new FileStream(tempPath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }

            File.Move(tempPath, fileNewPath.path);
            return fileNewPath.path2;

        }

        public static string Update(string updatedPath, IFormFile file)
        {
            File.Delete(Environment.CurrentDirectory +  @"\wwwroot\" + updatedPath );
            var result = Add(file);
            return result;
        }


        public static IResult Delete(string path)
        {
            var path2 = Environment.CurrentDirectory + @"\wwwroot\" + path;
            try
            {
                File.Delete(path2);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        public static (string path, string path2 ) newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;
            var newPath = Guid.NewGuid() + fileExtension;
            var currentLocation = Environment.CurrentDirectory + @"\wwwroot\";



            return ($@"{currentLocation}\{newPath}",newPath);
        }
    }
}