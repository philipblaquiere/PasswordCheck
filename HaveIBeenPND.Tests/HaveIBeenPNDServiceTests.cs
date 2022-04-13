using HaveIBeenPND.Contracts;
using HaveIBeenPND.Entities;
using HaveIBeenPND.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HaveIBeenPND.Tests
{
    [TestClass]
    public class HaveIBeenPNDServiceTests
    {
        [TestMethod]
        public async Task HaveIBeenPND_EmptyPassword_ReturnsNull()
        {
            // Arrange
            IHaveIBeenPNDClient client = new MockHaveIBeenPNDClient();
            IHaveIBeenPNDService service = new HaveIBeenPNDService(client);
            string password = "";

            // Act
            PNDPassword? pndPassword = await service.HaveIBeenPND(password);

            // Assert
            Assert.IsNull(pndPassword);
        }

        [TestMethod]
        public async Task HaveIBeenPND_PasswordFound_ReturnsPNDPassword()
        {
            // Arrange
            IHaveIBeenPNDClient client = new MockHaveIBeenPNDClient();
            IHaveIBeenPNDService service = new HaveIBeenPNDService(client);
            string password = "Testing1234";

            // Act
            PNDPassword? pndPassword = await service.HaveIBeenPND(password);

            // Assert
            Assert.IsNotNull(pndPassword);
        }


        [TestMethod]
        public async Task HaveIBeenPND_PrefixNotFound_ReturnsNull()
        {
            // Arrange
            IHaveIBeenPNDClient client = new MockHaveIBeenPNDClientEmpty();
            IHaveIBeenPNDService service = new HaveIBeenPNDService(client);
            string password = "Testing1234";

            // Act
            PNDPassword? pndPassword = await service.HaveIBeenPND(password);

            // Assert
            Assert.IsNull(pndPassword);
        }
    }
}
