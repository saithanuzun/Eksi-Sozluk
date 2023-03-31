using Dapper;
using EksiSozluk.Projections.UserService.RabbitMQ;
using Npgsql;

namespace EksiSozluk.Projections.UserService.Service;

public class UserService
{
    public async Task<Guid> CreateEmailConfirmation(UserEmailChangedEvent email)
    {
        var guid = Guid.NewGuid();

        var connectionString =
            "USER ID=postgres ; Password=password123;Server=localhost;port=5432;Database=eksisozluk ;Integrated Security=true;Pooling=true";
        using var connection = new NpgsqlConnection(connectionString);
        connection.Open();

        var commandText =
            "INSERT INTO dbo.emailconfirmation (\"Id\", \"CreatedDate\", \"OldEmailAddress\", \"NewEmailAddress\") VALUES (@Id, current_date, @OldEmailAddress ,@NewEmailAddress)";
        var queryArguments = new
        {
            id = guid,
            email.OldEmailAddress,
            email.NewEmailAddress
        };
        await connection.ExecuteAsync(commandText, queryArguments);

        return guid;
    }
}