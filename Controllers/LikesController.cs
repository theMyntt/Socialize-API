using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Socialize.Data;
using Socialize.DTOs;

namespace Socialize.Controllers
{
    [Route("api/[controller]")]
    public class LikesController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public LikesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LikesDTO dto)
        {
            var publication = await dbContext.Publication.FindAsync(dto.PublicationId);
            var user = await dbContext.User.FirstOrDefaultAsync(u => u.Code == dto.UserCode);

            if (publication == null || user == null)
            {
                return NotFound(new
                {
                    message = "No User/Publication found with this ID",
                    statusCode = 404
                });
            }

            var like = await dbContext.Likes.FirstOrDefaultAsync(u => u.Publication == publication && u.User == user);

            if (like != null)
            {
                return Conflict(new
                {
                    message = "You already liked this publication",
                    statusCode = 409
                });
            }

            await dbContext.Likes.AddAsync(new Models.Likes {
                Publication = publication,
                User = user
            });
            await dbContext.SaveChangesAsync();

            return StatusCode(201);
        }

        [HttpDelete("{publicationId}")]
        public async Task<IActionResult> Delete(int publicationId, [Required] string userCode)
        {
            try
            {
                var publication = await dbContext.Publication.FindAsync(publicationId);
                var user = await dbContext.User.FirstOrDefaultAsync(u => u.Code == userCode);

                if (publication == null || user == null)
                {
                    return NotFound(new
                    {
                        message = "No User/Publication found with this ID",
                        statusCode = 404
                    });
                }

                var model = await dbContext.Likes.FirstOrDefaultAsync(l => l.Publication == publication && l.User == user);

                if (model == null)
                {
                    return NotFound(new
                    {
                        message = "No publication found with this ID",
                        statusCode = 404
                    });
                }

                dbContext.Likes.Remove(model);
                dbContext.SaveChanges();

                return NoContent();
            } catch
            {
                return StatusCode(500, new
                {
                    message = "We cant remove this like",
                    statusCode = 500
                });
            }
        }
    }
}

