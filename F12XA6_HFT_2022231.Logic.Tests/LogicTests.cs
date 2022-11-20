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
            #region Demo data for Dev Studio Lists
            var dg1 = new Game { Id = 1, GameTitle = "Cyberpunk2077", Price = 60, Rating = 2 };
            var dg2 = new Game { Id = 2, GameTitle = "Grand Theft Auto V", Price = 50, Rating = 7 };
            var dg3 = new Game { Id = 3, GameTitle = "Grand Theft Auto IV", Price = 30, Rating = 6 };
            var dg4 = new Game { Id = 4, GameTitle = "The Witcher 3: Wild hunt", Price = 55, Rating = 4 };

            var de1 = new Developer { Id = 2, DevName = "Carter", Salary = 64000 };
            var de2 = new Developer { Id = 4, DevName = "Mike", Salary = 82000 };
            var de3 = new Developer { Id = 6, DevName = "Noah", Salary = 120000 };
            #endregion


            var a = new DevStudio { Id = 1, StudioName = "CD Pojekt RED", Games = new List<Game> { dg1, dg4 }, Employees = new List<Developer> { de1, de2 } };
            var b = new DevStudio { Id = 2, StudioName = "Rockstar Games", Games = new List<Game> { dg2, dg3 }, Employees = new List<Developer> { de3 } };
            var studios = new List<DevStudio> { a, b };

            var games = new List<Game>
            {
               new Game { Id = 1, GameTitle = "Cyberpunk2077", Price = 60, PublisherStudio = a, Rating = 2 },
               new Game { Id = 2, GameTitle = "Grand Theft Auto V", Price = 50, PublisherStudio = b, Rating = 7 },
               new Game { Id = 3, GameTitle = "Grand Theft Auto IV", Price = 30, PublisherStudio = b, Rating = 6 },
               new Game { Id = 4, GameTitle = "The Witcher 3: Wild hunt", Price = 55, PublisherStudio = a, Rating = 4 }
            };

            var devs = new List<Developer>
            {
                new Developer{Id = 2,DevName = "Carter",Company = a,Salary = 64000},
                new Developer{Id = 4,DevName = "Mike",Company = a,Salary = 82000},
                new Developer{Id = 6,DevName = "Noah",Company = b,Salary = 120000},
            };

            mockStudioRepo = new Mock<IRepository<DevStudio>>();
            mockStudioRepo.Setup(m => m.ReadAll()).Returns(studios);

            mockGameRepo = new Mock<IRepository<Game>>();
            mockGameRepo.Setup(m => m.ReadAll()).Returns(games);

            mockDevRepo = new Mock<IRepository<Developer>>();
            mockDevRepo.Setup(m => m.ReadAll()).Returns(devs);

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
    }
}