using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Socialize.Data;
using Socialize.DTOs;

namespace Socialize.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        ApplicationDbContext dbContext;

        public UserController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost("login")]
        public async Task<ActionResult<object>> Get([FromBody] LoginUserDTO dto)
        {
            var response = await dbContext.User.FirstOrDefaultAsync(u => u.Email == dto.Email && u.Password == dto.Password);

            if (response == null)
            {
                return NotFound(new
                {
                    message = "No user found",
                    statusCode = 404
                });
            }

            return Ok(new
            {
                user = new {
                    name = response.Name,
                    code = response.Code,
                    description = response.Description,
                    photo = response.Photo,
                    createdAt = response.CreatedAt
                },
                statusCode = 200
            });
        }

        [HttpGet("{code}/image")]
        public async Task<IActionResult> Get(string code)
        {
            var user = await dbContext.User.FirstOrDefaultAsync(u => u.Code == code);

            if (user == null)
            {
                return NotFound(new {
                    message = "No user found",
                    statusCode = 404
                });
            }

            var databytes = System.IO.File.ReadAllBytes(user.Photo);

            return File(databytes, "image/png");
        }

        [HttpPost]
        public async Task<ActionResult<object>> Post([FromForm] NewUserDTO dto)
        {
            try
            {
                var userExists = await dbContext.User.FirstOrDefaultAsync(u => u.Code == dto.Code);

                if (userExists != null)
                {
                    return Conflict(new
                    {
                        message = "User already exists",
                        statusCode = 409
                    });
                }

                var filePath = Path.Combine("Storage", dto.Photo.FileName);

                using Stream fileStream = new FileStream(filePath, FileMode.Create);
                dto.Photo.CopyTo(fileStream);

                await dbContext.User.AddAsync(new Models.User {
                    Code = dto.Code,
                    Email = dto.Email,
                    Name = dto.Name,
                    Password = dto.Password,
                    Description = dto.Description,
                    Photo = filePath,
                    CreatedAt = DateTime.Now
                });
                await dbContext.SaveChangesAsync();

                return StatusCode(201, new
                {
                    message = "User created successfuly",
                    statusCode = 201
                });
            } catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error",
                    error = ex.Message,
                    statusCode = 500
                });
            }
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

