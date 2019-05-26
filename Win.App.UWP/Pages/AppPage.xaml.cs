using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Win.App.Client.Msg;
using Win.App.Client.SQLite;
using Win.App.Model;
using Win.App.Protobuf.Msg;
using static Win.App.UWP.Tools.TimeTools;
using static Win.App.Client.Msg.SendMsg;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml;
using Win.App.UWP.Tools;
using Windows.System.Threading;
using Windows.UI.Core;

namespace Win.App.UWP.Pages
{
    public sealed partial class AppPage : Page
    {
        ObservableCollection<AppInfo> AppInfos = new ObservableCollection<AppInfo>();

        bool IsCompleted = false;
        bool IsError = false;
        bool IsFirst = true;
        ThreadPoolTimer PeriodicTimer;

        public AppPage()
        {
            this.InitializeComponent();
            GetAppInfo();
            if (IsFirst)
            {
                CancelPeriodicTimer();
            }
        }

        private void AppGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(AppInfoPage), (AppInfo)e.ClickedItem);
        }

        private void GetAppInfo()
        {
            ObservableCollection<AppInfo> appInfos = ReceiveMsg<AppInfoProto, AppInfo, string>.appInfos;

            if (appInfos.Count != 0)
            {
                AppInfos = appInfos;
                AppGridView.ItemsSource = AppInfos;
                IsFirst = false;
                return;
            }

            LoadingBorder.Visibility = Visibility.Visible;
           
            DateTime dateTime = DateTime.Now;
            int errorCount = 0;
            PeriodicTimer = ThreadPoolTimer.CreatePeriodicTimer(async (source) =>
            {
                await Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
                {
                    appInfos = ReceiveMsg<AppInfoProto, AppInfo, string>.appInfos;

                    if (AppInfos.Count != appInfos.Count)
                    {
                        IsCompleted = true;
                        AppInfos = appInfos;
                        AppGridView.ItemsSource = AppInfos;
                        LoadingBorder.Visibility = Visibility.Collapsed;
                        
                    }
                    else if (TimeDiffOfSeconds(dateTime) > 5)
                    {
                        dateTime = DateTime.Now;

                        errorCount++;

                        if (errorCount > 2)
                        {
                            LoadingProgressRing.Visibility = Visibility.Collapsed;
                            LoadingTextBlock.Visibility = Visibility.Visible;
                            IsError = true;

                            
                        }
                        else
                        {
                            GetAppInfos();
                        }
                    }
                });
            }, TimeSpan.FromSeconds(1));
        }

        private void CancelPeriodicTimer()
        {
            Task.Run(() =>
            {
                while (true)
                {
                    if (IsCompleted || IsError)
                    {
                        PeriodicTimer.Cancel();
                        break;
                    }
                }
            });
        }
    }
}
