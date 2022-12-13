using EnergyControl.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EnergyControl.Domain.DataInitializers
{
    public class EnergyControlDbInitializer
    {
        public List<Organization> Organizations { get; private set; } = null!;
        public List<Subsidiary> Subsidiaries { get; private set; } = null!;
        public List<ConsumptionObject> ConsumptionObjects { get; private set; } = null!;
        public List<SettlementMeter> SettlementMeters { get; private set; } = null!;
        public List<ElectricityMeasuringPoint> ElectricityMeasuringPoints { get; private set; } = null!;
        public List<ElectricitySupplyPoint> ElectricitySupplyPoints { get; private set; } = null!;
        public List<ElectricalEnergyMeter> ElectricalEnergyMeters { get; private set; } = null!;
        public List<PowerTransformer> PowerTransformers { get; private set; } = null!;
        public List<VoltageTransformer> VoltageTransformers { get; private set; } = null!;

        public EnergyControlDbInitializer()
        {
            CreateOrganizations();
            CreateSubsidiaries();
            CreateConsumptionObjects();
            CreateSettlementMeters();
            CreateElectricitySupplyPoints();
            CreateElectricalEnergyMeters();
            CreatePowerTransformers();
            CreateVoltageTransformers();
            CreateElectricityMeasuringPoints();
        }

        private void CreateOrganizations()
        {
            Organizations = new List<Organization>(1);
            Organizations.Add(new Organization
            {
                Id = 1,
                Name = "FirstOrganization",
                Address = "DefaultAddress"
            });
        }

        private void CreateSubsidiaries()
        {
            Subsidiaries = new List<Subsidiary>(1);
            Subsidiaries.Add(new Subsidiary
            {
                Id = 1,
                Name = "FirstSubsidiary",
                Address = "DefaultAddress",
                OrganizationId = 1
            });
        }

        private void CreateConsumptionObjects()
        {
            ConsumptionObjects = new List<ConsumptionObject>(1);
            ConsumptionObjects.Add(new ConsumptionObject
            {
                Id = 1,
                Name = "FirstConsumptionObject",
                Address = "DefaultAddress",
                SubsidiaryId = 1,
            });
        }

        private void CreateSettlementMeters()
        {
            SettlementMeters = new List<SettlementMeter>(2);
            SettlementMeters.Add(new SettlementMeter
            {
                Id = 1,
                StartDate = new DateTime(2017, 3, 1),
                EndDate = new DateTime(2017, 12, 1),
            });
            SettlementMeters.Add(new SettlementMeter
            {
                Id = 2,
                StartDate = new DateTime(2018, 3, 1),
                EndDate = new DateTime(2018, 12, 1),
            });
        }

        private void CreateElectricitySupplyPoints()
        {
            ElectricitySupplyPoints = new List<ElectricitySupplyPoint>(2);
            ElectricitySupplyPoints.Add(new ElectricitySupplyPoint
            {
                Id = 1,
                Name = "FirstElectricitySupplyPoint",
                MaxPower = 100f,
                ConsumptionObjectId = 1,
                SettlementMeterId = 1
            });
            ElectricitySupplyPoints.Add(new ElectricitySupplyPoint
            {
                Id = 2,    
                Name = "SecondElectricitySupplyPoint",
                MaxPower = 200f,
                ConsumptionObjectId = 1,
                SettlementMeterId = 2
            });
        }

        private void CreateElectricalEnergyMeters()
        {
            ElectricalEnergyMeters = new List<ElectricalEnergyMeter>(2);
            ElectricalEnergyMeters.Add(new ElectricalEnergyMeter
            {
                Id = 1,
                Number = "FirstElectricalEnergyMeterNumber",
                Type = ElectricalEnergyMeterType.MeterA,
                VerificationDate = new DateTime(2022, 3, 1),
            });
            ElectricalEnergyMeters.Add(new ElectricalEnergyMeter
            {
                Id = 2,
                Number = "SecondElectricalEnergyMetersNumber",
                Type = ElectricalEnergyMeterType.MeterB,
                VerificationDate = new DateTime(2023, 3, 1),
            });
        }

        private void CreatePowerTransformers()
        {
            PowerTransformers = new List<PowerTransformer>(2);
            PowerTransformers.Add(new PowerTransformer
            {
                Id = 1,
                Number = "FirstPowerTransformerNumber",
                TransformationRatio = 1.5f,
                Type = TransformerType.TransformerA,
                VerificationDate = new DateTime(2022, 3, 1),
            });
            PowerTransformers.Add(new PowerTransformer
            {
                Id = 2,
                Number = "SecondPowerTransformerNumber",
                TransformationRatio = 2.5f,
                Type = TransformerType.TransformerB,
                VerificationDate = new DateTime(2023, 3, 1),
            });
        }

        private void CreateVoltageTransformers()
        {
            VoltageTransformers = new List<VoltageTransformer>(2);
            VoltageTransformers.Add(new VoltageTransformer
            {
                Id = 1,
                Number = "FirstVoltageTransformerNumber",
                TransformationRatio = 0.5f,
                Type = TransformerType.TransformerC,
                VerificationDate = new DateTime(2022, 3, 1),
            });
            VoltageTransformers.Add(new VoltageTransformer
            {
                Id = 2,
                Number = "SecondVoltageTransformerNumber",
                TransformationRatio = 0.75f,
                Type = TransformerType.TransformerA,
                VerificationDate = new DateTime(2023, 3, 1),
            });
        }

        private void CreateElectricityMeasuringPoints()
        {
            ElectricityMeasuringPoints = new List<ElectricityMeasuringPoint>(2);
            ElectricityMeasuringPoints.Add(new ElectricityMeasuringPoint
            {
                Id = 1,
                Name = "FirstElectricityMeasuringPoint",
                ConsumptionObjectId = 1,
                SettlementMeterId = 1,
                ElectricalEnergyMeterId = 1,
                PowerTransformerId = 1,
                VoltageTransformerId = 1
            });
            ElectricityMeasuringPoints.Add(new ElectricityMeasuringPoint
            {
                Id = 2,
                Name = "SecondElectricityMeasuringPoint",
                ConsumptionObjectId = 1,
                SettlementMeterId = 2,
                ElectricalEnergyMeterId = 2,
                PowerTransformerId = 2,
                VoltageTransformerId = 2
            });
        }
    }
}
