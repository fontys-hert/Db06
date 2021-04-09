using Db06.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Db06.Test.Controllers
{
    public class AccountControllerTests
    {
        [Fact]
        public void Shows_an_error_when_supplying_an_invalid_pin()
        {
            var controller = new AccountController();

            controller.Index(12345);

            // [...] de rest
        }
    }
}
