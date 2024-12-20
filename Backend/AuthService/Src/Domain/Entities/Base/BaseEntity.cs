﻿namespace Domain.Entities.Base;

public abstract class BaseEntity
{
    public DateTime CreatedAt { get; } = DateTime.UtcNow;  
    public DateTime? UpdatedAt { get; set; }
}