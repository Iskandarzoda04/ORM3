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

        string sql = @"
        insert into Comments
        (user_id, post_id, content, creation_date)
        values
        (@UserId, @PostId, @Content, @CreationDate)";

        con.Execute(sql, comment);
    }

    public void Delete(int id)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "delete from Comments where id = @Id";

        con.Execute(sql, new { Id = id });
    }

    public List<Comment> GetAll()
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "select * from Comments";

        var comments = con.Query<Comment>(sql).ToList();

        return comments;
    }

    public Comment GetById(int id)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "select * from Comments where id = @Id";

        var comment = con.QueryFirstOrDefault<Comment>(sql, new { Id = id });
        return comment;
    }

    public void Update(Comment comment)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = @"
        update Comments
        set Userid = @UserId,
            Postid = @PostId,
            Content = @Content,
            CreationDate = @CreationDate
        where id = @CommentId";

        con.Execute(sql, comment);
    }
}