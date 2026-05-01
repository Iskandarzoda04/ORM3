using Domain;

namespace Infrastructure.Interfacce;
public interface ILikes
{
    
      Task Add(Like like);
   Task<List<Like>> GetAll();
    Task<Like> GetById(int id);
    Task Update(Like like);
    Task Delete(int id);
}
