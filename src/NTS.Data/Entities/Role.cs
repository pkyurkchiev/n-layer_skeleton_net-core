namespace NTS.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Role : EntityWithFlags
    {
        #region Properties

        [StringLength(50)]
        public string Name { get; set; }

        public virtual ICollection<User> Users { get; set; }

        #endregion
    }
}
