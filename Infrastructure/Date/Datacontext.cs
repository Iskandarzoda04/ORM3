using Npgsql;
using System.Data;
namespace Infrastructure.Date;

public class DataContext
{
    private readonly string connectionString =  "Server=localhost;Database=ORM3;User Id=postgres;Password=12345";
   


     public IDbConnection GetConnection()
    {
        return new NpgsqlConnection(connectionString);
    }
        
}



