﻿using System;
using Core.Entities;

namespace Entities.Concrete
{
    public class Brand : IEntity
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}