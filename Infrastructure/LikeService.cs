using Npgsql;
using Dapper;
using Domain;
using Infrastructure.Interfacce;
using Infrastructure.Date;


namespace Infrastructure;



public class LikeService : ILikes
{
        private readonly DataContext context = new();
    private string sql;


    public void Add(Like like)
    {
       using var con = context.GetConnection();
    con.Open();

    string sql = @"insert into likes
                   (user_id, post_id, like_date)
                   values
                   (@UserId, @PostId, @LikeDate)";

    con.Execute(sql, like);
    }

    public void Delete(int id)
    {
       using  var con = context.GetConnection();
       con.Open();

       var sql = "delete  from Likes where id=@Id";

         con.Execute(sql, new{id});

    }

    public List<Like> GetAll()
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "select from Users";

        var lk = con.Query<Like>(sql).ToList();

    return lk;
    }

    public Like GetById(int id)
    {
       using var con = context.GetConnection();
        con.Open();

        var sql ="select from Likes where id=@id";

         var lk = con.QueryFirstOrDefault<Like>(sql, new { id });

    return lk;
    }

    public void Update(Like like)
    {
        using var con = context.GetConnection();
    con.Open();

    string sql = @"update likes
                   set user_id = @UserId,
                       post_id = @PostId,
                       like_date = @LikeDate
                   where like_id = @LikeId";

    int result = con.Execute(sql, like);

    if(result > 0)
        Console.WriteLine("Like updated successfully");
    else
        Console.WriteLine("Like not found");
    }

}

