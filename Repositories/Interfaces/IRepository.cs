namespace Repositories.interfaces;

public interface IRepository<T>{
    public T GetOne(int id);
    public void Post(T item);
    public void Delete(int id);
}