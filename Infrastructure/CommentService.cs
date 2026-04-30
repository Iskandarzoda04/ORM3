using Npgsql;
using Dapper;
using Domain;
using Infrastructure.Interfacce;
using Infrastructure.Date;

namespace Infrastructure;


public class CommentService : IComment
{
       private readonly DataContext context = new();
    public void Add(Comment comment)
    {
        using var con = context.GetConnection();
    con.Open();

    string sql = @"insert into comments
                   (user_id, post_id, content, creation_date)
                   values
                   (@UserId, @PostId, @Content, @CreationDate)";

     con.Execute(sql, comment);
    }

    public void Delete(int id)
    {
        using var con = context.GetConnection();
        con.Open();

        var sql = "delete  from Comments where id=@Id ";

        con.Execute(sql, new{id});
    }

    public List<Comment> GetAll()
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "select from Comments";

        var cmt = con.Query<Comment>(sql).ToList();

    return cmt;
    }

    public Comment GetById(int id)
    {
       using var con = context.GetConnection();
        con.Open();

        var sql ="select from Comments where id=@id";

         var cmt = con.QueryFirstOrDefault<Comment>(sql, new { id });

    return cmt;
    }

    public void Update(Comment comment)
    {
        using var con = context.GetConnection();
    con.Open();

    string sql = @"update comments
                   set user_id = @UserId,
                       post_id = @PostId,
                       content = @Content,
                       creation_date = @CreationDate
                   where comment_id = @CommentId";

    int result = con.Execute(sql, comment);

    if (result > 0)
        Console.WriteLine("Comment updated successfully");
    else
        Console.WriteLine("Comment not found");
    }

}
