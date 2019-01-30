using BankRelease.Domain.Interfaces.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankRelease.Domain.Entity
{
    public class TransferRelease : IRelease
    {
        public TransferRelease()
        {

        }

        public int Id { get; set; }
        public int OriginAccount { get; set; }
        public int DestinationAccount { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Value { get; set; }
    }
}
