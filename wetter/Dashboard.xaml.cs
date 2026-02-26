using System;
using Microsoft.UI.Xaml;
using wetter.Views;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace wetter
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Dashboard : Window
    {
        public Dashboard()
        {
            InitializeComponent();
            // Hides the default system title bar.
            ExtendsContentIntoTitleBar = true;
            // Replace system title bar with the WinUI TitleBar control. 
            SetTitleBar(SimpleTitleBar);

            //Default Navigate
            contentFrame.Navigate(typeof(WetterView));
        }

        /// <summary>
        /// Handles the SelectionChanged event of the NavigationView to navigate to the selected page or the settings
        /// view.
        /// </summary>
        /// <param name="sender">The NavigationView control that raised the event.</param>
        /// <param name="args">The event data that contains information about the selected item.</param>
        private void NavigationView_SelectionChanged(Microsoft.UI.Xaml.Controls.NavigationView sender, Microsoft.UI.Xaml.Controls.NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                contentFrame.Navigate(typeof(SettingView));
            }
            else
            {
                var selectedItem = (Microsoft.UI.Xaml.Controls.NavigationViewItem)args.SelectedItem;
                string selectedItemTag = ((string)selectedItem.Tag);
                string pageName = "wetter.Views." + selectedItemTag;
                Type? pageType = Type.GetType(pageName);
                contentFrame.Navigate(pageType);
            }
        }
    }
}
