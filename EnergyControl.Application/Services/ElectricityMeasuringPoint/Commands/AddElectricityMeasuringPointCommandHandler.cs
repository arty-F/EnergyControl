using EnergyControl.Application.Persistence;
using EnergyControl.Contracts.ElectricityMeasuringPoint;
using EnergyControl.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace EnergyControl.Application.Services.Commands
{
    public class AddElectricityMeasuringPointCommandHandler 
        : IRequestHandler<AddElectricityMeasuringPointCommand, AddElectricityMeasuringPointResponse>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddElectricityMeasuringPointCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<AddElectricityMeasuringPointResponse> Handle(
            AddElectricityMeasuringPointCommand command, CancellationToken cancellationToken)
        {
            var eem = await AddNewElectricalEnergyMeterAsync(command.Request);
            var pt = await AddNewPowerTransformerAsync(command.Request);
            var vt = await AddNewVoltageTransformerAsync(command.Request);

            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (System.Exception)
            {
                return new AddElectricityMeasuringPointResponse(false);
            }

            await AddNewElectricityMeasuringPointAsync(command.Request, eem, pt, vt);

            try
            {
                await _unitOfWork.SaveAsync();
            }
            catch (System.Exception)
            {
                return new AddElectricityMeasuringPointResponse(false);
            }
            
            return new AddElectricityMeasuringPointResponse(true);
        }

        private async Task<ElectricalEnergyMeter> AddNewElectricalEnergyMeterAsync(AddElectricityMeasuringPointRequest request)
        {
            var entity = new ElectricalEnergyMeter
            {
                Number = request.ElectricalEnergyMeterNumber,
                Type = (ElectricalEnergyMeterType)request.ElectricalEnergyMeterType,
                VerificationDate = request.ElectricalEnergyMeterVerificationDate
            };
            var eemRepo = _unitOfWork.GetRepository<ElectricalEnergyMeter>();
            await eemRepo.AddAsync(entity);
            return entity;
        }

        private async Task<PowerTransformer> AddNewPowerTransformerAsync(AddElectricityMeasuringPointRequest request)
        {
            var entity = new PowerTransformer
            {
                Number = request.PowerTransformerNumber,
                Type = (TransformerType)request.PowerTransformerType,
                VerificationDate = request.PowerTransformerVerificationDate
            };
            var ptRepo = _unitOfWork.GetRepository<PowerTransformer>();
            await ptRepo.AddAsync(entity);
            return entity;
        }

        private async Task<VoltageTransformer> AddNewVoltageTransformerAsync(AddElectricityMeasuringPointRequest request)
        {
            var entity = new VoltageTransformer
            {
                Number = request.VoltageTransformerNumber,
                Type = (TransformerType)request.VoltageTransformerType,
                VerificationDate = request.VoltageTransformerVerificationDate
            };
            var vtRepo = _unitOfWork.GetRepository<VoltageTransformer>();
            await vtRepo.AddAsync(entity);
            return entity;
        }

        private async Task AddNewElectricityMeasuringPointAsync(
            AddElectricityMeasuringPointRequest request, ElectricalEnergyMeter eem, PowerTransformer pt, VoltageTransformer vt)
        {
            var entity = new ElectricityMeasuringPoint
            {
                Name = request.Name,
                ElectricalEnergyMeterId = eem.Id,
                PowerTransformerId = pt.Id,
                VoltageTransformerId = vt.Id
            };
            var empRepo = _unitOfWork.GetRepository<ElectricityMeasuringPoint>();
            await empRepo.AddAsync(entity);
        }
    }
}
