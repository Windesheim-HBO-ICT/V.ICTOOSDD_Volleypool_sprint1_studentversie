using System;
using System.Collections.Generic;
using System.Text;
using VolleyPool.Core.Interfaces.Repositories;
using VolleyPool.Core.Models;
using VolleyPool.Core.Services;
using VolleyPool.Data.Repostories;

//sprint-3-uc1-invoeren-speler
namespace CoreTest.Unit
{
    internal class TestPlayerRepository : PlayerRepository
    {
        //Instead of using the production repository, we create a test repository with fake data for testing purposes.
        //We're inheriting from the production repository to reuse its methods, but we override the data with our own test data.
        //This is the easy way, instead of creating a completely new repository from scratch. In real scenarios,
        //you would typically use a mocking framework like Moq to create mock repositories without needing to create a
        //separate class.. You will learn this in the C# lessons.

        private Player[] players = [

        ];

    }

    public class PlayerServiceUnitTests
    {
        IPlayerRepository playerRepository;
        PlayerService playerService;
        [SetUp]
        public void Setup()
        {
            playerRepository = new TestPlayerRepository();
            playerService = new PlayerService(playerRepository);
        }

        [Test]
        public void AddPlayer_WithValidData_ReturnsPlayer()
        {
            var playerWithValidData = new Player { Name = "Theo", Surname = "Thijssen", BirthDate = DateTime.Now, MemberId = -1 };
            var result = playerService.Add(playerWithValidData);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("Theo"));
            Assert.That(result.MemberId, Is.Not.EqualTo(-1));
        }

        [Test]
        public void AddPlayer_WithInvalidBirthDate_ThrowsException()
        {
            var playerWithInvalidData = new Player {
                Name = "Johan",
                Surname = "Nienhuis",
                //In the future
                BirthDate = DateTime.Now.AddDays(1),
                MemberId = -1
            };
            Assert.Throws<ArgumentException>(() => playerService.Add(playerWithInvalidData));
        }
    }
}


