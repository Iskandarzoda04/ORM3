using Dapper;
using Domain;
using Infrastructure.Date;
using Infrastructure.Interfacce;

namespace Infrastructure;

public class PostService : IPost
{
    private readonly DataContext context = new();

    public async Task Add(Post post)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = @"insert into Posts
        (userId, content, creationDate, likesCount)
        values
        (@UserId, @Content, @CreationDate, @LikesCount)";

       await con.ExecuteAsync(sql, post);
    }

    public async Task Delete(int id)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "delete from Posts where id = @Id";

        await con.ExecuteAsync(sql, new { Id = id });
    }

    public  async Task<List<Post>> GetAll()
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "select * from Posts";

        var posts = con.Query<Post>(sql).ToList();
        return posts;
    }

    public  async Task<Post> GetById(int id)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "select * from Posts where id = @Id";

        var post= con.QueryFirstOrDefault<Post>(sql, new { Id = id });

        return post;
    }

    public async Task Update(Post post)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = @" update Posts
        set userId = @UserId,
            content = @Content,
            creationDate = @CreationDate,
            likesCount = @LikesCount
        where id = @PostId";

        await con.ExecuteAsync(sql, post);

        
    }
}