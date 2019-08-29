using ADit.Interfaces;
using ADit.Repositories.DataAccess;
using ADit.Repositories.Models;
using System.Linq;

namespace ADit.Repositories.Queries
{
    /// <summary>
    /// 
    /// </summary>
    public class DigitalFileQueries
    {

        /// <summary>
        /// Gets the digital file detail.
        /// </summary>
        /// <param name="db">The database.</param>
        /// <param name="digitalFileId">The digital file identifier.</param>
        /// <returns></returns>
        internal static IDigitalFile getDigitalFileDetail(ADitEntities db, int digitalFileId)
        {
            var result = (from d in db.DigitalFiles
                          where d.DigitalFileId.Equals(digitalFileId)
                          select new DigitalFileModel
                          {
                              FileContent=d.FileContent,
                              DateCreated = d.DateCreated,
                              DigitalFileId = d.DigitalFileId,
                              DigitalTypeId = d.DigitalTypeId,
                           
                              IsActive = d.IsActive,
                              FileExtension = d.FileExtension,
                              Filename = d.FileName,
                              ContentType= d.ContentType

                          }).FirstOrDefault();
            return result;
        }
    }
}
