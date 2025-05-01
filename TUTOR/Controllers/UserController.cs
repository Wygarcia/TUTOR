using Microsoft.AspNetCore.Mvc;
using TUTOR.Context;
using TUTOR.Model;

namespace TUTOR.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly TutorDbContext _context;

        public UserController(TutorDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _context.Users.Where(u => !u.IsDeleted).ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id && !u.IsDeleted);
            if (user == null) return NotFound("Usuario no encontrado");
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            user.Modified = DateTime.UtcNow;
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }
    }
}

