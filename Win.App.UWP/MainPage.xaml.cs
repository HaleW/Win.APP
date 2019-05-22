using Client.DotNettyClient;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Win.App.UWP.Pages;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Win.App.UWP
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<String> suggestions;
        public static Button backBbutton;
        public MainPage()
        {
            this.InitializeComponent();
            ContentFrame.Navigate(typeof(AppPage));
            //ContentFrame.Navigate(typeof(LogoPage));
            CustomTitleBar();
            SetBackButtonVisible();
            backBbutton = BackButton;
            suggestions = new ObservableCollection<string>();
            suggestions.Add("AAAAAA");
            suggestions.Add("CCCCCCCCCC");
            suggestions.Add("BBBBBBBBBBB");
            suggestions.Add("BBBBBBBB");
            suggestions.Add("DDDDDDDD");
            suggestions.Add("RRRRRRRRRRRR");
            suggestions.Add("TTTTTTTTTTTTT");
        }

        private void CustomTitleBar()
        {
            var coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            var appTitleBar = ApplicationView.GetForCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            appTitleBar.ButtonBackgroundColor = Colors.Transparent;
            appTitleBar.ButtonInactiveBackgroundColor = Colors.Transparent;
            coreTitleBar.LayoutMetricsChanged += CoreTitleBar_LayoutMetricsChanged;
        }

        private void IsShowSearchBox(bool flag)
        {
            SearchAutoSuggestBox.Visibility = flag ? Visibility.Visible : Visibility.Collapsed;
            SearchButton.Visibility = !flag ? Visibility.Visible : Visibility.Collapsed;
        }

        public void SetBackButtonVisible()
        {
            BackButton.Visibility = ContentFrame.CanGoBack ? Visibility.Visible : Visibility.Collapsed;
        }

        private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
        {
            TitleBar.Padding = new Thickness(sender.SystemOverlayLeftInset, 0, sender.SystemOverlayRightInset, 0);
            Window.Current.SetTitleBar(TitleBarGrid);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (ContentFrame.CanGoBack)
            {
                ContentFrame.GoBack();
            }
            SetBackButtonVisible();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            IsShowSearchBox(true);
        }

        private void Page_PointerPressed(object sender, Windows.UI.Xaml.Input.PointerRoutedEventArgs e)
        {
            IsShowSearchBox(false);
        }

        private void SettingButton_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(SettingsPage));
            SetBackButtonVisible();
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(DownloadPage));
            SetBackButtonVisible();
        }

        //private void AccountButton_Click(object sender, RoutedEventArgs e)
        //{
        //    ContentFrame.Navigate(typeof(AccountPage));
        //    SetBackButtonVisible();
        //}

        private void SearchAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                //Set the ItemsSource to be your filtered dataset
                var filtered = suggestions.Where(p => p.StartsWith(sender.Text)).ToArray();
                sender.ItemsSource = filtered;
            }
        }

        private void SearchAutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            // Set sender.Text. You can use args.SelectedItem to build your text string.
            //a.Text = args.SelectedItem.ToString();
        }

        private void SearchAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                // User selected an item from the suggestion list, take an action on it here.
            }
            else
            {
                // Use args.QueryText to determine what to do.
                //a.Text = sender.Text;
            }
        }

        private void TCPButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
