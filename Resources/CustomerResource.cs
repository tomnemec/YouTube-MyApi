using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApi.Models;

namespace MyApi.Resources
{
    public class CustomerResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public MembershipType MembershipType { get; set; }
    }
}