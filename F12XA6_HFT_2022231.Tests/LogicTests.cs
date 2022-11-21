using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using F12XA6_HFT_2022231.Logic;
using F12XA6_HFT_2022231.Logic.ModelLogics;
using F12XA6_HFT_2022231.Models;
using F12XA6_HFT_2022231.Repository.Interfaces;
using Moq;

namespace F12XA6_HFT_2022231.Tests
{
    public class Tests
    {
        private Mock<IRepository<Game>> mockGameRepo;
        private Mock<IRepository<Developer>> mockDevRepo;
        private Mock<IRepository<DevStudio>> mockStudioRepo;
        [SetUp]
        public void Init()
        {
            #region Mock Data

            var a = new DevStudio { Id = 1, StudioName = "CD Pojekt RED", Games = new List<Game>(), Employees = new List<Developer>() };
            var b = new DevStudio { Id = 2, StudioName = "Rockstar Games", Games = new List<Game>(), Employees = new List<Developer>() };
            var studios = new List<DevStudio> { a, b };


            var g1 = new Game { Id = 1, GameTitle = "Cyberpunk2077", PublisherStudio = a, Price = 60, Rating = 2 };
            var g2 = new Game { Id = 2, GameTitle = "Grand Theft Auto V", PublisherStudio = b, Price = 50, Rating = 7 };
            var g3 = new Game { Id = 3, GameTitle = "Grand Theft Auto IV", PublisherStudio = b, Rating = 6 };
            var g4 = new Game { Id = 4, GameTitle = "The Witcher 3: Wild hunt", PublisherStudio = a, Price = 55, Rating = 4 };
            var games = new List<Game> { g1, g2, g3, g4 };

            var e1 = new Developer { Id = 2, DevName = "Carter", Company = a, Salary = 64000 };
            var e2 = new Developer { Id = 4, DevName = "Mike", Company = a, Salary = 82000 };
            var e3 = new Developer { Id = 6, DevName = "Noah", Company = b, Salary = 120000 };
            var devs = new List<Developer> { e1, e2, e3 };

            a.Games.Add(g1);
            a.Games.Add(g4);
            a.Employees.Add(e1);
            a.Employees.Add(e2);

            b.Games.Add(g2);
            b.Games.Add(g3);
            b.Employees.Add(e3);

            #endregion

            mockStudioRepo = new Mock<IRepository<DevStudio>>();
            mockStudioRepo.Setup(m => m.ReadAll()).Returns(studios);

            mockGameRepo = new Mock<IRepository<Game>>();
            mockGameRepo.Setup(m => m.ReadAll()).Returns(games);

            mockDevRepo = new Mock<IRepository<Developer>>();
            mockDevRepo.Setup(m => m.ReadAll()).Returns(devs);

        }

        #region GameLogic Tests

        #region non CRUD method tests

        [Test]
        public void GameCountByStudioWithRightInput()
        {

            var logic = new GameLogic(mockGameRepo.Object);

            var res = logic.GameCountByStudio();

            Assert.That(res.First().GameCount, Is.EqualTo(2));
            Assert.That(res.First().PublisherStudioName, Is.EqualTo("CD Pojekt RED"));
            Assert.That(res.ElementAt(1).GameCount, Is.EqualTo(2));
            Assert.That(res.ElementAt(1).PublisherStudioName, Is.EqualTo("Rockstar Games"));

        }
        [Test]
        public void AvgRatingByStudioWithRightInput()
        {

            var logic = new GameLogic(mockGameRepo.Object);

            var res = logic.AvgRatingByStudio();


            Assert.That(res.First().AvgRating, Is.EqualTo(3));
            Assert.That(res.First().PublisherStudioName, Is.EqualTo("CD Pojekt RED"));
            Assert.That(res.ElementAt(1).AvgRating, Is.EqualTo(6.5));
            Assert.That(res.ElementAt(1).PublisherStudioName, Is.EqualTo("Rockstar Games"));

        }

        #endregion

        #region Create tests

        [Test]
        public void GameCreateRightData()
        {
            var logic = new GameLogic(mockGameRepo.Object);
            var game = new Game { Id = 1, GameTitle = "Cyberpunk2077", Price = 60, Rating = 2, PublisherStudio = new DevStudio(), Developers = new List<Developer>() };
            logic.Create(game);
            mockGameRepo.Verify(g => g.Create(game), Times.Once);
        }
        [Test]
        public void GameCreateDevelopersIsNull()
        {
            var logic = new GameLogic(mockGameRepo.Object);
            var game = new Game { Id = 1, GameTitle = "Cyberpunk2077", Price = 60, Rating = 2, PublisherStudio = new DevStudio() };
            try
            {
                logic.Create(game);
            }
            catch
            {

            }
            mockGameRepo.Verify(g => g.Create(game), Times.Never);
        }
        [Test]
        public void GameCreateGameTitleIsNull()
        {
            var logic = new GameLogic(mockGameRepo.Object);
            mockGameRepo.Verify(g => g.Create(new Game { Id = 1, GameTitle = "", Developers = new List<Developer>(), Price = 60, Rating = 2, PublisherStudio = new DevStudio() }), Times.Never);
        }
        [Test]
        public void GameCreatePublisherStudioIsNull()
        {
            var logic = new GameLogic(mockGameRepo.Object);
            var game = new Game { Id = 1, GameTitle = "Cyberpunk2077", Developers = new List<Developer>(), Price = 60, Rating = 2 };
            try
            {
                logic.Create(game);
            }
            catch
            {

            }
            mockGameRepo.Verify(g => g.Create(game), Times.Never);
        }
        [Test]
        public void GameCreateObjectIsNull()
        {
            var logic = new GameLogic(mockGameRepo.Object);
            try
            {
                logic.Create(null);
            }
            catch
            {

            }

            mockGameRepo.Verify(g => g.Create(null), Times.Never);
        }
        #endregion
        #endregion

