using CargosService.Business.Contract.Packaging;
using CargosService.Business.Implementation.Packaging;
using CargosService.Common.Contracts;
using CargosService.Configuration.Contract.Settings;
using CargosService.TestFramework.CargoHelpers;
using CargosService.TestFramework.TruckHelpers;
using Moq;
using NUnit.Framework;

namespace CargosServiceUnitTests.Business
{
    [TestFixture]
    public class PackagingServiceTests
    {
        private Mock<IPackagingManager> _managerMock;
        private Mock<IPackagingConfiguration> _configurationMock; 
        private IPackagingService _service;

        [SetUp]
        public void SetUp()
        {
            _managerMock = new Mock<IPackagingManager>();
            _configurationMock = new Mock<IPackagingConfiguration>();

            _service = new PackagingService(_managerMock.Object, _configurationMock.Object);
        }

        [Test]
        public void Should_Return_Package_With_Two_Cargos()
        {
            var truck = TruckHelper.GetTestTruck();
            _managerMock.Setup(x => x.GetPrioritisedCargos(truck.Volume, truck.Payload))
                .Returns(CargoHelper.GetBigVolumeList);
            _configurationMock.Setup(c => c.FillThreshold).Returns(10);
            _configurationMock.Setup(c => c.Strategy).Returns(OptimizationStrategy.Volume);

            var pack = _service.LoadTruck(truck);

            Assert.AreEqual(2, pack.Cargos.Count);
        }

        [Test]
        public void Should_Return_Package_With_One_Cargo()
        {
            var truck = TruckHelper.GetTestTruck();
            _managerMock.Setup(x => x.GetPrioritisedCargos(truck.Volume, truck.Payload))
                .Returns(CargoHelper.GetBigWeightList);
            _configurationMock.Setup(c => c.FillThreshold).Returns(10);
            _configurationMock.Setup(c => c.Strategy).Returns(OptimizationStrategy.Weight);

            var pack = _service.LoadTruck(truck);

            Assert.AreEqual(1, pack.Cargos.Count);
        }
    }
}
