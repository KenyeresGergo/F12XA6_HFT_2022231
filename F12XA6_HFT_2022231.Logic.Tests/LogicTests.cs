using System;
using System.Collections.Generic;
using System.Linq;
using Castle.DynamicProxy.Internal;
using F12XA6_HFT_2022231.Logic.ModelLogics;
using F12XA6_HFT_2022231.Models;
using F12XA6_HFT_2022231.Repository.Interfaces;
using Moq;
using NUnit.Framework;

namespace F12XA6_HFT_2022231.Logic.Tests
{
    public class Tests
    {
        private GameLogic gameLogic;
        private DeveloperLogic devLogic;
        private DevStudioLogic studioLogic;
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
        public void GameCreateDevelopersIsNull()
        {
            var logic = new GameLogic(mockGameRepo.Object);
            mockGameRepo.Verify(g=>g.Create(new Game { Id = 1, GameTitle = "Cyberpunk2077",Price = 60, Rating = 2,PublisherStudio = new DevStudio()}), Times.Never);
        }  
        [Test]
        public void GameCreaGameTitleIsNull()
        {
            var logic = new GameLogic(mockGameRepo.Object);
            mockGameRepo.Verify(g=>g.Create(new Game { Id = 1, GameTitle = "",Developers = new List<Developer>(),Price = 60, Rating = 2, PublisherStudio = new DevStudio() }), Times.Never);
        } 
        [Test]
        public void GameCreatePublisherStudioIsNull()
        {
            var logic = new GameLogic(mockGameRepo.Object);
            mockGameRepo.Verify(g=>g.Create(new Game { Id = 1, GameTitle = "Cyberpunk2077", Developers = new List<Developer>(),Price = 60, Rating = 2 }), Times.Never);
        } 
        [Test]
        public void GameCreateObjectIsNull()
        {
            var logic = new GameLogic(mockGameRepo.Object);
            mockGameRepo.Verify(g=>g.Create(null), Times.Never);
        }
        #endregion
        #endregion



    }
}