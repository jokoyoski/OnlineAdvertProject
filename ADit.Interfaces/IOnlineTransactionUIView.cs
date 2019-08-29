using System.Collections.Generic;
using System.Web.Mvc;

namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="ADit.Interfaces.IOnlineTransactionUI" />
    public interface IOnlineTransactionUIView : IOnlineTransactionUI 
    {
        
        /// <summary>
        /// Gets or sets the online duration list.
        /// </summary>
        /// <value>
        /// The online duration list.
        /// </value>
        IList<SelectListItem> OnlineDurationList { get; set; }
        /// <summary>
        /// Gets or sets the duration of the online.
        /// </summary>
        /// <value>
        /// The duration of the online.
        /// </value>
        IList<IOnlineDuration> OnlineDuration { get; set; }
        /// <summary>
        /// Gets or sets the platform packages.
        /// </summary>
        /// <value>
        /// The platform packages.
        /// </value>
        IList<IOnlinePlatform> PlatformPackages { get; set; }

        /// <summary>
        /// Gets or sets the airing details list.
        /// </summary>
        /// <value>
        /// The airing details list.
        /// </value>
        IList<IOnlineTransactionAiringUI> AiringDetailsList { get; set; }
        /// <summary>
        /// Gets or sets the type of the timing.
        /// </summary>
        /// <value>
        /// The type of the timing.
        /// </value>
        IList<SelectListItem> TimingType { get; set; }
        /// <summary>
        /// Gets or sets the online extra service list.
        /// </summary>
        /// <value>
        /// The online extra service list.
        /// </value>
        IList<SelectListItem> OnlineExtraServiceList { get; set; }

        /// <summary>
        /// Gets or sets the online platform list.
        /// </summary>
        /// <value>
        /// The online platform list.
        /// </value>
        IList<SelectListItem> OnlinePlatformList { get; set; }

        /// <summary>
        /// Gets or sets the online purpose list.
        /// </summary>
        /// <value>
        /// The online purpose list.
        /// </value>
        IList<SelectListItem> OnlinePurposeList { get; set; }

        /// <summary>
        /// Gets or sets the artwork list.
        /// </summary>
        /// <value>
        /// The artwork list.
        /// </value>
        IList<SelectListItem> ArtworkList { get; set; }

        /// <summary>
        /// Gets or sets the selected online packages ids.
        /// </summary>
        /// <value>
        /// The selected online packages ids.
        /// </value>
        List<int> SelectedOnlinePackagesIds { get; set; }

        /// <summary>
        /// Gets the timing DDL.
        /// </summary>
        /// <param name="timingId">The timing identifier.</param>
        /// <returns></returns>
        IList<SelectListItem> GetTimingDDL(int timingId);

        /// <summary>
        /// Gets the online package description.
        /// </summary>
        /// <param name="platformId">The platform identifier.</param>
        /// <returns></returns>
        string GetOnlinePackageDescription(int platformId);


       
    }
}
