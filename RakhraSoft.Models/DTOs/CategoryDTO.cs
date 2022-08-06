using System;
using System.ComponentModel.DataAnnotations;

namespace RakhraSoft.Models.DTOs
{
    public class CategoryDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name.")]
        public string Name { get; set; }
    }
}

