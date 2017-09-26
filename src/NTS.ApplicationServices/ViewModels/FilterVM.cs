namespace NTS.ApplicationServices.ViewModels
{
    public abstract class FilterVM
    {
        public bool IsActiveDisplayed { get; set; }
        public virtual bool IsActive { get; private set; }
    }
}
