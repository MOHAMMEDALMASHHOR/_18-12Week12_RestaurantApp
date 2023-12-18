using Entities;
using Repositories.interfaces;

namespace Repositories;

public class ItemsRepository:IRepository<Items>
{
    private List<Items> items{get;set;}

    public ItemsRepository(List<Items> items)
    {
        this.items = items;
    }

    public void Delete(int id)
    {
        items.Remove(GetOne(id));
    }

    public Items GetOne(int id)
    {
        return items.Find(o=>o.Id.Equals(id));
    }

    public void Post(Items item)
    {
        items.Add(item);
    }
    public List<Items> GetAll(){
        return items;
    }
}
