var repository = new TaskRepository();

repository.Add(new TaskItem
{
    Id = 1,
    Title = "Create project structure",
    IsCompleted = true
});

repository.Add(new TaskItem
{
    Id = 2,
    Title = "Implement JSON serialization",
    IsCompleted = false
});

repository.Add(new TaskItem
{
    Id = 3,
    Title = "Test repository methods",
    IsCompleted = false
});

await repository.SaveToFileAsync("tasks.json");

Console.WriteLine("Tasks saved to file.");

var loadedRepository = new TaskRepository();
await loadedRepository.LoadFromFileAsync("tasks.json");

Console.WriteLine("Tasks loaded from file:");
Console.WriteLine();

foreach (var task in loadedRepository.GetAll())
{
    Console.WriteLine($"Id: {task.Id}");
    Console.WriteLine($"Title: {task.Title}");
    Console.WriteLine($"Completed: {task.IsCompleted}");
    Console.WriteLine();
}

var foundTask = loadedRepository.GetById(2);

if (foundTask != null)
{
    Console.WriteLine("Found task by Id:");
    Console.WriteLine($"Id: {foundTask.Id}, Title: {foundTask.Title}");
}