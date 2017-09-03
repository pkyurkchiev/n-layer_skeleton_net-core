namespace NTS.Data.Entities
{
    using Interfaces;

    public class User : Entity, IIsActive
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; }
    }
}
