using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DTO;

public partial class UserDTO
{

        public int UserId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string Email { get; set; } = null!;

        public string Password { get; set; } = null!;
        [JsonIgnore]
        public virtual ICollection<Order> Orders { get; } = new List<Order>();
    }

