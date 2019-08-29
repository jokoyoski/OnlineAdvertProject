using ADit.Interfaces;
using ADit.Interfaces.ValueTypes;
using ADit.Repositories.DataAccess;
using ADit.Repositories.Queries;
using System;

namespace ADit.Repositories.Services
{
    public class DigitalFileRepository : IDigitalFileRepository
    {/// <summary>
     /// Initializes a new instance of the <see cref="DigitalFileRepository"/> class.
     /// </summary>
     /// <param name="dbContextFactory">The database context factory.</param>

        private readonly IDbContextFactory dbContextFactory;

        public DigitalFileRepository(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }




        #region Digital File Setup

        /// <summary>
        /// Gets the digital file detail.
        /// </summary>
        /// <param name="digitalFileId">The digital file identifier.</param>
        /// <returns></returns>
        public IDigitalFile GetDigitalFileDetail(int digitalFileId)
        {
            try 
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    var aRecord = DigitalFileQueries.getDigitalFileDetail(dbContext, digitalFileId);

                    return aRecord;
                }
            }
            catch (Exception e)
            {
                throw new ApplicationException("Repository GetDigitalFileDetail", e);
            }
        }





        /// <summary>
        /// Saves the digital file.
        /// </summary>
        /// <param name="digitalFileTypeId">The digital file type identifier.</param>
        /// <param name="fileName">Name of the file.</param>
        /// <param name="fileExtension">The file extension.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="theContent">The content.</param>
        /// <param name="digitalFileId">The digital file identifier.</param>
        /// <returns></returns>
        public string SaveDigitalFile(int digitalFileTypeId, string fileName, string fileExtension, string contentType, byte[] theContent, out int digitalFileId)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            if (string.IsNullOrEmpty(contentType))
            {
                throw new ArgumentNullException(nameof(contentType));
            }

            if (theContent == null)
            {
                throw new ArgumentNullException(nameof(theContent));
            }
            
            var result = string.Empty;
            digitalFileId = 0;

            var newRecord = new DigitalFile
            {
                FileContent = theContent,
                FileExtension = fileExtension,
                FileName = fileName,
                ContentType = contentType,
                DigitalTypeId = digitalFileTypeId,
                IsActive = true,
                DateCreated = DateTime.Now
            };

            try
            {
                using (
                    var dbContext = (ADitEntities)this.dbContextFactory.GetDbContext())
                {
                    dbContext.DigitalFiles.Add(newRecord);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = string.Format("SaveDigitalFile - {0} , {1}", e.Message,
                    e.InnerException != null ? e.InnerException.Message : "");
            }

            digitalFileId = newRecord.DigitalFileId;
            return result;
        }


#endregion

    }
}
