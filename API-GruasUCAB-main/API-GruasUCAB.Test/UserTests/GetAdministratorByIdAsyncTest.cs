using System;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using API_GruasUCAB.Users.Infrastructure.Repositories;
using API_GruasUCAB.Users.Infrastructure;
using API_GruasUCAB.Users.Domain.Entities;
using API_GruasUCAB.Users.Application.DTOs;

namespace API_GruasUCAB.Test.UserTests
{
    public class GetAdministratorByIdAsyncTest
    {
        private readonly Mock<UserDbContext> _mockContext;
        private readonly AdministratorRepository _repository;

        public AdministratorRepositoryTest()
        {
            _mockContext = new Mock<UserDbContext>();
            _repository = new AdministratorRepository(_mockContext.Object);
        }

        [Fact]
        public async Task GetAdministratorByIdAsync_ShouldReturnAdministrator_WhenAdministratorExists()
        {
            // Arrange
            var adminId = Guid.NewGuid();
            var admin = new Administrator(new UserId(adminId), new UserName("Admin1"), new UserEmail("admin1@example.com"), new UserPhone(1234567890), new UserCedula(1234567890), new UserBirthDate("01-01-1980"));

            var mockSet = new Mock<DbSet<Administrator>>();
            mockSet.Setup(m => m.FindAsync(new UserId(adminId))).ReturnsAsync(admin);

            _mockContext.Setup(c => c.Administrators).Returns(mockSet.Object);

            // Act
            var result = await _repository.GetAdministratorByIdAsync(adminId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("Admin1", result.Name);
        }

        [Fact]
        public async Task GetAdministratorByIdAsync_ShouldThrowException_WhenAdministratorDoesNotExist()
        {
            // Arrange
            var adminId = Guid.NewGuid();

            var mockSet = new Mock<DbSet<Administrator>>();
            mockSet.Setup(m => m.FindAsync(new UserId(adminId))).ReturnsAsync((Administrator)null);

            _mockContext.Setup(c => c.Administrators).Returns(mockSet.Object);

            // Act & Assert
            await Assert.ThrowsAsync<KeyNotFoundException>(() => _repository.GetAdministratorByIdAsync(adminId));
        }
    }
}