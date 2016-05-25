using System;

namespace QudiniChallenge.Contracts.Domain
{
    public interface ICustomer
    {
        string Name { get; set; }
        string Surname { get; set; }
        string Email { get; set; }
        DateTime ExpectedTime { get; set; } 
    }
}
