using Dapper;
using Domain;
using Infrastructure.Interfacce;
using Infrastructure.Date;

namespace Infrastructure;

public class LikeService : ILikes
{
    private readonly DataContext context = new();

    public  async Task Add(Like like)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = @"
        insert into Likes
        (Userid, Postid, likedate)
        values
        (@UserId, @PostId, @LikeDate)";

        await con.ExecuteAsync(sql, like);
    }

    public  async Task Delete(int id)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "delete from Likes where id = @Id";

        await con.ExecuteAsync(sql, new { Id = id });
    }

    public async Task<List<Like>> GetAll()
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "select * from Likes";

        var likes = con.Query<Like>(sql).ToList();
        return likes;
    }

    public async Task<Like> GetById(int id)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "select * from Likes where id = @Id";

        var like = con.QueryFirstOrDefault<Like>(sql, new { Id = id });
        return like;
    }

    public  async Task Update(Like like)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = @"
        update Likes
        set userid = @UserId,
            postid = @PostId,
            likedate = @LikeDate
        where id = @LikeId";

        await con.ExecuteAsync(sql, like);
    }

   
 

}