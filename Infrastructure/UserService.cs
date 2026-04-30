using Npgsql;
using Dapper;
using Domain;
using Infrastructure.Interfacce;
using Infrastructure.Date;

namespace Infrastructure;         

public class UserService : IUserService
{
      private readonly DataContext context = new();

    public void Add(User user)
    {
        using var conn = context.GetConnection();
        conn.Open();

    string sql = @" insert into users(fullname, email, phone) values(@FullName, @Email, @Phone)";

    conn.Execute(sql, user);
        
    }

    public void Delete(int id)
    {
        using var con = context.GetConnection();
        con.Open();

        var sql = "delete  from Usrs where id=@Id ";

        con.Execute(sql, new{id});

    }

    public List<User> GetAll()
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "select from Users";

        var us = con.Query<User>(sql).ToList();

    return us;
       
    }

    public User GetById(int id)
    {
        using var con = context.GetConnection();
        con.Open();

        var sql ="select from Users where id=@id";

         var us = con.QueryFirstOrDefault<User>(sql, new { id });

    return us;

    }

    public void Update(User user)
    {
        using var con = context.GetConnection();
        con.Open();
   
         var sql = @"update users
                set username = @username,
                    email = @email,
                    full_name = @fullname,
                    registration_date = @date
                WHERE user_id = @id";

       var result = con.Execute(sql, user);

          if(result > 0)
        Console.WriteLine("User updated successfully");
    else
        Console.WriteLine("User not found");
    }

}
