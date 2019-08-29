using ADit.Domain.Resources;
using ADit.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ADit.Domain.Utilities
{
    /// <summary>
    /// 
    /// </summary>
    public static class GetOnlineArtWorkDropdownList
    {
        /// <summary>
        /// Artworks the price.
        /// </summary>
        /// <param name="OnlinePlatformCollection">The online platform collection.</param>
        /// <param name="selectedArtWorkPriceId">The selected art work price identifier.</param>
        /// <returns></returns>
        internal static IList<SelectListItem> ArtworkPrice(IEnumerable<IOnlineArtworkPrice> OnlinePlatformCollection,
           int selectedArtWorkPriceId)
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                   Text = Common.SelectOnlineArtworktext,
                    Value = "-1",
                    Selected = (selectedArtWorkPriceId < 1)
                }
            };

            if (OnlinePlatformCollection.Any())
            {
                list.AddRange(OnlinePlatformCollection.Select(t => new SelectListItem
                {
                    Text = t.Comment,  //this is the Title
                    Value = t.ArtWorkPriceId.ToString(),  //Id
                    Selected = (t.ArtWorkPriceId.Equals(selectedArtWorkPriceId))
                }));
            }

            return list;
        }
    }
}
