using TaskManager.Data;
using TaskManager.Models;
using HotChocolate.Data;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.GraphQL;

public class Query
{
    [UseFiltering]
    [UseSorting]
    public async Task<IQueryable<TaskItem>> GetAllTasks([Service] IDbContextFactory<AppDbContext> dbContextFactory)
    {
        var context = await dbContextFactory.CreateDbContextAsync();
        // Return IQueryable - no need to dispose context immediately because of deferred execution
        return context.Tasks.AsNoTracking();
    }
}
