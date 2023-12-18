using Entities;
using Repositories.interfaces;

namespace Repositories;

public class OrderRepository:IRepository<Order>
{
    private List<Order> orders{get;set;}

    public OrderRepository(List<Order> orders)
    {
        this.orders = orders;
    }

    public void Delete(int id)
    {
        orders.Remove(GetOne(id));
    }

    public Order GetOne(int id)
    {
        return orders.Find(o=>o.Id.Equals(id));
    }

    public void Post(Order item)
    {
        orders.Add(item);
    }
}
