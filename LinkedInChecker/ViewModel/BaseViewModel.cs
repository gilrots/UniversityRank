
using System.ComponentModel;


namespace LinkedInChecker.ViewModel
{
    /// <summary>
    /// Base class for implements mvvm design
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnpropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
