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
    public class BeersRepositoryTests
    {
        [TestMethod()]
        public void GetBeersTest()
        {
            // Arrange
            var repository = new BeersRepository();

            // Act
            var result = repository.GetBeers();

            // Assert
            Assert.AreEqual(5, result.Count); // Vi tager udgangspunkt i der  er 5 øl, da jeg har oprettet 5 øl. 
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            // Arrange
            var repository = new BeersRepository();
            var forventetBeerId = 1;

            // Act
            var result = repository.GetById(forventetBeerId);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(forventetBeerId, result.Id);
        }

        [TestMethod()]
        public void TilføjBeerTest()
        {
            // Arrange
            var repository = new BeersRepository();
            var TilføjNyBeer = new Beer { Name = "Ny Test Beer", Abv = 8.2 };

            // Act
            var result = repository.TilføjBeer(TilføjNyBeer);
            var alleBeers = repository.GetBeers();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(6, alleBeers.Count); // tager udgangspunkt i at der er 5 øl
            Assert.IsTrue(alleBeers.Any(b => b.Name == "Ny Test Beer"));
        }

        [TestMethod()]
        public void SletteBeerTest()
        {
            // Arrange
            var repository = new BeersRepository();
            var beerIdSlette = 1;

            // Act
            var result = repository.SletteBeer(beerIdSlette);
            var alleBeers = repository.GetBeers();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, alleBeers.Count); // tager udgangspunkt i at der er 5 øl
            Assert.IsFalse(alleBeers.Any(b => b.Id == beerIdSlette));
        }

        [TestMethod()]
        public void OpdatereBeersTest()
        {
            // Arrange
            var repository = new BeersRepository();
            var beerIdOpdatere = 1;
            var OpdateretData = new Beer { Name = "Opdateret Name", Abv = 9.1 };

            // Act
            var result = repository.OpdatereBeers(beerIdOpdatere, OpdateretData);
            var OpdateretBeer = repository.GetById(beerIdOpdatere);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Opdateret Name", OpdateretBeer.Name);
            Assert.AreEqual(6,5, OpdateretBeer.Abv);
        }
    }
}