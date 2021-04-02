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
            if (file.Length > 0)
            {
                using (FileStream fileStream = new FileStream(tempPath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            var fileNewPath = newPath(file);
            File.Move(tempPath, fileNewPath);
            return fileNewPath;

        }

        public static string Update(string updatedPath, IFormFile file)
        {
            var path = newPath(file).ToString();
            if (updatedPath.Length > 0)
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            File.Delete(updatedPath);
            return path;
        }


        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
        public static string newPath(IFormFile file)
        {
            FileInfo ff = new FileInfo(file.FileName);
            string fileExtension = ff.Extension;


            var currentLocation = Environment.CurrentDirectory + @"\root\Images\";
            var path = Guid.NewGuid().ToString() + fileExtension;
            return currentLocation + path;
        }
    }
}