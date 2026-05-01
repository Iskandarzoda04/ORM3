using Domain;

namespace Infrastructure.Interfacce;

public interface IPost
{
      Task Add(Post post);
    Task<List<Post>> GetAll();
    Task<Post> GetById(int id);
    Task Update(Post post);
    Task Delete(int id);
}
