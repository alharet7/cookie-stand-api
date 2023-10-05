using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using cookie_stand_api.Data;
using cookie_stand_api.Models;
using cookie_stand_api.Models.Interfaces;
using cookie_stand_api.Models.DTOs;
using System.Net;
using cookie_stand_api.Model.DTO;

namespace cookie_stand_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CookieStandsController : ControllerBase
    {
        private readonly ICookieStand _cookieStand;
        public CookieStandsController(ICookieStand cookieStand)
        {
            _cookieStand = cookieStand;
        }

        // GET: api/CookieStands
        [HttpGet]
        public async Task<ActionResult<List<CookieStandGetDTO>>> GetCookieStands()
        {
            var cookieStands = await _cookieStand.GetAllCookieStand();
            if (cookieStands.Count == 0)
            {
                return NoContent();
            }
            else
                return cookieStands;
        }

        // GET: api/CookieStands/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CookieStandGetDTO>> GetCookieStand(int id)
        {

            var cookieStand = await _cookieStand.GetCookieStandByID(id);
            if (cookieStand != null)
                return cookieStand;
            else
                return NoContent();
        }

        // PUT: api/CookieStands/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<CookieStand>> PutCookieStand(int id, CookieStandPostDTO cookieStand)
        {
            var cookieStandToUpdate = await _cookieStand.UpdateCookieStand(id, cookieStand);

            if (cookieStandToUpdate != null)
            {
                return cookieStandToUpdate;
            }
            else
            {
                return NoContent();
            }
        }

        // POST: api/CookieStands
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CookieStand>> PostCookieStand([FromBody] CookieStandPostDTO cookieStand)
        {
            var cookieStandPost = await _cookieStand.AddCookieStand(cookieStand);
            if (cookieStandPost != null)
            {
                return cookieStandPost;
            }
            else
                return NoContent();
        }

        // DELETE: api/CookieStands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCookieStand(int id)
        {
            await _cookieStand.RemoveCookieStand(id);
            return Ok();
        }


    }
}
