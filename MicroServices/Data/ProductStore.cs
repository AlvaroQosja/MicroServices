using ProductServices.Model;

namespace ProductServices.Data
{
    public class ProductStore
    {
        private readonly List<Product> _catalog =
        [
            new Product{Id = 1, Name = "Laptop", Price = 1000.00m },
            new Product{Id = 2, Name = "Mouse", Price = 40.00m},
            new Product{Id = 3, Name= "Keyboard", Price = 100.00m},
            new Product{Id = 4, Name = "Phone", Price = 500.00m },
            new Product{Id = 5, Name = "Monitor", Price = 140.00m},
            new Product{Id = 6, Name= "Charger", Price = 20.00m}
        ];

        public List<Product> GetAll()
        {
            return _catalog;
        }

        public Product? GetById(int id)
        {
            return _catalog.FirstOrDefault(p => p.Id == id);
        }
    }
}
