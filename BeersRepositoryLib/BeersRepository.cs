using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeersRepositoryLib
{
    public class BeersRepository
    {
        public int nextId = 5;
        private List<Beer> _beers = new()
        {
            new Beer() { Id = 1, Name = "Budweiser",Abv = 5},
            new Beer() { Id = 2, Name = "Heineken",Abv = 6},
            new Beer() { Id = 3, Name = "Corona",Abv = 7},
            new Beer() { Id = 4, Name = "Guinness",Abv = 8},

        };

        public List<Beer> Get()
        {
            return new List<Beer>(_beers);
        }

        public List<Beer> Get(int abvGreateThen = 0, string? sortBy = null)
        {
            List<Beer> beers = new List<Beer>(_beers);
            if (abvGreateThen != 0)
            {
                return beers.FindAll(b => b.Abv > abvGreateThen);
            }
            switch (sortBy)
            {
                case "Name":
                    beers.Sort((b1, b2) => b1.Name.CompareTo(b2.Name));
                    break;
                case "Abv":
                    beers.Sort((b1, b2) => b1.Abv - b2.Abv);
                    break;
            }
            return beers;

        }


        public Beer? GetById(int id)
        { 
           return _beers.Find(b => b.Id == id); 
        }
        public Beer Add(Beer beer)
        {
            beer.Id = nextId++;
            _beers.Add(beer);
            return beer;

        }
        public Beer? Delete(int id)
        {
            Beer? beer = _beers.Find(b => b.Id == id);
            if (beer != null)
            {
                _beers.Remove(beer);
            }
            return beer;

        }

        public Beer? Update(int id, Beer beer)
        {
            Beer? beerToUpdate = _beers.Find(b => b.Id == id);
            if (beerToUpdate != null)
            {
                beerToUpdate.Name = beer.Name;
                beerToUpdate.Abv = beer.Abv;
            }
            return beerToUpdate;
        }
    }
}
