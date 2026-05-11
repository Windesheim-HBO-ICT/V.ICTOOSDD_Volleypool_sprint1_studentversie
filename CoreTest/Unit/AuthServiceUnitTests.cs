using VolleyPool.Core.Interfaces.Repositories;
using VolleyPool.Core.Models;
using VolleyPool.Core.Services;
using VolleyPool.Data.Repostories;

namespace CoreTest.Unit
{
    public class AuthServiceUnitTests
    {
        AuthService authService;
        IParentRepository parentRepository;
        [SetUp]
        public void Setup()
        {
            parentRepository = new ParentRepository();
            IPlayerRepository playerRepository = new PlayerRepository();

            // For the sake of simplicity, the production repositories are used in the unit tests.
            // This should never be done in real scenarios, as it is dangerous.
            // Always use a repository instance with fake or mock data.

            authService = new AuthService(parentRepository, playerRepository);
        }

        [Test]
        public void IsFirstLogin_ParentWithValidPassword_ReturnsTrue()
        {
            var parentWithValidPassword = new Parent { Name = "Theo", Email = "theo@tilburg.nl", Phone = "06-1234567", Password = "abcde1" };
            var result = authService.IsFirstLogin(parentWithValidPassword);
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsFirstLogin_ParentWithEmptyPassword_ReturnsFalse()
        {
            var parentWithEmptyPassword = new Parent { Name = "Theo", Email = "theo@tilburg.nl", Phone = "06-1234567", Password = "" };
            var result = authService.IsFirstLogin(parentWithEmptyPassword);
            Assert.That(result, Is.True);
        }

        [Test]
        public void Register_WithValidData_ReturnsParent()
        {
            var result = authService.Register(
                1,
                new DateTime(2000, 1, 21),
                "Theo",
                "theo@tilburg.nl",
                "06-1234567",
                "SECRET1234556"
            );

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Theo"));
            Assert.That(result.Email, Is.EqualTo("theo@tilburg.nl"));
        }

        [Test]
        public void Register_NonExistingMemberId_ReturnsNull()
        {
            var result = authService.Register(0, new DateTime(2000, 1, 21), "Theo", "theo@tilburg.nl", "06-1234567", "SECRET1234556");
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Register_WrongBirthDate_ReturnsNull()
        {
            var result = authService.Register(1, new DateTime(2000, 1, 20), "Theo", "theo@tilburg.nl", "06-1234567", "SECRET1234556");
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Register_PaaswordOfLength5_ReturnsNull()
        {
            var result = authService.Register(1, new DateTime(2000, 1, 21), "Theo", "theo@tilburg.nl", "06-1234567", "12345");
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Register_PaaswordWithoutDigit_ReturnsNull()
        {
            var result = authService.Register(1, new DateTime(2000, 1, 21), "Theo", "theo@tilburg.nl", "06-1234567", "abcdef");
            Assert.That(result, Is.Null);
        }

        //#student-start:UC2#
        [Test]
        public void Register_LoginWithValidData_ReturnsParent()
        {
            var result = authService.Login("theo@tilburg.nl", "SECRET1234556");
            Assert.That(result, Is.EqualTo(parentRepository.Get("theo@tilburg.nl")));
        }

        [Test]
        public void Register_LoginWithInvalidPassword_ReturnsNull()
        {
            var result = authService.Login("theo@tilburg.nl", "SECRET");
            Assert.That(result, Is.Null);
        }

        [Test]
        public void Register_LoginWithInvalidUsername_ReturnsNull()
        {
            var result = authService.Login("theo@tilburg", "SECRET1234556");
            Assert.That(result, Is.Null);
        }
        //#student-end:UC2#
    }
}
