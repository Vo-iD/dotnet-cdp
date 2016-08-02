using System.Linq;
using CargosService.Business.Contract.Packaging;
using CargosService.Business.Implementation.Packaging;
using CargosService.Configuration.Contract.Settings;
using CargosService.DataAccess.Contract.Infrastructure;
using CargosService.DataAccess.Contract.Models;
using CargosService.TestFramework.CargoHelpers;
using Moq;
using NUnit.Framework;

namespace CargosServiceUnitTests.Business
{
    [TestFixture]
    public class PackagingManagerTests
    {
        private Mock<IFullRepository<Cargo>> _repositoryMock;
        private Mock<IPackagingConfiguration> _configurationMock; 
        private IPackagingManager _manager;

        [SetUp]
        public void SetUp()
        {
            _repositoryMock = new Mock<IFullRepository<Cargo>>();
            _configurationMock = new Mock<IPackagingConfiguration>();

            _manager = new PackagingManager(_repositoryMock.Object, _configurationMock.Object);
        }

        [Test]
        public void PrioritisedCargos_Should_Be_Two()
        {
            _repositoryMock.Setup(r => r.Get()).Returns(CargoHelper.GetFullCargoList);
            _configurationMock.Setup(c => c.HighPriorityDayThreshold).Returns(2);

            var prioritisedCargos = _manager.GetPrioritisedCargos(100, 10000);

            Assert.AreEqual(2, prioritisedCargos.Count());
        }

        [Test]
        public void NonPrioritisedCargos_Should_Be_Three()
        {
            _repositoryMock.Setup(r => r.Get()).Returns(CargoHelper.GetFullCargoList);
            _configurationMock.Setup(c => c.HighPriorityDayThreshold).Returns(2);

            var nonPrioritisedCargos = _manager.GetNonPrioritisedCargos(100, 10000);

            Assert.AreEqual(3, nonPrioritisedCargos.Count());
        }
    }
}
