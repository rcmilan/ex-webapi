using Api.Domain.Models;
using System.Net;
using System.Threading.Tasks;

namespace Api.Tests.Api
{
    internal class UserControllerTests
    {
        [Test]
        public async Task ShouldAddUser()
        {
            // Arrange
            await using var application = new WebAppFactory("Development");
            var client = application.CreateClient();

            var user = new User(System.Guid.NewGuid(), "username", "user@email.com");
            var byteContent = Helpers.BuildContent(user);

            // Act
            var response = await client.PostAsync("/api/user", byteContent);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
