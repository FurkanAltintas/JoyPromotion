﻿using JoyPromotion.Shared.Entities;

namespace JoyPromotion.Dtos.Dtos
{
    public class SocialMediaDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
    }
}
