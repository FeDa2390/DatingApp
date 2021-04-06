using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using API.Entities;
using API.Data;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // api/users/[id]
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        [HttpGet("syncallusers")]
        public ActionResult<IEnumerable<AppUser>> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        [HttpGet("synconeuser/{id}")]
        public ActionResult<AppUser> GetUserSync(int id)
        {
            return _context.Users.Find(id);
        }
    }
}