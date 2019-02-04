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
        public virtual decimal Balance { get; private set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public virtual void Credit(decimal value)
        {
            Balance += value;
        }

        public virtual void Debit(decimal value)
        {
            Balance -= value;
        }
    }

    
}
