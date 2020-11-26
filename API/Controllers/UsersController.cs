using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }


        //https://localhost:5001/api/users/ -->  alle Nutzer werden angezeigt
        //Aber dieser Code ist snychron! --> Code ist blocked solange bis returned wird
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await  _context.Users.ToListAsync();
          
        }

        // https://localhost:5001/api/users/2 -->  Nutzer mit der ID 2 wird angezeigt
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
           return await _context.Users.FindAsync(id);          
        }

    }
}