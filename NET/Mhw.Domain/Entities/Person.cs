﻿using System;

namespace Mhw.Domain.Entities
{
    public class Person : EntityBase
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string AddressLine { get; set; }
    }
}