using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace DTO;

public partial class UserDTO
{

        public int UserId { get; set; }

        [StringLength(20, MinimumLength = 2, ErrorMessage = "FirstName too short minimum 2 letters")]
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [EmailAddress(ErrorMessage = "Email not valid")]
        public string Email { get; set; } = null!;

        [StringLength(maximumLength: 20, ErrorMessage = "password too long")]
        public string Password { get; set; } = null!;
        
       
    }

