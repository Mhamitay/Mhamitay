using System.ComponentModel.DataAnnotations;

namespace EasyDine.Domain
{
    public class SearchViewModel
    {
         public int user_ID { get; set; }
         public string RestaurantName { get; set; }
        public string restaurantid { get; set; }

        [Range(0, 3,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public string cityID { get; set; }

        [Range(0, 3,ErrorMessage = "Value for {0} must be between {1} and {2}.")]

        public string countryID { get; set; }

        public string postalCode { get; set; }

        public string closeAt { get; set; }
     
        public string OpensAt { get; set; }

        [Range(1,15, ErrorMessage = "Invalid time selected")]
        public string distance { get; set; }

        [Range(0, 1,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public string image { get; set; }

        [Range(0, 5,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public string Rating { get; set; }

        [Range(0,1,ErrorMessage = "please enter a value true or false")]
        public bool favorites { get; set; }
    }
}
