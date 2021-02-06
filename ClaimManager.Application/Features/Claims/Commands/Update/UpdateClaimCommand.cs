using AspNetCoreHero.Results;
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

namespace ClaimManager.Application.Features.Claims.Commands.Update
{
    
    /// <summary>
    /// Requester's Update
    /// </summary>
    public class UpdateClaimCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string RequesterId { get; set; }
        public string ApproverId { get; set; }
        public DateTime SubmitDate { get; set; }
        public string RequesterComments { get; set; }
        public ICollection<UpdateClaimCommandItemDto> ClaimItems { get; set; }
        public class UpdateClaimCommandHandler : IRequestHandler<UpdateClaimCommand, Result<int>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IClaimsRepository _claimsRepository;
            public UpdateClaimCommandHandler(IClaimsRepository claimsRepository, IUnitOfWork unitOfWork)
            {
                _unitOfWork = unitOfWork;
                _claimsRepository = claimsRepository;
            }               

            public async Task<Result<int>> Handle(UpdateClaimCommand command, CancellationToken cancellationToken)
            {
                Claim claim = await _claimsRepository.GetByIdAsync(command.Id);
                if (claim == null) throw new ApplicationException("claim not found");
                claim.Title = command.Title;
                claim.ApproverId = command.ApproverId;
                claim.SubmitDate = command.SubmitDate; 
                claim.RequesterComments = command.RequesterComments;

                IList<ClaimItem> claimItems = new List<ClaimItem>();

                foreach(UpdateClaimCommandItemDto i in command.ClaimItems)
                {
                    claimItems.Add(new ClaimItem
                    {
                        Payee = i.Payee,
                        Date = i.Date,
                        Description = i.Description,
                        Amount = i.Amount,
                        USDAmount = i.USDAmount,
                        Image = i.Image,
                        ClaimId = i.ClaimId,
                        ClaimCategoryId = i.ClaimCategoryId,
                        CurrencyId = i.CurrencyId,
                    });
                }
                claim.ClaimItems = claimItems;
                await _claimsRepository.UpdateAsync(claim);
                await _unitOfWork.Commit(cancellationToken);

                return Result<int>.Success(claim.Id);
            }
        }
    }

}
