using ClaimManager.API.Controllers;
using ClaimManager.Application.Features.Claims.Queries.GetAllPaged;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimManager.Api.Controllers.v1.Claims
{
    public class ClaimController : BaseApiController<ClaimController>
    {
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNumber, int pageSize)
        {
            return Ok(await _mediator.Send(new GetAllClaimsQuery(pageNumber, pageSize)));
        }
    }
}
