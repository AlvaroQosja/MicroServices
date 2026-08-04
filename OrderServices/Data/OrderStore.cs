using OrderServices.Model;

namespace OrderServices.Data
{
    public class OrderStore
    {
        private readonly List<Order> Orders = new();
        private int _nextId = 1;

        public IReadOnlyList<Order> GetAll()
        {
            return Orders;
        }

        public Order? GetById(int id)
        {
            return Orders.FirstOrDefault(o => o.Id == id);
        }

        public Order Add(int productId, int quantity)
        {
            var order = new Order
            {
                Id = _nextId++,
                ProductId = productId,
                Quantity = quantity
            };

            Orders.Add(order);

            return order;
        }
    }
}