﻿
using JobStack.Domain.Enums;

namespace JobStack.Domain.Common;

public class BaseEntity
{
    public int Id { get; set; }
    public bool  IsDeleted { get; set; }
}
