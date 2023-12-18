using Entities;
using Repositories.interfaces;
namespace Repositories;

public class UserRepository : IRepository<User>
{
    private List<User> users { get; set; }

    public UserRepository(List<User> users)
    {
        this.users = users;
    }

    public void Delete(int id)
    {
        users.Remove(GetOne(id));
    }

    public User GetOne(int id)
    {
       return users.Find(u=>u.Id.Equals(id));
    }

    public void Post(User item)
    {
        var pass = item.Password.Encoder(item.Salt);
        item.Password = pass;
        users.Add(item);
    }
    public User GetData(string email, string password){
        var user = users.Find(u=>u.Email.Equals(email));
        if (user is null)
        {
            return null;
        }
        if(user.Password==password.Encoder(user.Salt)){
            return user;
        }
        return null;
    }

}