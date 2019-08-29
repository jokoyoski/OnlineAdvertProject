using ADit.Domain.Extensions;
using ADit.Interfaces;
using System;
using System.IO;
using System.Web;

namespace ADit.Domain.Services
{
 
    public class DigitalServices : IDigitalFileServices
    {
     
        private readonly IDigitalFileRepository digitalFileRepository;

      
        public DigitalServices(IDigitalFileRepository digitalFileRepository)
        {
            this.digitalFileRepository = digitalFileRepository;
        }

        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <param name="digitalFileTypeId">The digital file type identifier.</param>
        /// <param name="profilePicture">The profile picture.</param>
        /// <param name="digitalFileId">The digital file identifier.</param>
        /// <returns></returns>
        public string SaveFile(int digitalFileTypeId, HttpPostedFileBase profilePicture, out int digitalFileId)
        {
            digitalFileId = 0;

            var processingMessage = string.Empty;

            if ((profilePicture == null) || (profilePicture.ContentLength < 1))
            {
                return processingMessage;
            }

            byte[] theContent;
            using (Stream inputStream = profilePicture.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }
                
                theContent = memoryStream.ToArray();
            }

            var fileName = profilePicture.FileName;
            var contentType = profilePicture.ContentType;
            var fileExtension = fileName.FileExtension();

            processingMessage = this.digitalFileRepository.SaveDigitalFile(digitalFileTypeId, fileName, fileExtension,
                contentType, theContent, out digitalFileId);

            return processingMessage;
        }

        /// <summary>
        /// Converts the file.
        /// </summary>
        /// <param name="uploadedFile">The uploaded file.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileExtension">The file extension.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <returns></returns>
        public byte[] ConvertFile(HttpPostedFileBase uploadedFile, out string fileName, out string fileExtension,
            out string contentType)
        {
            fileName = String.Empty;
            contentType = String.Empty;
            fileExtension = String.Empty;

            if ((uploadedFile == null) || (uploadedFile.ContentLength < 1))
            {
                return null;
            }

            byte[] theContent;
            using (Stream inputStream = uploadedFile.InputStream)
            {
                MemoryStream memoryStream = inputStream as MemoryStream;
                if (memoryStream == null)
                {
                    memoryStream = new MemoryStream();
                    inputStream.CopyTo(memoryStream);
                }

                theContent = memoryStream.ToArray();
            }

            fileName = uploadedFile.FileName;
            contentType = uploadedFile.ContentType;
            fileExtension = fileName.FileExtension();


            return theContent;
        }

        /// <summary>
        /// Stores the binart files.
        /// </summary>
        /// <param name="digitalFileTypeId">The digital file type identifier.</param>
        /// <param name="fileBinay">The file binay.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="fileExtension">The file extension.</param>
        /// <param name="digitalFileId">The digital file identifier.</param>
        /// <returns></returns>
        public string StoreBinartFiles(int digitalFileTypeId, byte[] fileBinay, string fileName, string contentType,
            string fileExtension, out int digitalFileId)
        {
            digitalFileId = 0;
            var processingMessage = string.Empty;


            processingMessage = this.digitalFileRepository.SaveDigitalFile(digitalFileTypeId, fileName, fileExtension,
                contentType, fileBinay, out digitalFileId);

            return processingMessage;
        }




    }
}