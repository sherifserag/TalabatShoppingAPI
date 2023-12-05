﻿using System.ComponentModel.DataAnnotations;

namespace TalabatG02.APIs.Dtos
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]

        public string ProductName { get; set; }
        [Required]

        public string PictureUrl { get; set; }
        [Required]
        [Range(0.1,double.MaxValue,ErrorMessage ="Price Must Be Greater than Zero")]
        public decimal Price { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="Quantity Must Be One Item at Least")]
        public int Quantity { get; set; }//1
        [Required]

        public string Brand { get; set; }
        [Required]

        public string Type { get; set; }
    }
}
