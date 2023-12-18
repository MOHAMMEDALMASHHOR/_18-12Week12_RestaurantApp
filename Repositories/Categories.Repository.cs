using Entities;
using Repositories.interfaces;

namespace Repositories;

public class CategoriesRepository:IRepository<Categories>
{
    private List<Categories> items{get;set;}

    public CategoriesRepository(List<Categories> items)
    {
        this.items = items;
    }

    public void Delete(int id)
    {
        items.Remove(GetOne(id));
    }

    public Categories GetOne(int id)
    {
        return items.Find(o=>o.Id.Equals(id));
    }

    public void Post(Categories item)
    {
        items.Add(item);
    }
}
