using EnergyControl.Application.Persistence;
using EnergyControl.Contracts.SettlementMeter;
using EnergyControl.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EnergyControl.Application.Services.Queries
{
    public class GetSettlementMeterByYearQueryHandler : IRequestHandler<GetSettlementMeterByYearQuery, GetSettlementMeterByYearResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSettlementMeterByYearQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetSettlementMeterByYearResponse> Handle(GetSettlementMeterByYearQuery query, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<SettlementMeter>();
            var a = await repo.GetAsync(a =>
                a.EndDate.Year == query.Request.Year
                || a.StartDate.Year == query.Request.Year
                || a.StartDate.Year < query.Request.Year && a.EndDate.Year > query.Request.Year);

            return new GetSettlementMeterByYearResponse(a?.Count() ?? 0);
        }
    }
}
