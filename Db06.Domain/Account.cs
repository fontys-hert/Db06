using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db06.Domain
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
        // OO principe: Encapsulation

        // properties
        public int Id { get; private set; }
        public string Name { get; private set; }
        private int Balance { get; set; }
        private int Pin { get; set; }

        // constructors
        private Account() { }

        public Account(string name, int pin = 12345)
        {
            Name = name;
            Pin = pin;
        }

        // methodes
        public string Deposit(int pin, int amount)
        {
            if (pin != Pin) return _incorrectPinMessage;

            Balance += amount;
            return $"Uw bedrag is veilig aangekomen. Nieuwe balans: {Balance}";
        }

        public virtual string Withdraw(int pin, int amount)
        {
            if (pin == Pin)
            {
                Balance -= amount;
                return $"Uw bedrag is veilig opgenomen. Nieuwe balans: {Balance}";
            }

            return _incorrectPinMessage;
        }

        public int GetBalance(int pin)
        {
            if (pin != Pin) throw new ArgumentException(_incorrectPinMessage, nameof(pin));

            return Balance;
        }
    }
}
