namespace TaskManager.Models;

public enum TaskStatus
{
    Pending,
    InProgress,
    Completed
}

public class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public TaskStatus Status { get; set; } = TaskStatus.Pending;
}
