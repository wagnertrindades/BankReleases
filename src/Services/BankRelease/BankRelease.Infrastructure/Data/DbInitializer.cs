using BankRelease.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankRelease.Infrastructure.Data
{
    public class DbInitializer
    {
        public static void Initialize(BankReleaseContext context)
        {
            if (context.TransferReleases.Any())
            {
                return;
            }

            var transferReleases = new TransferRelease[]
            {
                new TransferRelease {
                    OriginAccount = 1,
                    DestinationAccount = 2,
                    Value = decimal.Parse("10.00"),
                },

                new TransferRelease {
                    OriginAccount = 2,
                    DestinationAccount = 3,
                    Value = decimal.Parse("100.00"),
                },

                new TransferRelease {
                    OriginAccount = 3,
                    DestinationAccount = 4,
                    Value = decimal.Parse("1000.00"),
                },
            };

            context.AddRange(transferReleases);

            context.SaveChanges();
        }
    }
}
