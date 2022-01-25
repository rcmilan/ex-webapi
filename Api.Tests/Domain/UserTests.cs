using Api.Domain.Models;
using NUnit.Framework;
using System;

namespace Api.Tests.Domain
{
    internal class UserTests
    {
        [Test]
        [TestCase("username", "email@email.com")]
        public void ShouldBuild(string name, string email)
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            var result = new User(id, name, email);

            // Assert
            Assert.AreEqual(id, result.ID);
            Assert.AreEqual(name, result.Name);
            Assert.AreEqual(email, result.Email);
        }
    }
}
