using Npgsql;
using Dapper;
using Domain;
using Infrastructure.Interfacce;
using Infrastructure.Date;

namespace Infrastructure;


public class PostService : IPost
{
     private readonly DataContext context = new();
    public void Add(Post post)
    {
          using var con = context.GetConnection();
    con.Open();

    string sql = @"insert into posts
                   (userid, content, creationdate, likescount)
                   values
                   (@UserId, @Content, @CreationDate, @LikesCount)";

     con.Execute(sql, post);
    }

    public void Delete(int id)
    {
         using var con = context.GetConnection();
        con.Open();

        var sql = "delete  from Posts where id=@Id ";

        con.Execute(sql, new{id});
    }

    public List<Post> GetAll()
    {
         using var con = context.GetConnection();
        con.Open();

        string sql = "select from Posts";

        var pst = con.Query<Post>(sql).ToList();

    return pst;
    }

    public Post GetById(int id)
    {
       using var con = context.GetConnection();
        con.Open();

        var sql ="select from Users where id=@id";

         var pst = con.QueryFirstOrDefault<Post>(sql, new { id });

    return pst;
    }

    public void Update(Post post)
    {
       using var con = context.GetConnection();
       con.Open();

 var  sql = @"update posts
                   set userid = @UserId,
                       content = @Content,
                       creationdate = @CreationDate,
                       likescount = @LikesCount
                   where postid = @PostId";

    int rst = con.Execute(sql, post);

    if (rst > 0)
        Console.WriteLine("Post updated successfully");
    else
        Console.WriteLine("Post not found");
    }

}
