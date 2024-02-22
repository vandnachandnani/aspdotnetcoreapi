using System;
using System.Collections.Generic;

namespace ASPCOREWEBAPI.Models;

public partial class Student
{
    public decimal StudentId { get; set; }

    public string? StudentName { get; set; }

    public decimal? Age { get; set; }
}
