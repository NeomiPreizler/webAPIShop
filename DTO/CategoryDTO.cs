﻿using Entities;
using System.Text.Json.Serialization;

namespace DTO;

public partial class CategoryDTO
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;
    
}
