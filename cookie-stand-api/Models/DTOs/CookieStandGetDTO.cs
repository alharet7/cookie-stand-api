namespace cookie_stand_api.Models.DTOs
{
    public class CookieStandGetDTO
    {
        public int ID { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }
        public List<int>? HourlySales { get; set; }
        public int Minimum_Customers_PerHour { get; set; }
        public int Maximum_Customers_PerHour { get; set; }
        public double Average_Cookies_PerSale { get; set; }
        public string? Owner { get; set; }
    }
}
