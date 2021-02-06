using AspNetCoreHero.Results;
using ClaimManager.Application.Interfaces.Repositories;
using ClaimManager.Application.Interfaces.Repositories.Claims;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClaimManager.Application.Features.Claims.Commands.Delete
{
    public class DeleteClaimCommand : IRequest<Result<int>>
    {
        public int Id { get; set; }
        public class DeleteClaimCommandHandler : IRequestHandler<DeleteClaimCommand, Result<int>>
        {
            private readonly IClaimsRepository _claimsRepository;
            private readonly IUnitOfWork _unitOfWork;

            public DeleteClaimCommandHandler(IClaimsRepository claimsRepository, IUnitOfWork unitOfWork)
            {
                _claimsRepository = claimsRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<Result<int>> Handle(DeleteClaimCommand command, CancellationToken cancellationToken)
            {
                var claim = await _claimsRepository.GetByIdAsync(command.Id);
                await _claimsRepository.DeleteAsync(claim);
                await _unitOfWork.Commit(cancellationToken);
                return Result<int>.Success(claim.Id);
            }

        }
    }
}
