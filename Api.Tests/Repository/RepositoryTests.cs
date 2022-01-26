using Api.Domain.Models;
using Api.Repository.Interfaces;
using Api.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Tests.Repository
{
    internal class RepositoryTests
    {
        private IRepository<User, Guid> _repository;

        public RepositoryTests()
        {
            _repository = new Repository<User, Guid>();
        }

        [Test]
        public void ShouldAdd()
        {
            // Arrange
            var entity = new User(Guid.NewGuid());

            // Act
            var result = _repository.Add(entity);

            // Assert
            Assert.AreEqual(entity, result);
        }

        [Test]
        public void ShouldAddMany()
        {
            // Arrange
            var entities = new List<User>
            {
                new User(Guid.NewGuid()),
                new User(Guid.NewGuid())
            };

            // Act
            var result = _repository.Add(entities);

            // Assert
            Assert.AreEqual(entities, result);
        }


        [Test]
        public void ShouldGetById()
        {
            // Arrange
            var entity = new User(Guid.NewGuid());

            // Act
            _repository.Add(entity);

            var result = _repository.Get(entity.ID);

            // Assert
            Assert.AreEqual(entity, result);
        }

        [Test]
        public void ShouldGet()
        {
            // Arrange
            var entity = new User(Guid.NewGuid());

            // Act
            _repository.Add(entity);

            var result = _repository.Get(e => e.ID == entity.ID);

            // Assert
            Assert.Contains(entity, result.ToList());
        }


        [Test]
        public void ShouldGetAll()
        {
            // Arrange
            var entities = new List<User>
            {
                new User(Guid.NewGuid()),
                new User(Guid.NewGuid())
            };

            // Act
            _repository.Add(entities);

            var result = _repository.GetAll();

            // Assert
            foreach (var r in result)
            {
                Assert.Contains(r, result.ToArray());
            }
        }

        [Test]
        public void ShouldRemove()
        {
            var user = new User(Guid.NewGuid());

            // Arrange
            var entities = new List<User>
            {
                new User(Guid.NewGuid()),
                user
            };

            // Act
            _repository.Add(entities);

            var result = _repository.Remove(user.ID);

            // Assert
            Assert.IsTrue(result == 1);
        }

        [Test]
        public void ShouldRemoveMany()
        {
            var user1 = new User(Guid.NewGuid());
            var user2 = new User(Guid.NewGuid());

            // Arrange
            var entities = new List<User>
            {
                user1,
                user2
            };

            // Act
            _repository.Add(entities);

            var result = _repository.Remove(e => entities.Any(d => d.ID == e.ID));

            // Assert
            Assert.IsTrue(result == 2);
        }
    }
}