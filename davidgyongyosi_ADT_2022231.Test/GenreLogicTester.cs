using System;
using NUnit.Framework;
using System.Collections.Generic;
using davidgyongyosi_ADT_2022231.Logic;
using davidgyongyosi_ADT_2022231.Logic.Classes;
using Moq;
using davidgyongyosi_ADT_2022231.Repository;
using davidgyongyosi_ADT_2022231.Models;
using System.Linq;

namespace davidgyongyosi_ADT_2022231.Test
{
    [TestFixture]
    public class GenreLogicTester
    {
        GenreLogic logic;
        Mock<IGenericRepository<Genre>> mockGenreRepo;

        [SetUp]
        public void Init()
        {
            mockGenreRepo = new Mock<IGenericRepository<Genre>>();
            mockGenreRepo.Setup(m => m.ReadAll()).Returns(new List<Genre>()
            {
                new Genre(1,"Test1"),
                new Genre(2,"Test1"),
                new Genre(3,"Test1"),
                new Genre(4,"Test1")
            }.AsQueryable());
            logic = new GenreLogic(mockGenreRepo.Object);
        }

        [Test]
        public void GenreCount()
        {
            int? count = logic.ReadAll().Count();
            Assert.That(count, Is.EqualTo(4));
        }

        [Test]
        public void CreateGenreTestWithCorrectTitle()
        {
            var genre = new Genre() { GenreName = "TableTop Simulator" };

            //ACT
            logic.Create(genre);

            //ASSERT
            mockGenreRepo.Verify(r => r.Create(genre), Times.Once);
        }

        [Test]
        public void CreateGenreTestWithInCorrectTitle()
        {
            var genre = new Genre() { GenreName = "" };
            try
            {
                //ACT
                logic.Create(genre);
            }
            catch
            {

            }

            //ASSERT
            mockGenreRepo.Verify(r => r.Create(genre), Times.Never);
        }
    }
}

