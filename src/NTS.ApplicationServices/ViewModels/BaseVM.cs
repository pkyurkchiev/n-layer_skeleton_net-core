namespace NTS.ApplicationServices.ViewModels
{
    public abstract class BaseVM
    {
        #region Properties
        public int Id { get; set; }

        public bool IsActive { get; set; }
        #endregion

        #region Constcutors
        public BaseVM()
        {
            IsActive = true;
        }
        #endregion
    }
}
