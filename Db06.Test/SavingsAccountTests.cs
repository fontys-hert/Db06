using Db06.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Db06.Test
{
    public class SavingsAccountTests
    {
        [Fact]
        public void Cannot_withdraw_amount()
        {
            var account = new SavingsAccount("Timo's spaarrekening", 4444);

            Assert.Throws<InvalidOperationException>(() => account.Withdraw(4444, 50));
        }
    }
}
