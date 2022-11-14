using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Application.DTO
{
    public class ProductForCreationDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Price is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a Quantity bigger than {0}")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a Quantity bigger than {0}")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "ImgURL is required")]
        public string ImgURL { get; set; }
        [Required(ErrorMessage = "CategoryId is required")]
        public Guid CategoryId { get; set; }
    }
}
