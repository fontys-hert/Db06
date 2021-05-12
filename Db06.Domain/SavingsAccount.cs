using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db06.Domain
{
    public class SavingsAccount : Account // OO principe: Inheritance
    {
        // (S) OLID principes
        // Single responsibility pattern (SRP)

        public SavingsAccount(string name, int pin = 12345) : base(name, pin)
        {
        }

        public override string Withdraw(int pin, int amount)
        {
            throw new InvalidOperationException("Jammer joh");
        }
    }
}
