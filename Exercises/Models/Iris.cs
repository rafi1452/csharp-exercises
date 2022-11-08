using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Exercises.Models;

[Keyless]
[Table("iris")]
public partial class Iris
{
    [Column("sepal_length")]
    public double SepalLength { get; set; }

    [Column("sepal_width")]
    public double SepalWidth { get; set; }

    [Column("petal_length")]
    public double PetalLength { get; set; }

    [Column("petal_width")]
    public double PetalWidth { get; set; }

    [Column("species")]
    [StringLength(50)]
    public string Species { get; set; } = null!;
}
