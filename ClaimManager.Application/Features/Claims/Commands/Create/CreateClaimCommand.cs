using AspNetCoreHero.Results;
using AutoMapper;
using ClaimManager.Application.Features.Claims.Commands.Dtos;
using ClaimManager.Application.Interfaces.Repositories;
using ClaimManager.Application.Interfaces.Repositories.Claims;
using ClaimManager.Domain.Entities.Claims;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClaimManager.Application.Features.Claims.Commands.Create
{
    public partial class CreateClaimCommand : IRequest<Result<int>>
    {
        public string Title { get; set; }
        public string RequesterId { get; set; }
        public string ApproverId { get; set; }
        public DateTime SubmitDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string RequesterComments { get; set; }
        public List<CreateClaimCommandItemDto> ClaimItems { get; set; }
    }

    public class CreateClaimCommandHandler : IRequestHandler<CreateClaimCommand, Result<int>>
    {
        private readonly IClaimsRepository _claimsRepository;
        private readonly IMapper _mapper;
        private IUnitOfWork _unitOfWork { get; set; }

        public CreateClaimCommandHandler(IClaimsRepository claimsRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _claimsRepository = claimsRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateClaimCommand request, CancellationToken cancellationToken)
        {
            var claim = new Claim
            {
                Title = request.Title,
                RequesterId = request.RequesterId,
                ApproverId = request.ApproverId,
                SubmitDate = request.SubmitDate,
                TotalAmount = request.TotalAmount,
                RequesterComments = request.RequesterComments,
                ClaimItems = new List<ClaimItem>(),
            };

            foreach(CreateClaimCommandItemDto i in request.ClaimItems)
            {
                claim.ClaimItems.Add(new ClaimItem
                {
                    Payee = i.Payee,
                    Date = i.Date,
                    Description = i.Description,
                    Amount = i.Amount,
                    USDAmount = i.USDAmount,
                    Image = i.Image,
                    CurrencyId = i.CurrencyId,
                    ClaimCategoryId = i.ClaimCategoryId,
                });
            }

            await _claimsRepository.InsertAsync(claim);
            await _unitOfWork.Commit(cancellationToken);
            return Result<int>.Success(claim.Id);
        }
    }
}
