using System;
using Microsoft.AspNetCore.Mvc;
using Socialize.Application.Usecases.User;
using Socialize.Core;
using Socialize.Data;
using Socialize.DTOs;

namespace Socialize.Infrastructure.Controllers.User
{
    [Route("/api/user/")]
    [Tags("User")]
    public class GetUsersController : Controller, IControllerService<GetUserDTO, IEnumerable<object>>
    {
        private readonly GetUserUsecase useCase;

        public GetUsersController(ApplicationDbContext dbContext)
        {
            useCase = new(dbContext);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> Perform([FromQuery] GetUserDTO dto)
        {
            return await useCase.run(dto);
        }
    }
}

