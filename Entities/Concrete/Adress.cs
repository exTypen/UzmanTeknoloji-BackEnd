﻿using System;
using Core.Entities;

namespace Entities.Concrete
{
    //Database'de ki tabloların karşılığı olan classlar.
    public class Address : IEntity
    {
        public Int64 Id { get; set; }
        public int UserId { get; set; }
        public int CityId { get; set; }
        public string AddressDetail { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreateDate { get; set; }
        public bool Active { get; set; }
    }
}