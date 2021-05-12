using Db06.Core.Services;
using Db06.DataAccess;
using Db06.Domain;
using Db06.Mvc.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Db06.Mvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly Account _account;
        private readonly Db06Context _context;

        public AccountController(Db06Context context)
        {
            _account = new Account("Timo");
            _account.Deposit(12345, 150);
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new AccountViewModel
            {
                ErrorMessage = null,
                Balance = 0,
                IsPinCorrect = false,
                Name = _account.Name
            });
        }

        [HttpPost]
        public IActionResult Index(int pin) // Single Responsibility
        {
            int balance = 0;
            bool isPinCorrect = true;
            string errorMessage = null;

            try
            {
                balance = _account.GetBalance(pin);
            }
            catch (ArgumentException exception)
            {
                if (exception.ParamName == "pin")
                {
                    isPinCorrect = false;
                    errorMessage = "De PIN code is niet correct";
                }
                else
                {
                    errorMessage = "Het invoeren van de PIN code is niet gelukt";
                }
            }

            var accountViewModel = new AccountViewModel
            {
                Balance = balance,
                IsPinCorrect = isPinCorrect,
                Name = _account.Name,
                ErrorMessage = errorMessage
            };

            return View(accountViewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(AccountCreateViewModel accountViewModel)
        {
            var accountService = new AccountService(_context);

            accountService.CreateNew(new Account(accountViewModel.Name, accountViewModel.Pin));

            return RedirectToAction("Index");
        }
    } 
}
