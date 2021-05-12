using Db06.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Db06.Test
{
    /**
     * Het is mogelijk voor een rekening om:
     * een rekening te openen, waarbij een naam verplicht is en een pincode optioneel. 
     * Zodra een pincode niet meegeleverd is, zal de standaard pincode 12345 zijn. 
     * Pincode mag niet opgevraagd worden
     */

    public class AccountTests
    {
        [Fact]
        public void Creates_a_bank_account_with_a_name()
        {
            // arrange
            // act
            var account = new Account("Sven's rekening");

            // assert
            Assert.Equal("Sven's rekening", account.Name);
        }

        // een pincode optioneel. 
        // Zodra een pincode niet meegeleverd is, zal de standaard pincode 12345 zijn.
        // Pincode mag niet opgevraagd worden

        // Geld te storten als de pincode correct wordt ingevoerd.
        // Er wordt een bericht getoond van de nieuwe balans.
        // Als de pincode incorrect is volgt een bericht dat de pincode niet correct is.
        [Fact]
        public void Deposits_amount_when_default_pin_is_correct()
        {
            // arrange
            var account = new Account("Thisoban's account");
            account.Deposit(12345, 100);

            // act
            string result = account.Deposit(12345, 50);
            // console.writeline?
            // bericht?

            // assert
            Assert.Equal("Uw bedrag is veilig aangekomen. Nieuwe balans: 150", result);
        }

        // incorrecte pin

        [Fact]
        public void Shows_a_message_with_an_invalid_pin_when_depositing()
        {
            // arrange
            var account = new Account("Thisoban's account");

            // act
            string result = account.Deposit(11111, 50);
            
            // assert
            Assert.Equal("Verkeerde PIN", result);
        }

        // niet-default pin
        [Fact]
        public void Deposits_amount_when_custom_pin_is_correct()
        {
            // arrange
            var account = new Account("Thisoban's account", 11111);

            // act
            string result = account.Deposit(11111, 50);

            // assert
            Assert.Equal("Uw bedrag is veilig aangekomen. Nieuwe balans: 50", result);
        }

        // - Geld op te nemen als de pincode correct wordt ingevoerd.
        // Er wordt een bericht getoond van de nieuwe balans.
        // Als de pincode incorrect is volgt een bericht dat de pincode niet correct is.
        [Fact]
        public void Withdraws_amount_when_pin_is_correct()
        {
            // arrange
            var account = new Account("Timo's account", 11111);
            account.Deposit(11111, 100);

            // act
            string result = account.Withdraw(11111, 50);

            // assert
            Assert.Equal("Uw bedrag is veilig opgenomen. Nieuwe balans: 50", result);
        }

        [Fact]
        public void Gets_the_current_balance_when_pin_is_correct()
        {
            var account = new Account("Marc");
            account.Deposit(12345, 15000);

            var balance = account.GetBalance(12345);

            Assert.Equal(15000, balance);
        }
    }
}
