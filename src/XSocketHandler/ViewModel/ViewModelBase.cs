using XSocketsDemo.Core;

namespace XSocketHandler.ViewModel
{
    /// <summary>
    /// Base for all viewmodels, just holding Id from EF
    /// </summary>
    public abstract class ViewModelBase
    {
        public int Id { get; set; }

        protected ViewModelBase(PersistentEntity entity)
        {
            this.Id = entity.Id;
        }
    }
}