﻿using JoyPromotion.Shared.Entities;

namespace JoyPromotion.Dtos.Dtos
{
    public class CategoryUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
