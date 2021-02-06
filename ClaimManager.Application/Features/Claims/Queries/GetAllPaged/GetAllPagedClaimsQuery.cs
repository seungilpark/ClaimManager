using AspNetCoreHero.Results;
using ClaimManager.Application.Extensions;
using ClaimManager.Application.Interfaces.Repositories.Claims;
using ClaimManager.Domain.Entities.Claims;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClaimManager.Application.Features.Claims.Queries.GetAllPaged
{
    public class GetAllPagedClaimsQuery : IRequest<PaginatedResult<GetAllClaimsResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public GetAllPagedClaimsQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }

        public GetAllPagedClaimsQuery()
        {
        }
    }

    public class GetAllPagedClaimsQueryHandler : IRequestHandler<GetAllPagedClaimsQuery, PaginatedResult<GetAllClaimsResponse>>
    {

        private readonly IClaimsRepository _repository;
        public GetAllPagedClaimsQueryHandler(IClaimsRepository repository)
        {
            _repository = repository;
        }

        public async Task<PaginatedResult<GetAllClaimsResponse>> Handle(GetAllPagedClaimsQuery request, CancellationToken cancellationToken)
        {

            Expression<Func<Claim, GetAllClaimsResponse>> expression = e => new GetAllClaimsResponse
            {
                Title = e.Title,
                RequesterId = e.RequesterId,
                ApproverId = e.ApproverId,
                SubmitDate = e.SubmitDate,
                ApprovalDate = e.ApprovalDate,
                ProcessedDate = e.ProcessedDate,
                TotalAmount = e.TotalAmount,
                Status = e.Status,
                RequesterComments = e.RequesterComments,
                ApproverComments = e.ApproverComments,
                FinanceComments = e.FinanceComments,
                ItemsCount = e.ClaimItems.Count(),
            };

            var paginatedList = await _repository.Claims
                .Select(expression)
                .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return paginatedList;
        }
    }
}
