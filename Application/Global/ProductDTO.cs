﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO
{
   public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string ImgURL { get; set; }
        public CategoryDTO Category { get; set; }
    }
}
