using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beer_obligatorisk_opgave
{
    public class BeersRepository
    {
        private int nextId = 6;
        private List<Beer> beers = new()
        {
            new Beer { Id = 1, Name = "Tuborg", Abv = 20},
            new Beer { Id = 2, Name = "Dansk Pilsner", Abv = 4.4},
            new Beer { Id = 3, Name = "Carlsberg", Abv = 49.4},
            new Beer { Id = 4, Name = "Corona", Abv = 2.9},
            new Beer { Id = 5, Name = "Breezer", Abv = 8.3}
        };
        public List<Beer> GetBeers(string? nameStart = null, string? sortby = null)
        {
            List<Beer> result = new List<Beer>(beers);

            if (nameStart != null)
            {
                result = result.FindAll(b => b.Name.StartsWith(nameStart));
            }
            if (sortby != null)
            {
                switch (sortby)
                {
                    case "name":
                        result.Sort((b1, b2) => b1.Name.CompareTo(b2.Name));
                        break;
                    case "abv":
                        result.Sort((b1, b2) => b1.Abv.CompareTo(b2.Abv));
                        break;
                }
            }
            return result;
        }
        public Beer? GetById(int id)
        {
            return beers.Find(beer => beer.Id == id);
        }
        public Beer TilføjBeer(Beer beer)
        {
            beer.Id = nextId++;
            beers.Add(beer);
            return beer;
        }
        public Beer? GetBeer(int id)
        {
            return beers.Find(b => b.Id == id);
        }
        public Beer? SletteBeer(int id)
        {
            Beer? beer = beers.Find(b => b.Id == id);
            if (beer != null)
            {
                beers.Remove(beer);
            }
            return beer;
        }
        public Beer? OpdatereBeers(int Id, Beer data)
        {
            Beer? beerToOpdatere = beers.Find(b => b.Id == Id);
            if (beerToOpdatere != null)
            {
                beerToOpdatere.Name = data.Name;
                beerToOpdatere.Abv = data.Abv;
            }
            return beerToOpdatere;
        }
    }
}
