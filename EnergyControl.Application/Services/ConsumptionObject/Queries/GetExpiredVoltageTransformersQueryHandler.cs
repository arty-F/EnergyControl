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
    public class GetExpiredVoltageTransformersQueryHandler 
        : IRequestHandler<GetExpiredVoltageTransformersQuery, GetExpiredVoltageTransformersResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetExpiredVoltageTransformersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<GetExpiredVoltageTransformersResponse> Handle(
            GetExpiredVoltageTransformersQuery query, CancellationToken cancellationToken)
        {
            var repo = _unitOfWork.GetRepository<ConsumptionObject>();
            var co = await repo.GetByIdAsync(query.Request.ConsumptionObjectId);

            if (co == null)
            {
                return new GetExpiredVoltageTransformersResponse(new ExpiredVoltageTransformers[0]);
            }

            var data = new List<ExpiredVoltageTransformers>();

            foreach (var mp in co.ElectricityMeasuringPoints)
            {
                var vt = mp.VoltageTransformer;
                if (vt.VerificationDate < DateTime.Now)
                {
                    data.Add(new ExpiredVoltageTransformers(vt.Number, (int)vt.Type, vt.VerificationDate, vt.TransformationRatio));
                }
            }

            return new GetExpiredVoltageTransformersResponse(data.ToArray());
        }
    }
}
