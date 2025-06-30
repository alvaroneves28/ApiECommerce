using ApiECommerce.Context;
using ApiECommerce.Entities;
using ApiECommerce.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiECommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly AppDbContext dbContext;
        private readonly IConfiguration _config;


        public UsersController(AppDbContext dbContext, IConfiguration config)
        {
            _config = config;
            this.dbContext = dbContext;
        }

        [HttpPost("[action]")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            var usuarioExiste = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == user.Email);

            if (usuarioExiste is not null)
            {
                return BadRequest("Já existe usuário com este email");
            }

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User user)
        {
            var actualUser = await dbContext.Users.FirstOrDefaultAsync(u =>
                u.Email == user.Email && u.Password == user.Password);

            if (actualUser is null)
            {
                return NotFound("User not found");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email)
            };

            var token = new JwtSecurityToken(
                issuer: _config["JWT:Issuer"],
                audience: _config["JWT:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: credentials);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return new JsonResult(new Dictionary<string, object>
            {
                { "accesstoken", jwt },
                { "tokentype", "bearer" },
                { "userid", actualUser.Id },
                { "username", actualUser.Name },
                { "email", actualUser.Email },
                { "contact", actualUser.Contact }
            });
        }

        [Authorize]
        [HttpPost("UploadUserFoto")]
        public async Task<IActionResult> UploadUserFoto([FromForm] UserImageUploadDTO model)
        {
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
            var user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            if (user is null)
            {
                return NotFound("User not found");
            }

            if (model.Image == null || model.Image.Length == 0)
            {
                return BadRequest("No image was sent.");
            }


            var imageFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "userimages");
            if (!Directory.Exists(imageFolder))
            {
                Directory.CreateDirectory(imageFolder);
            }

            // Nome de ficheiro único
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(model.Image.FileName);
            string filePath = Path.Combine(imageFolder, uniqueFileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await model.Image.CopyToAsync(stream);
            }

            user.Image = "/userimages/" + uniqueFileName;

            await dbContext.SaveChangesAsync();
            return Ok("Imagem enviada com sucesso.");
        }


        [Authorize]
        [HttpGet("UserProfileImage")]
        public async Task<IActionResult> UserProfileImage()
        {
            //verifica se o usuário esta autenticado
            var userEmail = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

            var usuario = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == userEmail);

            if (usuario is null)
                return NotFound("Usuário não encontrado");

            var imagemPerfil = await dbContext.Users
                .Where(x => x.Email == userEmail)
                .Select(x => new
                {
                    x.Image,
                })
                .SingleOrDefaultAsync();

            return Ok(imagemPerfil);
        }

        [HttpGet("All")]
        [AllowAnonymous] 
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await dbContext.Users
                .Select(u => new
                {
                    u.Id,
                    u.Email,
                    u.Name,
                    u.Contact,
                })
                .ToListAsync();

            return Ok(users);
        }


    }
}
