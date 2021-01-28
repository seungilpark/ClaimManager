using ClaimManager.Application.Interfaces.Shared;
using System;

namespace ClaimManager.Infrastructure.Shared.Services
{
    public class SystemDateTimeService : IDateTimeService
    {
        public DateTime NowUtc => DateTime.UtcNow;
    }
}