        #region DeveloperLogic Tests

        #region non CRUD Tests

        [Test]
        public void DeveloperEmployeeNamesByCompanyTest()
        {

            var logic = new DeveloperLogic(mockDevRepo.Object);

            var res = logic.EmployeeNamesByCompany();

            Assert.That(res.First().Developernames, Is.EqualTo(new List<string> { "Carter", "Mike" }));
            Assert.That(res.First().CompanyName, Is.EqualTo("CD Pojekt RED"));
            Assert.That(res.ElementAt(1).Developernames, Is.EqualTo(new List<string> { "Noah" }));
            Assert.That(res.ElementAt(1).CompanyName, Is.EqualTo("Rockstar Games"));

        }

        #endregion

        #region Create Tests

        [Test]
        public void DeveloperCreateObjectIsNull()
        {
            var logic = new DeveloperLogic(mockDevRepo.Object);
            try
            {
                logic.Create(null);
            }
            catch
            {

            }
            mockDevRepo.Verify(g => g.Create(null), Times.Never);
        }
        [Test]
        public void DeveloperCreateCompanyIsNull()
        {
            var logic = new DeveloperLogic(mockDevRepo.Object);
            var dev = new Developer { Id = 2, DevName = "Carter", Salary = 64000 };
            try
            {
                logic.Create(dev);
            }
            catch
            {

            }
            mockDevRepo.Verify(g => g.Create(dev), Times.Never);
        }
        [Test]
        public void DeveloperCreateDevNameIsNull()
        {
            var logic = new DeveloperLogic(mockDevRepo.Object);
            var dev = new Developer { Id = 2, Company = new DevStudio(), Salary = 64000 };
            try
            {
                logic.Create(dev);
            }
            catch
            {

            }
            mockDevRepo.Verify(g => g.Create(dev), Times.Never);

        }
        [Test]
        public void DeveloperCreateDevNameIsEmpty()
        {
            var logic = new DeveloperLogic(mockDevRepo.Object);
            var dev = new Developer { Id = 2, DevName = "", Company = new DevStudio(), Salary = 64000 };
            try
            {
                logic.Create(dev);
            }
            catch
            {

            }
            mockDevRepo.Verify(g => g.Create(dev), Times.Never);
        }

        #endregion

        #endregion

        #region DevStudiLogic Tests

        #region Create tests

        [Test]
        public void DevStudioCreateRightInput()
        {
            var logic = new DevStudioLogic(mockStudioRepo.Object);
            var studio = new DevStudio
            { Id = 1, StudioName = "CD Pojekt RED", Games = new List<Game>(), Employees = new List<Developer>() };
            logic.Create(studio);
            mockStudioRepo.Verify(g => g.Create(studio), Times.Once);
        }
        [Test]
        public void DevStudioCreateGamesIsNull()
        {
            var logic = new DevStudioLogic(mockStudioRepo.Object);
            var studio = new DevStudio
            { Id = 1, StudioName = "CD Pojekt RED", Employees = new List<Developer>() };
            try
            {
                logic.Create(studio);
            }
            catch
            {

            }
            mockStudioRepo.Verify(g => g.Create(studio), Times.Never);
        }
        [Test]
        public void DevStudioCreateEmployeesIsNull()
        {
            var logic = new DevStudioLogic(mockStudioRepo.Object);
            var studio = new DevStudio
            { Id = 1, StudioName = "CD Pojekt RED", Games = new List<Game>() };
            try
            {
                logic.Create(studio);
            }
            catch
            {

            }
            mockStudioRepo.Verify(g => g.Create(studio), Times.Never);
        }
        [Test]
        public void DevStudioCreateStudioNameIsNull()
        {
            var logic = new DevStudioLogic(mockStudioRepo.Object);
            var studio = new DevStudio
            { Id = 1, Games = new List<Game>(), Employees = new List<Developer>() };
            try
            {
                logic.Create(studio);
            }
            catch
            {

            }
            mockStudioRepo.Verify(g => g.Create(studio), Times.Never);
        }
        [Test]
        public void DevStudioCreateStudioNameIs0Lenght()
        {
            var logic = new DevStudioLogic(mockStudioRepo.Object);
            var studio = new DevStudio
            { Id = 1, StudioName = "", Games = new List<Game>(), Employees = new List<Developer>() };
            try
            {
                logic.Create(studio);
            }
            catch
            {

            }
            mockStudioRepo.Verify(g => g.Create(studio), Times.Never);
        }

        #endregion

        #endregion



    }
}