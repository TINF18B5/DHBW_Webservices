using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Customer.Controllers;

namespace Customer.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        [IgnoreDataMember]
        public bool IsFavorite { get; set; }
        [IgnoreDataMember]
        public string ImageFile { get; set; }

    }
}