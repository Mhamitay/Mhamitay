namespace EasyDine.Domain
{
    public class BlackList
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int restaurantId { get; set; }
        public bool isBlakListed { get; set; }

    }
}
