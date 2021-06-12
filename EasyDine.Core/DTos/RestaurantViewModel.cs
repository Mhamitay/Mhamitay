using System.Collections.Generic;

namespace EasyDine.Domain.DTo
{
    public class RestaurantViewModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string postalCode { get; set; }
        public string closeAt { get; set; }
        public string OpensAt { get; set; }
        public string destance { get; set; }
        public string Rating { get; set; }
        public string image { get; set; }
        public bool isBlakListed { get; set; }
        public bool isFavorite { get; set; }
        public List<BlackList>blackLists { get; set; }

    }
}
