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
        (user_id, post_id, like_date)
        values
        (@UserId, @PostId, @LikeDate)";

        con.Execute(sql, like);
    }

    public void Delete(int id)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "delete from Likes where like_id = @Id";

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

        string sql = "select * from Likes where like_id = @Id";

        var like = con.QueryFirstOrDefault<Like>(sql, new { Id = id });
        return like;
    }

    public void Update(Like like)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = @"
        update Likes
        set user_id = @UserId,
            post_id = @PostId,
            like_date = @LikeDate
        where like_id = @LikeId";

        con.Execute(sql, like);
    }
}