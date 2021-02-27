using ClaimManager.Application.Features.Claims.Commands.Create;
using ClaimManager.Application.Features.Claims.Commands.Update;
using ClaimManager.Application.Features.Claims.Queries.GetAllPaged;
using ClaimManager.Application.Features.Claims.Queries.GetById;
using ClaimManager.BlazorMud.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace ClaimManager.BlazorMud.Services
{
    public class ClaimsService : IClaimsService
    {
        const int API_VERSION = 1;
        private readonly HttpClient _httpClient;

        public ClaimsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<int> CreateClaim(CreateClaimCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteClaim(int claimId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetAllClaimsResponse>> GetAllClaims()
        {
            return await _httpClient.GetFromJsonAsync<GetAllClaimsResponse[]>($"api/{API_VERSION}/claim/");
        }

        public async Task<GetClaimByIdQueryResponse> GetByClaimId(int claimId)
        {
            return await _httpClient.GetFromJsonAsync<GetClaimByIdQueryResponse>($"api/{API_VERSION}/claim/{claimId}");
        }

        public Task<int> UpdateClaim(int claimId, UpdateClaimCommand command)
        {
            throw new NotImplementedException();
        }

    }
}
