using Dapper;
using Domain;
using Infrastructure.Interfacce;
using Infrastructure.Date;

namespace Infrastructure;

public class LikeService : ILikes
{
    private readonly DataContext context = new();

    public void Add(Like like)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = @"
        insert into Likes
        (Userid, Postid, likedate)
        values
        (@UserId, @PostId, @LikeDate)";

        con.Execute(sql, like);
    }

    public void Delete(int id)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "delete from Likes where id = @Id";

        con.Execute(sql, new { Id = id });
    }

    public List<Like> GetAll()
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "select * from Likes";

        var likes = con.Query<Like>(sql).ToList();
        return likes;
    }

    public Like GetById(int id)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "select * from Likes where id = @Id";

        var like = con.QueryFirstOrDefault<Like>(sql, new { Id = id });
        return like;
    }

    public void Update(Like like)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = @"
        update Likes
        set userid = @UserId,
            postid = @PostId,
            likedate = @LikeDate
        where id = @LikeId";

        con.Execute(sql, like);
    }
}