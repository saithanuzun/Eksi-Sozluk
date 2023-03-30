using System.Data.SqlClient;
using Dapper;
using EksiSozluk.Projections.UserService.RabbitMQ;
using Npgsql;

namespace EksiSozluk.Projections.UserService.Service;

public class UserService
{
    public async Task<Guid> CreateEmailConfirmation(UserEmailChangedEvent email)
    {
        var guid = Guid.NewGuid();

        string connectionString="USER ID=postgres ; Password=password123;Server=localhost;port=5432;Database=eksisozluk ;Integrated Security=true;Pooling=true";
        using var connection = new NpgsqlConnection(connectionString: connectionString);
        string table = "public.dbo.emailconfirmation";
        string commandText =
            $"INSERT INTO  {table} (Id, CreatedDate, OldEmailAddress, NewEmailAddress) VALUES (@Id, GETDATE(), @OldEmailAddress, @NewEmailAddress)";
        connection.Open();
        await using (var cmd = new NpgsqlCommand(commandText, connection))
        {
            cmd.Parameters.AddWithValue("Id", guid);
            cmd.Parameters.AddWithValue("OldEmailAddress", email.OldEmailAddress);
            cmd.Parameters.AddWithValue("NewEmailAddress", email.NewEmailAddress);
            await cmd.ExecuteNonQueryAsync();
        }

        return guid;
    }
}