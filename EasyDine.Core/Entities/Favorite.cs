namespace EasyDine.Domain
{
    public class Favorite
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int restaurantId { get; set; }
        public bool isFavorite { get; set; }
    }
}
