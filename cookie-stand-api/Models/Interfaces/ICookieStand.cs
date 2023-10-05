using cookie_stand_api.Model.DTO;
using cookie_stand_api.Models.DTOs;

namespace cookie_stand_api.Models.Interfaces
{
    public interface ICookieStand
    {
        public Task<CookieStand> AddCookieStand(CookieStandPostDTO cookieStandPostDTO);
        public Task<List<CookieStandGetDTO>> GetAllCookieStand();
        public Task<CookieStandGetDTO> GetCookieStandByID(int id);
        public Task<CookieStand> UpdateCookieStand(int id, CookieStandPostDTO cookieStandPostDTO);
        public Task<List<HourlySales>> GenerateHourlySales(int cookieStandId, int minCustomer, int maxCustomer, double avgCookie);
        public Task<List<HourlySales>> UpdateHourlySales(int cookieStandId, int minCustomer, int maxCustomer, double avgCookie);
        public Task<string> RemoveCookieStand(int id);
    }
}
