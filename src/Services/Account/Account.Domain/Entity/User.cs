namespace Account.Domain.Entity
{
    public class User
    {
        public User()
        {

        }

        public int Id { get; set; } 
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public CheckingAccount CheckingAccount { get; set; }
    }
}
