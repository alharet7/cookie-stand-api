using cookie_stand_api.Data;
using cookie_stand_api.Model.DTO;
using cookie_stand_api.Models.DTOs;
using cookie_stand_api.Models.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace cookie_stand_api.Models.Services
{
    public class CookieStandService : ICookieStand
    {
        private readonly CookieDbContext _context;
        public CookieStandService(CookieDbContext context)
        {
            _context = context;
        }
        public async Task<CookieStand> AddCookieStand(CookieStandPostDTO cookieStandPostDTO)
        {
            var cookieStand = new CookieStand
            {
                Location = cookieStandPostDTO.Location,
                Description = cookieStandPostDTO.Description,
                Minimum_Customers_PerHour = cookieStandPostDTO.Minimum_Customers_PerHour,
                Maximum_Customers_PerHour = cookieStandPostDTO.Maximum_Customers_PerHour,
                Owner = cookieStandPostDTO.Owner,
            };
            var newCookie = await _context.CookieStands.AddAsync(cookieStand);
            cookieStand.HourlySales = await GenerateHourlySales(cookieStand.ID, cookieStand.Minimum_Customers_PerHour,
                                                                                                       cookieStand.Maximum_Customers_PerHour, cookieStand.Average_Cookies_PerSale);
            await _context.SaveChangesAsync();
            return cookieStand;
        }

        public async Task<List<HourlySales>> GenerateHourlySales(int cookieStandId, int minCustomer, int maxCustomer, double avgCookie)
        {
            List<HourlySales> hourlySalesList = new();
            Random rnd = new Random();
            for (int i = 1; i <= 14; i++)
            {
                int customer = rnd.Next(minCustomer, maxCustomer + 1);
                int value = (int)(avgCookie * customer);
                HourlySales hourlySales = new HourlySales
                {
                    ID = i,
                    CookieStandID = cookieStandId,
                    HourlySale = value
                };
                await _context.HourlySales.AddAsync(hourlySales);
                hourlySalesList.Add(hourlySales);
            }
            return hourlySalesList;
        }

        public async Task<List<CookieStandGetDTO>> GetAllCookieStand()
        {
            return await _context.CookieStands.Select(o => new CookieStandGetDTO
            {
                ID = o.ID,
                Location = o.Location,
                Description = o.Description,
                HourlySales = o.HourlySales.Select(h => h.HourlySale).ToList(),
                Minimum_Customers_PerHour = o.Minimum_Customers_PerHour,
                Maximum_Customers_PerHour = o.Maximum_Customers_PerHour,
                Average_Cookies_PerSale = o.Average_Cookies_PerSale,
                Owner = o.Owner
            }).ToListAsync();
        }

        public async Task<CookieStandGetDTO> GetCookieStandByID(int id)
        {
            var cookieStand = await _context.CookieStands.Select(cookieStand => new CookieStandGetDTO
            {
                ID = cookieStand.ID,
                Location = cookieStand.Location,
                Description = cookieStand.Description,
                HourlySales = cookieStand.HourlySales.Select(x => x.HourlySale).ToList(),
                Minimum_Customers_PerHour = cookieStand.Minimum_Customers_PerHour,
                Maximum_Customers_PerHour = cookieStand.Maximum_Customers_PerHour,
                Average_Cookies_PerSale = cookieStand.Average_Cookies_PerSale,
                Owner = cookieStand.Owner
            }).FirstOrDefaultAsync(x => x.ID == id);

            return cookieStand;
        }

        public async Task<string> RemoveCookieStand(int id)
        {
            var cookieStand = await _context.CookieStands.FindAsync(id);
            if (cookieStand != null)
            {
                var hourlySales = await _context.HourlySales.Where(x => x.CookieStandID == id).ToListAsync();

                foreach (var item in hourlySales)
                {
                    _context.Entry(item).State = EntityState.Deleted;
                }
                _context.Entry(cookieStand).State = EntityState.Deleted;

                await _context.SaveChangesAsync();
                return " Deleted Successfully!";
            }
            return "Cookie Stand with ID " + id + " Not Found.";
        }


        public async Task<CookieStand> UpdateCookieStand(int id, CookieStandPostDTO cookieStandPostDTO)
        {
            var currentCookieStand = await _context.CookieStands.FindAsync(id);

            if (currentCookieStand != null)
            {
                currentCookieStand.Location = cookieStandPostDTO.Location;
                currentCookieStand.Description = cookieStandPostDTO.Description;
                currentCookieStand.Minimum_Customers_PerHour = cookieStandPostDTO.Minimum_Customers_PerHour;
                currentCookieStand.Maximum_Customers_PerHour = cookieStandPostDTO.Maximum_Customers_PerHour;
                currentCookieStand.Average_Cookies_PerSale = cookieStandPostDTO.Average_Cookies_PerSale;

                currentCookieStand.HourlySales = await UpdateHourlySales(id, currentCookieStand.Minimum_Customers_PerHour,
                                                                                                                    currentCookieStand.Maximum_Customers_PerHour, currentCookieStand.Average_Cookies_PerSale);
                _context.Entry(currentCookieStand).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return currentCookieStand;
            }
            else
                return null;
        }
        public async Task<List<HourlySales>> UpdateHourlySales(int cookieStandId, int minCustomer, int maxCustomer, double avgCookie)
        {
            List<HourlySales> hourlySalesList = new();
            Random rnd = new Random();
            for (int i = 1; i <= 14; i++)
            {
                int customer = rnd.Next(minCustomer, maxCustomer + 1);
                int value = (int)(avgCookie * customer);
                HourlySales hourlySales = new HourlySales
                {
                    ID = i,
                    CookieStandID = cookieStandId,
                    HourlySale = value
                };

                _context.Entry(hourlySales).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                hourlySalesList.Add(hourlySales);
            }
            return hourlySalesList;
        }
    }
}
