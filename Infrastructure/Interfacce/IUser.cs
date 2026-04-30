
using Domain;
namespace Infrastructure.Interfacce;

public interface IUserService
{
    void Add(User user);
    List<User> GetAll();
    User GetById(int id);
    void Update(User user);
    void Delete(int id);
}