using System.ComponentModel.DataAnnotations.Schema;

namespace Account.Domain.Entity
{
    public class CheckingAccount
    {
        public CheckingAccount()
        {

        }

        public int Id { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Balance { get; private set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public void Credit(decimal value)
        {
            Balance += value;
        }

        public void Debit(decimal value)
        {
            Balance -= value;
        }
    }

    
}
