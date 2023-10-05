namespace cookie_stand_api.Models
{
    public class CookieStand
    {
        public int ID { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public int Minimum_Customers_PerHour { get; set; }
        public int Maximum_Customers_PerHour { get; set; }
        public double Average_Cookies_PerSale { get; set; }
        public string? Owner { get; set; }
        public List<HourlySales>? HourlySales { get; set; }
    }
}
