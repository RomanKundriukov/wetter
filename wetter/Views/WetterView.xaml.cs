using Microsoft.UI.Xaml.Controls;
using wetter.ViewModels;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace wetter.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class WetterView : Page
    {
        internal WetterViewModel _vm { get; set; }
        public WetterView()
        {
            _vm = new WetterViewModel();

            this.InitializeComponent();
            DataContext = _vm;

            Loaded += async (sender, args) => 
            {
                await _vm.Initialize();
            };
        }

        //private void initial()
        //{
        //    Task task = new Task(async () => await _vm.Initialize());

        //    task.RunSynchronously();

        //    Task.WaitAny(task);
        //}
    }
}
