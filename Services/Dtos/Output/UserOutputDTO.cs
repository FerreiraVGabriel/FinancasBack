﻿namespace Api.Dtos.Output
{
    public record UserOutputDTO
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
    }
}