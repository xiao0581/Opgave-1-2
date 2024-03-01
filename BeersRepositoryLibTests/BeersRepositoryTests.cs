using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeersRepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeersRepositoryLib.Tests
{
    [TestClass()]
    public class BeersRepositoryTests
    {
        [TestMethod()]
        public void GetAllTest()
        {
            //arrange
            BeersRepository beersRepository = new BeersRepository();

            //act
            List<Beer> beers = beersRepository.Get();

            //assert
            Assert.AreEqual(5, beers.Count);
        }

        [TestMethod()]
        public void GetTest()
        {
            //testing the get method with the abvGreateThen
            BeersRepository beersRepository = new BeersRepository();
            IEnumerable<Beer> beer = beersRepository.Get(abvGreateThen: 5);
            Assert.IsNotNull(beer);
            Assert.AreEqual(6, beer.First().Abv);

            //testing the get method with the sortByName
            IEnumerable<Beer> beer2 = beersRepository.Get(sortBy: "Name");
            Assert.IsNotNull(beer2);
            Assert.AreEqual("Budweiser", beer2.First().Name);

            //testing the get method with the sortByAbv
            IEnumerable<Beer> beer3 = beersRepository.Get(sortBy: "Abv");
            Assert.IsNotNull(beer3);
            Assert.AreEqual(5, beer3.First().Abv);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            BeersRepository beersRepository = new BeersRepository();
            Beer? beer = beersRepository.GetById(1);
            Assert.IsNotNull(beer);
            Assert.AreEqual(1, beer.Id);

        }

        [TestMethod()]
        public void AddTest()
        {
            BeersRepository beersRepository = new BeersRepository();
            Beer beer = new Beer() { Name = "Stella", Abv = 5 };
            beersRepository.Add(beer);
            List<Beer> beers = beersRepository.Get();
            Assert.AreEqual(6, beers.Count);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            BeersRepository beersRepository = new BeersRepository();
            beersRepository.Delete(1);
            Assert.IsNull(beersRepository.GetById(1));

        }

        [TestMethod()]
        public void UpdateTest()
        {
            BeersRepository beersRepository = new BeersRepository();
            Beer beer = new Beer() { Id = 1, Name = "Budweiser", Abv = 5 };
            beersRepository.Update(1, beer);
            Assert.AreEqual("Budweiser", beersRepository.GetById(1).Name);
        }
    }
}