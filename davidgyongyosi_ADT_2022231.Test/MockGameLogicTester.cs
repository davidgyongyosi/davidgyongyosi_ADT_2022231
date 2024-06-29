using System;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using davidgyongyosi_ADT_2022231.Logic;
using davidgyongyosi_ADT_2022231.Models;
using davidgyongyosi_ADT_2022231.Repository;
using System.Linq;

namespace davidgyongyosi_ADT_2022231.Test
{
    [TestFixture]
    public class MockGameLogicTester
    {
        GameLogic logic;
        Mock<IGenericRepository<Game>> mockGameRepo;

        [SetUp]
        public void Init()
        {
            mockGameRepo = new Mock<IGenericRepository<Game>>();
            mockGameRepo.Setup(m => m.ReadAll()).Returns(new List<Game>()
            {
                new Game(1, "Jatek1", "2019", 9.99, 1 ),
                new Game(2, "Jatek2", "2009", 14.99, 4 ),
                new Game(3, "Jatek3", "2018", 4.99, 7 ),
                new Game(4, "Jatek4", "2015", 0, 12 ),
                new Game(5, "Jatek5", "2020", 39.99, 2 ),
                new Game(6, "Jatek6", "2021", 49.99, 4 ),
                new Game(7, "Jatek7", "2002", 29.99, 6 ),
                new Game(8, "Jatek8", "2000", 19.99, 2 )
            }.AsQueryable());
            logic = new GameLogic(mockGameRepo.Object);
        }

        [Test]
        public void AvgPricePerYearTest()
        {
            double? avg = logic.GetAveragePricePerYear("2009");
            Assert.That(avg, Is.EqualTo(14.99));
        }

        [Test]
        public void YearStatisticsTest()
        {
            
            var actual = logic.StatsPerYear().ToList();
            var expected = new List<YearInfo>()
            {
                new YearInfo() { Year = "2019", AvgPrice = 9.99, GameNumber = 1 },
                new YearInfo() { Year = "2009", AvgPrice = 14.99, GameNumber = 1 },
                new YearInfo() { Year = "2018", AvgPrice = 4.99, GameNumber = 1 },
                new YearInfo() { Year = "2015", AvgPrice = 0, GameNumber = 1 },
                new YearInfo() { Year = "2020", AvgPrice = 39.99, GameNumber = 1 },
                new YearInfo() { Year = "2021", AvgPrice = 49.99, GameNumber = 1 },
                new YearInfo() { Year = "2002", AvgPrice = 29.99, GameNumber = 1 },
                new YearInfo() { Year = "2000", AvgPrice = 19.99, GameNumber = 1 }
            };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CreateGameTestWithCorrectTitle()
        {
            var game = new Game() { GameName = "Jatek1" };

            //ACT
            logic.Create(game);

            //ASSERT
            mockGameRepo.Verify(r => r.Create(game), Times.Once);
        }

        [Test]
        public void CreateGameTestWithInCorrectTitle()
        {
            var game = new Game() { GameName = "" };
            try
            {
                //ACT
                logic.Create(game);
            }
            catch
            {

            }

            //ASSERT
            mockGameRepo.Verify(r => r.Create(game), Times.Never);
        }
    }
}

