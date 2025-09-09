using Microsoft.EntityFrameworkCore;
using TaskManager.Data;
using TaskManager.GraphQL;

var builder = WebApplication.CreateBuilder(args);

// ✅ Add CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy
            .AllowAnyOrigin()    // You can restrict this to specific origins if needed
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Register DbContext pool with SQLite
builder.Services.AddPooledDbContextFactory<AppDbContext>(options =>
    options.UseSqlite("Data Source=tasks.db"));

// Add GraphQL Server with Query and Mutation
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting();

var app = builder.Build();

// ✅ Use CORS middleware
app.UseCors("AllowAll");

// Create DB schema on startup
using (var scope = app.Services.CreateScope())
{
    var dbFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<AppDbContext>>();
    using var dbContext = dbFactory.CreateDbContext();
    dbContext.Database.EnsureCreated();
}

// Map GraphQL endpoint
app.MapGraphQL();
app.MapGet("/", () => Results.Text("Welcome! Visit /graphql for the GraphQL playground."));

app.Run();
