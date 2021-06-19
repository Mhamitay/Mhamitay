namespace EasyDine.Domain
{/// <summary>
///     this is the Restaurant class/Entity
/// </summary>
    public class Restaurant
    {
        /// <summary>
        ///     id of the restaurant
        /// </summary>
        public int id { get; set; }
        /// <summary>
        ///     name of the restaturnte
        /// </summary>
        public string name { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string closeAt { get; set; }
        public string OpensAt { get; set; }
        public string destance { get; set; }
        public string Rating { get; set; }
        public string image { get; set; }
    }
}
     