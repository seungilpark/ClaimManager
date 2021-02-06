using ClaimManager.API.Controllers;
using ClaimManager.Application.Features.Claims.Commands.Create;
using ClaimManager.Application.Features.Claims.Commands.Delete;
using ClaimManager.Application.Features.Claims.Commands.Update;
using ClaimManager.Application.Features.Claims.Queries.GetAllPaged;
using ClaimManager.Application.Features.Claims.Queries.GetById;
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
        public async Task<IActionResult> GetAllPagedAsync(int pageNumber, int pageSize)
        {
            return Ok(await _mediator.Send(new GetAllPagedClaimsQuery(pageNumber, pageSize)));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _mediator.Send(new GetAllPagedClaimsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var claim = await _mediator.Send(new GetClaimByIdQuery() { Id = id });
            return Ok(claim);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateClaimCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteClaimCommand { Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, UpdateClaimCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }
    }
}
