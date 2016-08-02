using CargosService.Business.Contract.Packaging;
using CargosService.Business.Implementation.Packaging;
using CargosService.Configuration.Contract.Settings;
using CargosService.TestFramework.CargoHelpers;
using CargosService.TestFramework.TruckHelpers;
using Moq;
using NUnit.Framework;

namespace CargosServiceUnitTests.Business
{
    [TestFixture]
    public class WeightTruckPackagerTests
    {
        private Mock<IPackagingManager> _managerMock;
        private Mock<IPackagingConfiguration> _configurationMock;
        private ITruckPackager _packager;

        [SetUp]
        public void SetUp()
        {
            _managerMock = new Mock<IPackagingManager>();
            _configurationMock = new Mock<IPackagingConfiguration>();

            _packager = new WeightTruckPackager(_managerMock.Object, _configurationMock.Object);
        }

        [Test]
        public void Should_Return_Pack_With_Three_Cargo()
        {
            var truck = TruckHelper.GetTestTruck();
            _managerMock.Setup(x => x.GetPrioritisedCargos(truck.Volume, truck.Payload))
                .Returns(CargoHelper.GetPrioritisedCargoes);
            _managerMock.Setup(x => x.GetNonPrioritisedCargos(truck.Volume, truck.Payload))
                .Returns(CargoHelper.GetBigWeightList);
            _configurationMock.Setup(c => c.FillThreshold).Returns(10);

            var pack = _packager.PackTruck(truck);

            Assert.AreEqual(3, pack.Cargos.Count);
        }

        [TestCase(10, 1)]
        [TestCase(99, 2)]
        public void Should_Return_Pack_With_Warnings(int fillThreshold, int warningCount)
        {
            var truck = TruckHelper.GetTestTruck();
            _managerMock.Setup(x => x.GetPrioritisedCargos(truck.Volume, truck.Payload))
                .Returns(CargoHelper.GetBigWeightList);
            _managerMock.Setup(x => x.GetNonPrioritisedCargos(truck.Volume, truck.Payload))
                .Returns(CargoHelper.GetBigWeightList);
            _configurationMock.Setup(c => c.FillThreshold).Returns(fillThreshold);

            var pack = _packager.PackTruck(truck);

            Assert.AreEqual(warningCount, pack.Warnings.Count);
        }
    }
}
