using Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DTO;

public partial class OrderDTO
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public int OrderSum { get; set; }

    public int UserId { get; set; }

    public ICollection<OrderItemDTO> OrderItems { get; set; } = new List<OrderItemDTO>();

}

