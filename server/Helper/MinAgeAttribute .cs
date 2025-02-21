using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.Helper
{
    public class MinAgeAttribute : ValidationAttribute
    {
        private readonly int _minAge;

        public MinAgeAttribute(int minAge)
        {
            _minAge = minAge;
            ErrorMessage = $"Bạn phải trên {_minAge} tuổi để đăng ký.";
        }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value is DateTime dateOfBirth)
            {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;

            if (dateOfBirth > today.AddYears(-age)) // Chưa đến sinh nhật năm nay
                age--;

            if (age < _minAge)
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success!;
        }
    }
}