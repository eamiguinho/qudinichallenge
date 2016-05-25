using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QudiniChallenge.Contracts.Domain;

namespace QudiniChallenge.Domain.Implementation
{
    public class Customer : ICustomer
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public DateTime ExpectedTime { get; set; }
        public int Id { get; set; }
    }
}
