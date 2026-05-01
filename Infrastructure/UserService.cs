using Dapper;
using Domain;
using Infrastructure.Date;
using Infrastructure.Interfacce;

namespace Infrastructure;

public class UserService : IUserService
{
    private readonly DataContext context = new();

    public async Task Add(User user)
    {
        using var conn = context.GetConnection();
        conn.Open();

        string sql = @"
        insert into Users (username, email, Fullname, Registrationdate)
        values (@Username, @Email, @FullName, @RegistrationDate)";

       await conn.ExecuteAsync(sql, user);
    }

    public async Task Delete(int id)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "delete from Users where id = @Id";

        await con.ExecuteAsync(sql, new { Id = id });
    }

    public  async Task<List<User>> GetAll()
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "select * from Users";

        var us= con.Query<User>(sql).ToList();
        return us;
    }

    public async Task<User> GetById(int id)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = "select * from Users where id = @Id";

        var us = con.QueryFirstOrDefault<User>(sql, new { Id = id });
        return us;
    }

    public async Task Update(User user)
    {
        using var con = context.GetConnection();
        con.Open();

        string sql = @"
        update Users
        set username = @Username,
            email = @Email,
            Fullname = @FullName,
            Registrationdate = @RegistrationDate
        where id = @UserId";

       await con.ExecuteAsync(sql, user);
    }
}