
using Domain;
namespace Infrastructure.Interfacce;

public interface IUserService
{
     Task Add(User user);
    Task<List<User>> GetAll();
    Task<User> GetById(int id);
    Task Update(User user);
    Task Delete(int id);
}