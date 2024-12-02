using DDDSample.Wpf.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace DDDSample.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            var window = Container.Resolve<MainWindow>();
            return window;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // DI コンテナに登録
        }
    }

}
