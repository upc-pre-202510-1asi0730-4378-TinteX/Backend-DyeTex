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
    public class FailureRateCommandService : IFailureRateCommandService
    {
        private readonly IMachineFailureRateRepository _analyticsRepo;
        private readonly AppDbContext _context;

        public FailureRateCommandService(
            IMachineFailureRateRepository analyticsRepo,
            AppDbContext context)
        {
            _analyticsRepo = analyticsRepo;
            _context = context;
        }

        public async Task Handle(UpdateMachineFailureRatesCommand command)
        {
            var joinedData = await (
                from tm in _context.Set<TextileMachine>()
                join mi in _context.Set<MachineInformation>() on tm.MachineInformationId equals mi.Id
                select new
                {
                    tm.Id,
                    tm.Name,
                    mi.FailureRate
                }).ToListAsync();

            foreach (var item in joinedData)
            {
                decimal rateDecimal = 0;

                // Validación segura del FailureRate (en caso sea un string como "20%")
                if (!string.IsNullOrWhiteSpace(item.FailureRate.ToString()))
                {
                    string normalized = item.FailureRate.ToString().Replace("%", "").Trim();
                    if (decimal.TryParse(normalized, out decimal parsed))
                    {
                        rateDecimal = parsed / 100;
                    }
                }

                var agg = new MachineFailureRate
                {
                    MachineId = item.Id,
                    MachineName = item.Name,
                    Rate = (double)rateDecimal
                };

                await _analyticsRepo.UpsertAsync(agg);
            }
        }
    }
}
