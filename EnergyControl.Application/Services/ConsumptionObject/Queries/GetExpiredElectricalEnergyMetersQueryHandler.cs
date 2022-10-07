using EnergyControl.Application.Persistence;
using EnergyControl.Contracts.ConsumptionObject;
using EnergyControl.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace EnergyControl.Application.Services.Queries
{
    public class GetExpiredElectricalEnergyMetersQueryHandler 
        : IRequestHandler<GetExpiredElectricalEnergyMetersQuery, GetExpiredElectricalEnergyMetersResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetExpiredElectricalEnergyMetersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetExpiredElectricalEnergyMetersResponse> Handle(
            GetExpiredElectricalEnergyMetersQuery query, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<ConsumptionObject>();
            var co = await repo.GetByIdAsync(query.Request.ConsumptionObjectId);

            if (co == null)
            {
                return new GetExpiredElectricalEnergyMetersResponse(new ExpiredElectricalEnergyMeter[0]);
            }

            var data = new List<ExpiredElectricalEnergyMeter>();

            foreach (var mp in co.ElectricityMeasuringPoints)
            {
                var eem = mp.ElectricalEnergyMeter;
                if (eem.VerificationDate < DateTime.Now)
                {
                    data.Add(new ExpiredElectricalEnergyMeter(eem.Number, (int)eem.Type, eem.VerificationDate));
                }
            }

            return new GetExpiredElectricalEnergyMetersResponse(data.ToArray());
        }
    }
}
