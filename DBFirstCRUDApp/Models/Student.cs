using System;
using System.Collections.Generic;

namespace DBFirstCRUDApp.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string StudentName { get; set; } = null!;

    public string Batch { get; set; } = null!;

    public int Marks { get; set; }
}
