using LinkedInChecker.ViewModel;


namespace LinkedInChecker
{
    /// <summary>
    /// Base for implements Data entity mvvm design
    /// </summary>
    /// <typeparam name="T">Represents data</typeparam>
    public abstract class BaseViewModelEntity<T> : BaseViewModel where T : IDataParser, new()
    {
        protected T Model;

        public BaseViewModelEntity(T model)
        {
            Model = new T();
            LoadFromModel(model);
        }

        protected abstract void LoadFromModel(T model);
    }
}
