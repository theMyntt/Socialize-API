using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Socialize.Data;

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
        public void Post([FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = await dbContext.Likes.FindAsync(id);

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

