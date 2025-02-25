using System;
using System.Collections.Generic;

namespace ConsoleApp1;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int? Age { get; set; }

    public int? GroupId { get; set; }

    public virtual Group? Group { get; set; }
}
