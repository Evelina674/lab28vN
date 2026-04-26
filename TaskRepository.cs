using System.Text.Json;

public class TaskRepository
{
    private List<TaskItem> tasks = new();

    public void Add(TaskItem task)
    {
        tasks.Add(task);
    }

    public List<TaskItem> GetAll()
    {
        return tasks;
    }

    public TaskItem GetById(int id)
    {
        return tasks.FirstOrDefault(t => t.Id == id);
    }

    public async Task SaveToFileAsync(string filename)
    {
        var json = JsonSerializer.Serialize(tasks);
        await File.WriteAllTextAsync(filename, json);
    }

    public async Task LoadFromFileAsync(string filename)
    {
        if (!File.Exists(filename)) return;

        var json = await File.ReadAllTextAsync(filename);
        tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new();
    }
}