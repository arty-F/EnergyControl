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
    public class GetExpiredPowerTransformersQueryHandler 
        : IRequestHandler<GetExpiredPowerTransformersQuery, GetExpiredPowerTransformersResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetExpiredPowerTransformersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetExpiredPowerTransformersResponse> Handle(
            GetExpiredPowerTransformersQuery query, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<ConsumptionObject>();
            var co = await repo.GetByIdAsync(query.Request.ConsumptionObjectId);

            if (co == null)
            {
                return new GetExpiredPowerTransformersResponse(new ExpiredPowerTransformers[0]);
            }

            var data = new List<ExpiredPowerTransformers>();

            foreach (var mp in co.ElectricityMeasuringPoints)
            {
                var pt = mp.PowerTransformer;
                if (pt.VerificationDate < DateTime.Now)
                {
                    data.Add(new ExpiredPowerTransformers(pt.Number, (int)pt.Type, pt.VerificationDate, pt.TransformationRatio));
                }
            }

            return new GetExpiredPowerTransformersResponse(data.ToArray());
        }
    }
}
