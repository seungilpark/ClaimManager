using AspNetCoreHero.Results;
using AutoMapper;
using ClaimManager.Application.Features.Claims.Queries.Dtos;
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
    public class GetClaimByIdQuery : IRequest<Result<GetClaimByIdQueryResponse>>
    {
        public int Id { get; set; }
        public class GetClaimByIdQueryHandler : IRequestHandler<GetClaimByIdQuery, Result<GetClaimByIdQueryResponse>>
        {
    
            private readonly IMapper _mapper;
            private readonly IClaimsRepository _repository;
            public GetClaimByIdQueryHandler(IClaimsRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Result<GetClaimByIdQueryResponse>> Handle( GetClaimByIdQuery request, CancellationToken cancellationToken)
            {
                var claim = await _repository.GetByIdAsync(request.Id);

                List<GetClaimItemDto> claimItems = new List<GetClaimItemDto>();

                foreach(ClaimItem item in claim.ClaimItems)
                {
                    claimItems.Add(new GetClaimItemDto
                    {
                        Payee = item.Payee,
                        Date = item.Date,
                        Description = item.Description,
                        Amount = item.Amount,
                        USDAmount = item.USDAmount,
                        Image = item.Image,
                        CurrencySymbol = item.Currency.Symbol,
                        CategoryCode = item.ClaimCategory.Code,
                    }); 
                }

                GetClaimByIdQueryResponse res = new GetClaimByIdQueryResponse
                {
                    Title = claim.Title,
                    RequesterId = claim.RequesterId,
                    ApproverId = claim.ApproverId,
                    SubmitDate = claim.SubmitDate,
                    ApprovalDate = claim.ApprovalDate,
                    ProcessedDate = claim.ProcessedDate,
                    TotalAmount = claim.TotalAmount,
                    Status = claim.Status,
                    RequesterComments = claim.RequesterComments,
                    ApproverComments = claim.ApproverComments,
                    FinanceComments = claim.FinanceComments,
                    ClaimItemsDtos = claimItems
                };

                return Result<GetClaimByIdQueryResponse>.Success(res);
            }
        }
    }
}
