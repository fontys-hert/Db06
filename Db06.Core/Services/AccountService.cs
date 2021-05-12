using Db06.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Db06.Core.Services
{
    public class AccountService
    {
        private readonly Db06Context _context;

        public AccountService(Db06Context context)
        {
            _context = context;
        }

        public void CreateNew(Domain.Account account)
        {

            var existingAccount = _context.Accounts.FirstOrDefault(dbAccount => dbAccount.Name == account.Name);

            // bestaat account al?
            if (existingAccount != null)
            {
                // zo ja -> error
                throw new InvalidOperationException("Account already exists");
            }

            // zo nee -> inserten
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
    }
}
