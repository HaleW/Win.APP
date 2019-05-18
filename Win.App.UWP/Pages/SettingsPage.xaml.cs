using System.Linq;
using Win.App.UWP.Settings;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Win.App.UWP.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            this.InitializeComponent();
            Loaded += SettingsPageLoaded;
        }

        private void ThemeRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var selectedTheme = ((RadioButton)sender)?.Tag?.ToString();

            if (selectedTheme != null)
            {
                Setting.Theme = App.GetEnum<ElementTheme>(selectedTheme);
            }
        }
        private void SettingsPageLoaded(object sender, RoutedEventArgs e)
        {
            var currentTheme = Setting.Theme.ToString();
            ThemeStackPanel.Children.Cast<RadioButton>().FirstOrDefault(c => c?.Tag?.ToString() == currentTheme).IsChecked = true;
        }
    }
}
