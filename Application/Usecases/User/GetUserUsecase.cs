using System;
using Azure;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Socialize.Core;
using Socialize.DTOs;
using Socialize.Data;

namespace Socialize.Application.Usecases.User
{
    public class GetUserUsecase : Controller, IUseCaseService<GetUserDTO, IEnumerable<object>>
    {
        private readonly ApplicationDbContext dbContext;

        public GetUserUsecase(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<ActionResult<IEnumerable<object>>> run(GetUserDTO dto)
        {
            if (dto.limit <= 1 || dto.limit > 100)
            {
                return BadRequest(new
                {
                    message = "Limit needs to be > 1 and <= 100",
                    statusCode = 400
                });
            }
            if (dto.page < 1)
            {
                return BadRequest(new
                {
                    message = "Page needs to be > 1",
                    statusCode = 400
                });
            }

            var bruteResponse = await dbContext.User
                .Skip((dto.page - 1) * dto.limit)
                .Take(dto.limit)
                .ToListAsync();

            List<object> users = new();

            for (int i = 0; i < bruteResponse.ToArray().Length; i++)
            {
                users.Add(new
                {
                    code = bruteResponse[i].Code,
                    name = bruteResponse[i].Name,
                    description = bruteResponse[i].Description,
                    createdAt = bruteResponse[i].CreatedAt
                });
            }

            return Ok(new
            {
                users = users.ToArray(),
                statusCode = 200
            });
        }
    }
}

