using Dapper;
using Domain;
using Infrastructure.Date;
using Infrastructure.Interfacce;

namespace Infrastructure;

public class UserService : IUserService
{
    private readonly DataContext context = new();

    public void Add(User user)
    {
        using var conn = context.GetConnection();
        conn.Open();

        string sql = @"
        insert into Users (username, email, full_name, registration_date)
        values (@Username, @Email, @FullName, @RegistrationDate)";

        conn.Execute(sql, user);
    }

    public void Delete(int id)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "delete from Users where user_id = @Id";

        con.Execute(sql, new { Id = id });
    }

    public List<User> GetAll()
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "select * from Users";

        var us= con.Query<User>(sql).ToList();
        return us;
    }

    public User GetById(int id)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "select * from Users where user_id = @Id";

        var us = con.QueryFirstOrDefault<User>(sql, new { Id = id });
        return us;
    }

    public void Update(User user)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = @"
        update Users
        set username = @Username,
            email = @Email,
            full_name = @FullName,
            registration_date = @RegistrationDate
        where user_id = @UserId";

        con.Execute(sql, user);
    }
}