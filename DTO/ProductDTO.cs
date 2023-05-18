using Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DTO;

public partial class ProductDTO
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int Price { get; set; }

    public int CategoryId { get; set; }

    public string? Description { get; set; }

    public string? Img { get; set; }

    public string CategoryName { get; set; } = null!;
   
}
