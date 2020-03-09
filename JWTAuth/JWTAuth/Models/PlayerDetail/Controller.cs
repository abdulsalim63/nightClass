using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace JWTAuth.Models.PlayerDetail
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerContext _context;

        public List<Admin> Admins = new List<Admin>
        {
            new Admin { username = "salim", password = "blablab"},
            new Admin { username = "budi", password = "blablab"}
        };

        public PlayerController(PlayerContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get() => Ok(new
        {
            Message = "Success retrieve player data",
            Status = true,
            Data = _context.players.OrderBy(x => x.id)
        });

        [HttpPost("auth")]
        [AllowAnonymous]
        public IActionResult TokenGenerator(Admin admin)
        {
            try
            {
                var result = Admins.First(x => x.username == admin.username && x.password == admin.password);

                var tokenHandler = new JwtSecurityTokenHandler();

                var tokenDescription = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim(ClaimTypes.Name, result.username),
                        new Claim(ClaimTypes.Authentication, result.password)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("this is encryption key")), SecurityAlgorithms.HmacSha512Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescription);

                return Ok(new {
                    token = tokenHandler.WriteToken(token),
                    admin = result
                });
            }
            catch(Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post(Player player)
        {
            _context.players.Add(player);
            _context.SaveChanges();

            return Ok(new
            {
                Message = "Success add player data",
                Status = true,
                Data = player
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(int Id)
        {
            try
            {
                var result = _context.players.First(x => x.id == Id);

                return Ok(new {
                    Message = "Success retrieve player data",
                    Status = true,
                    Data = result
                });
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeletebyId(int Id)
        {
            try
            {
                var result = _context.players.First(x => x.id == Id);
                _context.players.Remove(result);
                _context.SaveChanges();

                return Ok(new
                {
                    Message = "Success delete player data",
                    Status = true,
                    Data = result
                });
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdatebyId(int Id, Player player)
        {
            try
            {
                var result = _context.players.First(x => x.id == Id);

                result.name = player.name;
                result.team = player.team;

                _context.SaveChanges();

                return Ok(new
                {
                    Message = "Success update player data",
                    Status = true,
                    Data = result
                });
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }

    public class Admin
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
