using System;
using System.ComponentModel.DataAnnotations;

namespace RCH_HIS.Models
{
    public class InputModel
    {
        [Required(ErrorMessage = "The number field is required.")]
        [Range(1, 100, ErrorMessage = "Please enter a number between 1 and 100.")]
        public int NumberField { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}