using ClaimManager.Application.Features.Claims.Commands.Create;
using ClaimManager.Application.Features.Claims.Commands.Update;
using ClaimManager.Application.Features.Claims.Queries.GetAllPaged;
using ClaimManager.Application.Features.Claims.Queries.GetById;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClaimManager.BlazorMud.Services.interfaces
{
    public interface IClaimsService
    {
        Task<IEnumerable<GetAllClaimsResponse>> GetAllClaims();
        Task<GetClaimByIdQueryResponse> GetByClaimId(int claimId);
        Task<int> CreateClaim(CreateClaimCommand command);
        Task<int> DeleteClaim(int claimId);
        Task<int> UpdateClaim(int claimId, UpdateClaimCommand command);
    }
}
