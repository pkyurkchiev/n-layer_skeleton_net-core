namespace NTS.Data.Entities
{
    using Interfaces;

    public abstract class EntityWithFlags : Entity, IIsActive
    {
        #region Contstructors
        public EntityWithFlags()
        {
            IsActive = true;
        }
        #endregion

        #region Properties

        public bool IsActive { get; set; }

        #endregion
    }
}
