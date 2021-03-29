using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db06.Core
{
    enum AccountType
    {
        Savings,
        Expense
    }

    // access modifiers: private, public, protected, internal
    public class Account // OO principe: Polymorphisme
    {
        // fields
        private readonly string _incorrectPinMessage = "Verkeerde PIN";
        private int _balance;
        private int _pin; // OO principe: Encapsulation

        // properties
        public string Name { get; }

        // constructors
        public Account(string name, int pin = 12345)
        {
            Name = name;
            _pin = pin;
        }

        // methodes
        public string Deposit(int pin, int amount)
        {
            if (pin != _pin) return _incorrectPinMessage;

            _balance += amount;
            return $"Uw bedrag is veilig aangekomen. Nieuwe balans: {_balance}";
        }

        // methodes
        public virtual string Withdraw(int pin, int amount)
        {
            if (pin == _pin)
            {
                _balance -= amount;
                return $"Uw bedrag is veilig opgenomen. Nieuwe balans: {_balance}";
            }

            return _incorrectPinMessage;
        }
    }
}
