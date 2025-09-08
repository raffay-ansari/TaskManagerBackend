using TaskManager.Data;
using TaskManager.Models;
using HotChocolate;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.GraphQL;

public class Mutation
{
    public async Task<TaskItem> CreateTask(
        string title,
        string description,
        [Service] IDbContextFactory<AppDbContext> dbContextFactory)
    {
        await using var context = await dbContextFactory.CreateDbContextAsync();

        var task = new TaskItem
        {
            Title = title,
            Description = description,
            Status = Models.TaskStatus.Pending
        };

        context.Tasks.Add(task);
        await context.SaveChangesAsync();
        return task;
    }

    public async Task<TaskItem?> UpdateTaskStatus(
        int id,
        Models.TaskStatus status,
        [Service] IDbContextFactory<AppDbContext> dbContextFactory)
    {
        await using var context = await dbContextFactory.CreateDbContextAsync();

        var task = await context.Tasks.FindAsync(id);
        if (task is null) return null;

        task.Status = status;
        await context.SaveChangesAsync();
        return task;
    }
}
