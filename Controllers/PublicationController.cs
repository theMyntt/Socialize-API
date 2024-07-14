using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Socialize.Data;
using Socialize.DTOs;
using Socialize.Models;

namespace Socialize.Controllers
{
    [Route("api/[controller]")]
    public class PublicationController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public PublicationController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Publication>>> Get(
            [Required] int page,
            [Required] int limit
        )
        {
            if (limit <= 1 || limit > 100)
            {
                return BadRequest(new
                {
                    message = "Limit needs to be > 1 and <= 100",
                    statusCode = 400
                });
            }
            if (page < 1)
            {
                return BadRequest(new
                {
                    message = "Page needs to be > 1",
                    statusCode = 400
                });
            }

            var response = await dbContext.Publication
                .Skip((page - 1) * limit)
                .Take(limit)
                .ToListAsync();

            return Ok(new
            {
                publications = response,
                statusCode = 200
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Publication>> Get(int id)
        {
            var response = await dbContext.Publication.FindAsync(id);

            if (response == null)
            {
                return NotFound(new
                {
                    message = "No publication found with this id",
                    statusCode = 404
                });
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<object>> Post([FromBody] NewPublicationDTO dto)
        {
            try
            {
                var response = await dbContext.Publication.AddAsync(new Publication
                {
                    Text = dto.Text,
                    CreatedAt = DateTime.Now
                });

                await dbContext.SaveChangesAsync();

                return StatusCode(201, new
                {
                    message = "Publication created",
                    statusCode = 201
                });
            } catch
            {
                return StatusCode(500, new
                {
                    message = "Internal Server Error",
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

