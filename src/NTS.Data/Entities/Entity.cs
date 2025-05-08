namespace NTS.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class Entity
    {
        #region Constructors
        public Entity()
        {
            CreatedOn = DateTime.UtcNow;
        }
        #endregion

        #region Properties

        [Key]
        public int Id { get; set; }

        public int? CreatedBy { get; set; }
        
        public DateTime? CreatedOn { get; set; }

        public int? UpdatedBy { get; set; }
        
        public DateTime? UpdatedOn { get; set; }

        #endregion
    }
}
