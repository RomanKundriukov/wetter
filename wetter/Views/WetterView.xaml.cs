using Microsoft.UI.Xaml.Controls;
using System.Threading.Tasks;
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

            Loading += async (sender, args) => 
            {
               // await _vm.GetDatenVonApiAsync();

                Task.WaitAny(_vm.GetDatenVonApiAsync());
            };

            Loaded += async (sender, args) =>
            {
                await _vm.InitialisiereAsync();
            };

        }
      
       
    }
}
