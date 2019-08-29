using System;

namespace ADit.Domain.Extensions
{
   public   static class stringExtensions
    {

        public  static string FileExtension(this string fileName)
        {
            if(fileName==null)
            {
                throw new ArgumentException("fileName");
            }
            var result = fileName.Substring(fileName.LastIndexOf("."));


            return result;

        }
    }
}
