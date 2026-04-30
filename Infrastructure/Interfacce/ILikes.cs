using Domain;

namespace Infrastructure.Interfacce;
public interface ILikes
{
    
      void Add(Like like);
    List<Like> GetAll();
    Like GetById(int id);
    void Update(Like like);
    void Delete(int id);
}
