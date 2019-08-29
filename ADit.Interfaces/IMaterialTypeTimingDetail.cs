namespace ADit.Interfaces
{
    public interface IMaterialTypeTimingDetail
    {
        /// <summary>
        /// Gets or sets the material type timing identifier.
        /// </summary>
        /// <value>
        /// The material type timing identifier.
        /// </value>
        int MaterialTypeTimingId { get; set; }

        /// <summary>
        /// Gets or sets the service type code.
        /// </summary>
        /// <value>
        /// The service type code.
        /// </value>
        string ServiceTypeCode { get; set; }

        /// <summary>
        /// Gets or sets the material type identifier.
        /// </summary>
        /// <value>
        /// The material type identifier.
        /// </value>
        int MaterialTypeId { get; set; }

        /// <summary>
        /// Gets or sets the material description.
        /// </summary>
        /// <value>
        /// The material description.
        /// </value>
        string MaterialDescription { get; set; }

        /// <summary>
        /// Gets or sets the timing identifier.
        /// </summary>
        /// <value>
        /// The timing identifier.
        /// </value>
        int TimingId { get; set; }

        /// <summary>
        /// Gets or sets the timing description.
        /// </summary>
        /// <value>
        /// The timing description.
        /// </value>
        string TimingDescription { get; set; }

        /// <summary>
        /// Gets or sets the is active.
        /// </summary>
        /// <value>
        /// The is active.
        /// </value>
        bool IsActive { get; set; }
    }
}