namespace cookie_stand_api.Model.DTO
{
    public class CookieStandPostDTO
    {
        public string? Location { get; set; }
        public string? Description { get; set; }
        public int Minimum_Customers_PerHour { get; set; }
        public int Maximum_Customers_PerHour { get; set; }
        public double Average_Cookies_PerSale { get; set; }
        public string? Owner { get; set; }

    }
}