using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Api.Domain.Models;

namespace Api.Tests.Api
{
    internal class UserControllerTests
    {
        private const string BASE_PATH = "/api/user";

        [Test]
        public async Task ShouldAddUser()
        {
            // Arrange
            await using var application = new WebAppFactory("Development");
            var client = application.CreateClient();

            var user = new User(System.Guid.NewGuid(), "username", "user@email.com");
            var byteContent = user.BuildByteContent();

            // Act
            var response = await client.PostAsync(BASE_PATH, byteContent);

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task ShouldAddAndGetAll()
        {
            // Arrange
            await using var application = new WebAppFactory("Development");
            var client = application.CreateClient();

            var users = new List<User>();

            var user1 = new User(System.Guid.NewGuid(), "username 1", "user1@email.com");
            var user2 = new User(System.Guid.NewGuid(), "username 2", "user2@email.com");
            var user3 = new User(System.Guid.NewGuid(), "username 3", "user3@email.com");

            users.Add(user1);
            users.Add(user2);
            users.Add(user3);

            foreach (var user in users)
            {
                var byteContent = user.BuildByteContent();
                await client.PostAsync(BASE_PATH, byteContent);
            }

            // Act
            var response = await client.GetAsync(BASE_PATH);

            var actual = await response.DeserializeContentAsync<IEnumerable<User>>();

            // Assert
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);

            Assert.Contains(user1.ID, actual.Select(u => u.ID).ToList());
            Assert.Contains(user2.ID, actual.Select(u => u.ID).ToList());
            Assert.Contains(user3.ID, actual.Select(u => u.ID).ToList());
        }

    }
}
