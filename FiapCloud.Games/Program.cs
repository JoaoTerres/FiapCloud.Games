using FiapCloud.Games.Api.Config;
using FiapCloud.Games.Api.Middleware;
using FiapCloud.Games.Infra.Data;
using FiapCloud.Games.Infra.Messaging;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddDatabaseConfiguration(builder.Configuration)
    .AddRepositoryConfiguration()
    .AddMediatorConfiguration()
    .AddSwaggerConfiguration();

builder.Services.AddControllers();

builder.Services.AddHostedService<RabbitMqConsumer>();

var app = builder.Build();

app.MigrateDatabase<AppDbContext>();

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseSwaggerConfiguration(app.Environment);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
