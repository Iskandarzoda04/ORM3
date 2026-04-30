using Domain;

namespace Infrastructure.Interfacce;

public interface IComment
{
      void Add(Comment comment);
    List<Comment> GetAll();
    Comment GetById(int id);
    void Update(Comment comment);
    void Delete(int id);
}
