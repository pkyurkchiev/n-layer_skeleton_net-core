namespace NTS.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Role : EntityWithFlags
    {
        #region Properties

        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        #endregion
    }
}
