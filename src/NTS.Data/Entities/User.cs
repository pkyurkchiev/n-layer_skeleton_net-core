namespace NTS.Data.Entities
{
    public class User : EntityWithFlags
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }
        
        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
    }
}
