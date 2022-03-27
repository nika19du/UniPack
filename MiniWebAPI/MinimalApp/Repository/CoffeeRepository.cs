using MinimalApp.Models;

namespace MinimalApp.Repository
{
    public static class CoffeeRepository
    {
        public static List<CoffeeModel> Coffes = new()
        {
            new() { Id=1,Name="Affogato",Description="Espresso poured on a vanilla ice cream"},
            new() { Id=2,Name="Americano",Description="Espresso with added hot water"},
            new() { Id=3,Name="Latte",Description="A tall,mild 'milk coffe'."},
            new() { Id = 4, Name = "Mocha", Description = "A caffe latte with chcolate" },
            new() { Id =5, Name = "Cappuccino", Description = "A caffe drink consisting of expresso and milk from mixture" }
        };
    }
}
