using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApi.Resources
{
    public class SaveCustomerResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int MembershipTypeId { get; set; }
    }
}