using GalaSoft.MvvmLight.Ioc;

namespace Savaged.OnScreenRulerLib.ViewModels
{
    public class ViewModelLocator
    {
        private static ViewModelLocator _current;

        public static ViewModelLocator Current =>
            _current ?? (_current = new ViewModelLocator());

        private ViewModelLocator()
        {
            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel MainViewModel =>
            SimpleIoc.Default.GetInstance<MainViewModel>();
    }
}
