using Domain;

namespace Infrastructure.Interfacce;

public interface IComment
{
      Task Add(Comment comment);
    Task<List<Comment>> GetAll();
    Task<Comment> GetById(int id);
    Task Update(Comment comment);
    Task Delete(int id);
}
