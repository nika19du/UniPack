using MinimalApp.Models;
using MinimalApp.Repository;

namespace MinimalApp.Services
{
    public class CoffeeService : ICoffeeService
    {
        public CoffeeModel Create(CoffeeModel coffee)
        {
            coffee.Id = CoffeeRepository.Coffes.Count + 1;
            CoffeeRepository.Coffes.Add(coffee);
            return coffee;
        } 
        public CoffeeModel? Get(int id)
        {
            var coffee = CoffeeRepository.Coffes.FirstOrDefault(x => x.Id == id);
            if (coffee == null) return null;

            return coffee;
        }

        public List<CoffeeModel> List()
        {
            var coffees = CoffeeRepository.Coffes;
            return coffees;
        }

        public CoffeeModel? Update(CoffeeModel newCoffee)
        {
            var oldCoffee = CoffeeRepository.Coffes.FirstOrDefault(x => x.Id == newCoffee.Id);

            if (oldCoffee is null) return null;

            oldCoffee.Name = newCoffee.Name;
            oldCoffee.Description = newCoffee.Description;

            return newCoffee;
        }
        
        public bool Delete(int id)
        {
            var oldCoffee = CoffeeRepository.Coffes.FirstOrDefault(x => x.Id == id);

            if (oldCoffee is null) return false;

            CoffeeRepository.Coffes.Remove(oldCoffee);

            return true;
        }
    }
}
