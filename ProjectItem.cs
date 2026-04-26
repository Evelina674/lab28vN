using System.Collections.Generic;

public class ProjectItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<TaskItem> Tasks { get; set; } = new();
}