using System.Web;

namespace ADit.Interfaces
{
    public interface IDigitalFileServices
    {
        /// <summary>
        /// Saves the file.
        /// </summary>
        /// <param name="digitalFileTypeId">The digital file type identifier.</param>
        /// <param name="profilePicture">The profile picture.</param>
        /// <param name="digitalFileId">The digital file identifier.</param>
        /// <returns></returns>
        string SaveFile(int digitalFileTypeId, HttpPostedFileBase profilePicture, out int digitalFileId);


        /// <summary>
        /// Converts the file.
        /// </summary>
        /// <param name="uploadedFile">The uploaded file.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileExtension">The file extension.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <returns></returns>
        byte[] ConvertFile( HttpPostedFileBase uploadedFile, out string fileName,
            out string fileExtension, out string contentType);

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
        string StoreBinartFiles(int digitalFileTypeId, byte[] fileBinay, string fileName, string contentType,
            string fileExtension, out int digitalFileId);
    }
}
