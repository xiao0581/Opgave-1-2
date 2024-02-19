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
    public class BeerTests
    {
        [TestMethod()]
        public void validateNameTest()
        {
            Beer beer = new Beer()
            {
                Id = 1,
                Name = "Budweiser",
                Abv = 5
            };
            beer.validateName();

            Beer beer2 = new Beer()
            {
                Id = 1,
                Name = "Bu",
                Abv = 5
            };
            Assert.ThrowsException<ArgumentException>(() => beer2.validateName());

            Beer beer3 = new Beer()
            {
                Id = 1,
                Name = null
            };
            Assert.ThrowsException<ArgumentNullException>(() => beer3.validateName());

        }

        [TestMethod()]
        public void validateAbvTest()
        {
            Beer beer = new Beer()
            {
                Id = 1,
                Name = "Budweiser",
                Abv = 5
            };
            beer.validateAbv();
            Beer beer2 = new Beer()
            {
                Id = 1,
                Name = "Budweiser",
                Abv = 0
            };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => beer2.validateAbv());
            Beer beer3 = new Beer()
            {
                Id = 1,
                Name = "Budweiser",
                Abv = 68
            };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => beer3.validateAbv());
        }

        [TestMethod()]
        public void ToStringTest()
        {
            Beer beer = new Beer()
            {
                Id = 1,
                Name = "Budweiser",
                Abv = 5
            };
            Assert.AreEqual("Id: 1, Name: Budweiser, Abv: 5", beer.ToString());
        }
    }
}