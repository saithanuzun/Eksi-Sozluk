using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace EksiSozluk.Api.WebApi.Extensions;

public static class AuthRegistration
{
    public static IServiceCollection ConfigureAuth(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:SigningKey"]));

        serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = signingKey,
                    ValidIssuer = "https://localhost:5000",
                    ValidAudience = "https://localhost:5000",
                    
                };
            });
        return serviceCollection;
    }
}