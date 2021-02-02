using AspNetCoreHero.Results;
using ClaimManager.Application.Interfaces.Repositories.Claims;
using ClaimManager.Domain.Entities.Claims;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClaimManager.Application.Features.Claims.Queries.GetById
{
    public class GetClaimByIdQuery : IRequest<Claim>
    {
        public int Id { get; set; }
        public class GetClaimByIdQueryHandler : IReqeustHandler<GetClaimByIdQuery, Claim>
        {
    
            private readonly IClaimsRepository _repository;
            public GetClaimByIdQueryHandler(IClaimsRepository repository)
            {
                _repository = repository;
            }

            public async Task<Claim> Handle(GetClaimByIdQuery request, CancellationToken cancellationToken)
            {
                var claim = await _repository.GetByIdAsync(request.Id);
                return claim;
            }
        }
    }
}
