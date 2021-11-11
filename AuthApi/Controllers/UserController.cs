using AuthApi.Models;
using AuthApi.Repository;
using AuthApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace AuthApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository repo;
        private readonly ITokenGeneratorService service;
        public UserController(IUserRepository repo, ITokenGeneratorService service)
        {
            this.repo = repo;
            this.service = service;
        }

        [HttpPost("register")]
        public IActionResult Post(User user)
        {
            return Ok(repo.Register(user));
        }

        [HttpPost("login")]
        public IActionResult Login(User user)
        {
            var u = repo.Login(user.UserName, user.Password);
            if (u == null)
            {
                return StatusCode(401, "Invalid UserId or Password");
            }
            else
            {
                return Ok(service.GenerateJWTToken(user.UserName, u));
            }
        }


    }
}
