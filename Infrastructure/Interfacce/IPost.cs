using Domain;

namespace Infrastructure.Interfacce;

public interface IPost
{
      void Add(Post post);
    List<Post> GetAll();
    Post GetById(int id);
    void Update(Post post);
    void Delete(int id);
}
