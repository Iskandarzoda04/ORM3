using Dapper;
using Domain;
using Infrastructure.Date;
using Infrastructure.Interfacce;

namespace Infrastructure;

public class PostService : IPost
{
    private readonly DataContext context = new();

    public void Add(Post post)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = @"insert into Posts
        (userId, content, creationDate, likesCount)
        values
        (@UserId, @Content, @CreationDate, @LikesCount)";

        con.Execute(sql, post);
    }

    public void Delete(int id)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "delete from Posts where postId = @Id";

        con.Execute(sql, new { Id = id });
    }

    public List<Post> GetAll()
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "select * from Posts";

        var posts = con.Query<Post>(sql).ToList();
        return posts;
    }

    public Post GetById(int id)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "select * from Posts where postId = @Id";

        var post= con.QueryFirstOrDefault<Post>(sql, new { Id = id });

        return post;
    }

    public void Update(Post post)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = @" update Posts
        set userId = @UserId,
            content = @Content,
            creationDate = @CreationDate,
            likesCount = @LikesCount
        where postId = @PostId";

        con.Execute(sql, post);

        
    }
}