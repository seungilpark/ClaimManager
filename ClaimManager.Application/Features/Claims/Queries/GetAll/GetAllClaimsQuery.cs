using ClaimManager.Application.Features.Claims.Queries.GetAllPaged;
using ClaimManager.Application.Interfaces.Repositories.Claims;
using ClaimManager.Domain.Entities.Claims;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClaimManager.Application.Features.Claims.Queries.GetAll
{
    public class GetAllClaimsQuery : IRequest<IList<Claim>>
    {

    }
    public class GetAllClaimsQueryHandler : IRequestHandler<GetAllClaimsQuery, IList<Claim>>
    {
        private readonly IClaimsRepository _repository;
        public GetAllClaimsQueryHandler(IClaimsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<Claim>> Handle(GetAllClaimsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Claims.ToListAsync();

        }
        
    }
}

