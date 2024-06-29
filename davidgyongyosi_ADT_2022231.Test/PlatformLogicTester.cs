using System;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using davidgyongyosi_ADT_2022231.Logic.Classes;
using davidgyongyosi_ADT_2022231.Models;
using davidgyongyosi_ADT_2022231.Repository;
using System.Linq;

namespace davidgyongyosi_ADT_2022231.Test
{
    [TestFixture]
    public class PlatformLogicTester
    {
        PlatformLogic logic;
        Mock<IGenericRepository<Platform>> mockPlatformRepo;

        [SetUp]
        public void Init()
        {
            mockPlatformRepo = new Mock<IGenericRepository<Platform>>();
            mockPlatformRepo.Setup(m => m.ReadAll()).Returns(new List<Platform>()
            {
                new Platform(1,"Test1"),
                new Platform(2,"Test1"),
                new Platform(3,"Test1"),
                new Platform(4,"Test1")
            }.AsQueryable());
            logic = new PlatformLogic(mockPlatformRepo.Object);
        }

        [Test]
        public void PlatformCount()
        {
            int? count = logic.ReadAll().Count();
            Assert.That(count, Is.EqualTo(4));
        }

        [Test]
        public void CreateGenreTestWithCorrectTitle()
        {
            var platform = new Platform() { PlatformName = "Nintendo" };

            //ACT
            logic.Create(platform);

            //ASSERT
            mockPlatformRepo.Verify(r => r.Create(platform), Times.Once);
        }

        [Test]
        public void CreateGenreTestWithInCorrectTitle()
        {
            var platform = new Platform() { PlatformName = "" };
            try
            {
                //ACT
                logic.Create(platform);
            }
            catch
            {

            }

            //ASSERT
            mockPlatformRepo.Verify(r => r.Create(platform), Times.Never);
        }
    }
}

