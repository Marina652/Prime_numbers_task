﻿using System.ComponentModel.DataAnnotations;

namespace MyTask.Models;

public class NumberModel
{
    [Key]
    public int Number { get; set; }

    public bool IsPrime { get; set; }
}
