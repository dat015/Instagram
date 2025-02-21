using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using server.Helper;
using server.Models;

namespace server.DTO
{
    public class UserDTO
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public bool? Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? Token { get; set; }
    }
}