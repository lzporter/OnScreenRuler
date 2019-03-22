namespace Savaged.OnScreenRulerLib.ViewModels
{
    public class ViewModelLocator
    {
        private static ViewModelLocator _current;

        public static ViewModelLocator Current =>
            _current ?? (_current = new ViewModelLocator());

        private ViewModelLocator()
        {
            MainViewModel = new MainViewModel();
        }

        public MainViewModel MainViewModel { get; }
    }
}
