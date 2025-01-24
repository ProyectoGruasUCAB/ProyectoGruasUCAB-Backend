using Xunit;
using Moq;
using Microsoft.EntityFrameworkCore;
using API_GruasUCAB.Users.Infrastructure.Repositories;
using API_GruasUCAB.Users.Infrastructure;
using API_GruasUCAB.Users.Domain.Entities;
using API_GruasUCAB.Users.Application.DTOs;

namespace API_GruasUCAB.Test.UserTests
{
    public class GetAllAdmnistratorsAsyncTest
    {
        private readonly Mock<UserDbContext> _mockContext;
        private readonly AdministratorRepository _repository;

        public AdministratorRepositoryTest()
        {
            _mockContext = new Mock<UserDbContext>();
            _repository = new AdministratorRepository(_mockContext.Object);
        }

        [Fact]
        public async Task GetAllAdministratorsAsync_ShouldReturnAllAdministrators()
        {
            // Arrange
            var administrators = new List<Administrator>
            {
                new Administrator(new UserId(Guid.NewGuid()), new UserName("Admin1"), new UserEmail("admin1@example.com"), new UserPhone(1234567890), new UserCedula(1234567890), new UserBirthDate("01-01-1980")),
                new Administrator(new UserId(Guid.NewGuid()), new UserName("Admin2"), new UserEmail("admin2@example.com"), new UserPhone(1234567891), new UserCedula(1234567891), new UserBirthDate("02-02-1981"))
            }.AsQueryable();

            var mockSet = new Mock<DbSet<Administrator>>();
            mockSet.As<IQueryable<Administrator>>().Setup(m => m.Provider).Returns(administrators.Provider);
            mockSet.As<IQueryable<Administrator>>().Setup(m => m.Expression).Returns(administrators.Expression);
            mockSet.As<IQueryable<Administrator>>().Setup(m => m.ElementType).Returns(administrators.ElementType);
            mockSet.As<IQueryable<Administrator>>().Setup(m => m.GetEnumerator()).Returns(administrators.GetEnumerator());

            _mockContext.Setup(c => c.Administrators).Returns(mockSet.Object);

            // Act
            var result = await _repository.GetAllAdministratorsAsync();

            // Assert
            Assert.Equal(2, result.Count);
            Assert.Equal("Admin1", result[0].Name);
            Assert.Equal("Admin2", result[1].Name);
        }
    }
}