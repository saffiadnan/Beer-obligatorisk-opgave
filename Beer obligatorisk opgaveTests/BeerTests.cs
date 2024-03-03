using Microsoft.VisualStudio.TestTools.UnitTesting;
using Beer_obligatorisk_opgave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer_obligatorisk_opgave.Tests
{
    [TestClass()]
    public class BeerTests
    {
        [TestMethod()]
        public void ValidateNameTest()
        {
            Beer beer = new()
            {
                Id = 1,
                Name = "Tuborg",
                Abv = 55
            };
            beer.ValidateName();

            Beer beerNullName = new()
            {
                Id = 1,
                Name = "",
                Abv = 55
            };

            Assert.ThrowsException<ArgumentException>(() => beerNullName.ValidateName());
        }

        [TestMethod()]
        public void ToStringTest()
        {

        }

        [TestMethod()]

        public void ValidateAbvTest()
        {
            Beer BeerAbvlav = new()
            {
                Id = 1,
                Name = "Tuborg",
                Abv = -1
            };
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => BeerAbvlav.ValidateAbv());

            Beer beerIndenrækkevide = new()
            {
                Id = 1,
                Name = "Tuborg",
                Abv = 19
            };
            beerIndenrækkevide.ValidateAbv();

        }

    }

}