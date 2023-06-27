using System;
using System.Collections.Generic;

namespace ToDoList.Areas.AddTask.Models;

public partial class Todoapp
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }
}
