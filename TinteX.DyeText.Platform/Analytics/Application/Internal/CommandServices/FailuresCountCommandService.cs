
using Microsoft.EntityFrameworkCore;
using TinteX.DyeText.Platform.Analytics.Domain.Model.Commands;
using TinteX.DyeText.Platform.Analytics.Domain.Model.Aggregates;
using TinteX.DyeText.Platform.Analytics.Domain.Repositories;
using TinteX.DyeText.Platform.Analytics.Domain.Services;
using TinteX.DyeText.Platform.Shared.Infrastructure.Persistence.EFC.Configuration;
using TinteX.DyeText.Platform.ARM.Domain.Model.Entities;
using TinteX.DyeText.Platform.ARM.Domain.Model.Aggregate;

namespace TinteX.DyeText.Platform.Analytics.Application.Internal.CommandServices
{
    public class FailuresCountCommandService : IFailureCountCommandService
    {
        private readonly IMachineFailureCountRepository _analyticsRepo;
        private readonly AppDbContext _context;

        public FailuresCountCommandService(
            IMachineFailureCountRepository analyticsRepo,
            AppDbContext context)
        {
            _analyticsRepo = analyticsRepo;
            _context = context;
        }

        public async Task Handle(UpdateMachineFailureCountsCommand command)
        {
            var joinedData = await (
                from tm in _context.Set<TextileMachine>()
                join mi in _context.Set<MachineInformation>() on tm.MachineInformationId equals mi.Id
                select new
                {
                    tm.Id,
                    tm.Name,
                    mi.AmountFailure
                }).ToListAsync();

            foreach (var item in joinedData)
            {
                var agg = new MachineFailureCount
                {
                    MachineId = item.Id,
                    MachineName = item.Name,
                    Count = (int)item.AmountFailure
                };
                await _analyticsRepo.UpsertAsync(agg);
            }
        }
    }
}