using System.Linq;
using Account.Domain.Entity;

namespace Account.Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AccountContext context)
        {
            if (context.CheckingAccounts.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User {
                    Name = "Darth Vader",
                    CPF = "97090260038",
                    Phone = "11999999999",
                    Email = "darth@vader.com"
                },

                new User {
                    Name = "Bart Simpson",
                    CPF = "77734098037",
                    Phone = "48888888888",
                    Email = "bart@simpson.com"
                },

                new User {
                    Name = "Xunda",
                    CPF = "53975581093",
                    Phone = "11777777777",
                    Email = "xunda@xunda.com"
                },
            };

            context.AddRange(users);

            var checkingAccounts = new CheckingAccount[]
            {
                new CheckingAccount {
                    User = users[0]
                },
                new CheckingAccount {
                    User = users[1]
                },
                new CheckingAccount {
                    User = users[2]
                },
            };

            context.AddRange(checkingAccounts);

            context.SaveChanges();
        }
    }
}
