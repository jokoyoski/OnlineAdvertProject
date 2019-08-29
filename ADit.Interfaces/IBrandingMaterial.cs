namespace ADit.Interfaces
{
    /// <summary>
    /// 
    /// </summary>
    public interface IBrandingMaterial
    {
        /// <summary>
        /// Gets or sets the branding material identifier.
        /// </summary>
        /// <value>
        /// The branding material identifier.
        /// </value>
        int BrandingMaterialId { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        string Description { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        bool IsActive { get; set; }
    }
}
