namespace ADit.Interfaces.ValueTypes
{
    /// <summary>
    /// Struct OrderStatus
    /// </summary>
    public struct OrderStatus
    {
        /// <summary>
        /// The pending
        /// </summary>
        public const string Active = "A";



        public const string Cancelled = "C";


        /// <summary>
        /// The completed
        /// </summary>
        public const string Deleted = "D";

        /// <summary>
        /// The in process
        /// </summary>
        public const string InFulfilment = "I";

        /// <summary>
        /// The fulfilled
        /// </summary>
        public const string Open = "O";

        /// <summary>
        /// The others
        /// </summary>
        public const string Paid = "P";


        /// <summary>
        /// 
        /// </summary>
        public const string Completed = "Z";
    }
}
