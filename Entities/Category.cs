﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;
    
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
