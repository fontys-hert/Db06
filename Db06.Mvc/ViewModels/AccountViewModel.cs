using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Db06.Mvc.ViewModels
{
    public class AccountViewModel
    {
        public bool IsPinCorrect { get; set; }
        public string Name { get; set; }
        public int Balance { get; set; }
        public string ErrorMessage { get; set; }
    }
}
