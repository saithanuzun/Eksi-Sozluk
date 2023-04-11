using EksiSozluk.Api.Application.Extensions;
using EksiSozluk.Api.Infrastructure.Persistence.Extensions;
using EksiSozluk.Api.WebApi.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddControllers()
    .AddJsonOptions(opt => { opt.JsonSerializerOptions.PropertyNamingPolicy = null; })
    .ConfigureApiBehaviorOptions(o => o.SuppressModelStateInvalidFilter = true);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwagger();

builder.Services.ConfigureAuth(builder.Configuration);
builder.Services.AddInfrastructureRegistration(builder.Configuration);
builder.Services.AddApplicationRegistration();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
}));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.ConfigureExceptionHandling(app.Environment.IsDevelopment());

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("MyPolicy");

app.MapControllers();

app.Run();