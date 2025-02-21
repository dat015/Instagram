using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using server.Helper;

namespace server.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Tên đăng nhập phải từ 8 đến 30 ký tự.")]
        public string? Username { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 8, ErrorMessage = "Mật khẩu phải từ 8 đến 30 ký tự.")]
        public string? PasswordHash { get; set; }
        [Required]
        public string? PasswordKey { get; set; }
        [Required]
        [RegularExpression(@"^(\+84|0)([3|5|7|8|9])([0-9]{8})$", ErrorMessage = "Số điện thoại không hợp lệ.")]

        public string? PhoneNumber { get; set; }
        [Required]
        [EmailAddress] // Kiểm tra email tự động
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", 
        ErrorMessage = "Email không hợp lệ.")]
        public string? Email { get; set; }
        [Required]
        public bool Gender { get; set; }
        [Required]
        [MinAge(16)]
        public DateTime DateOfBirth { get; set; }




    }
}