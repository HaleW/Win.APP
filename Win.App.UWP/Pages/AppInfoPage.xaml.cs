using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Diagnostics;
using Win.App.UWP.Tools;
using Win.App.Model;

namespace Win.App.UWP.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class AppInfoPage : Page
    {
        private AppInfo AppInfo;
        public static List<AppInfo> AppDownloadingList = new List<AppInfo>();
        public AppInfoPage()
        {
            this.InitializeComponent();
            MainPage.backBbutton.Visibility = Visibility.Visible;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AppInfo = (AppInfo)e.Parameter;
        }

        private async void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            SetDownloadButtonState(DownloadState.Downloading);

            string downloadUrl = AppInfo.DownloadUrl64;
            try
            {
                await BulidDownloadAsync(downloadUrl);
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            //foreach (AppInfo info in AppDownloadingList)
            //{
            //    if (info.Name.Equals(AppInfo.Name))
            //    {
            //        switch (info.DownloadState)
            //        {
            //            case DownloadState.Downloaded:
            //                SetDownloadButtonState(DownloadState.Downloaded);
            //                ToastMsg.Toast(info.Name + "下载完成");
            //                break;
            //            case DownloadState.Error:
            //                SetDownloadButtonState(DownloadState.Error);
            //                ToastMsg.Toast(info.Name + "下载出错：" + info.DownloadErrorMsg);
            //                break;
            //            default:
            //                AppDownloadingList.Remove(info);
            //                break;
            //        }
            //    }
            //}
        }

        private async Task BulidDownloadAsync(string url)
        {
            Uri uri;
            StorageFile storageFile;
            try
            {
                string fileName = url.Substring(url.LastIndexOf("/") + 1);
                //StorageFolder storageFolder = await DownloadsFolder.CreateFolderAsync("AppHub", CreationCollisionOption.OpenIfExists);
                StorageFolder storageFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("shared", CreationCollisionOption.OpenIfExists);
                storageFile = await storageFolder.CreateFileAsync(fileName, CreationCollisionOption.ReplaceExisting);

                uri = new Uri(Uri.EscapeUriString(url), UriKind.RelativeOrAbsolute);
            }
            catch (Exception ex)
            {
                //AppInfo.DownloadErrorMsg = ex.Message;
                //AppInfo.DownloadState = DownloadState.Error;

                return;
            }

            //AppInfo.DownloadState = DownloadState.Downloading;
            AppInfoPage.AppDownloadingList.Add(AppInfo);

            BackgroundDownloader backgroundDownloader = new BackgroundDownloader();
            DownloadOperation downloadOperation = backgroundDownloader.CreateDownload(uri, storageFile);
            await downloadOperation.StartAsync();
            //HandleDownloadAsync()

            foreach (AppInfo info in AppInfoPage.AppDownloadingList)
            {
                if (info.Name.Equals(AppInfo.Name))
                {
                    //info.DownloadState = DownloadState.Downloaded;
                }
            }
        }

        private void SetDownloadButtonState(DownloadState state)
        {
            switch (state)
            {
                case DownloadState.Downloaded:
                    DownloadButton.IsEnabled = true;
                    DownloadSymbolIcon.Visibility = Visibility.Visible;
                    DownloadProgressRing.IsActive = false;
                    DownloadProgressRing.Visibility = Visibility.Collapsed;
                    DownloadTextBlock.Text = "下载";
                    break;
                case DownloadState.Downloading:
                    DownloadButton.IsEnabled = false;
                    DownloadSymbolIcon.Visibility = Visibility.Collapsed;
                    DownloadProgressRing.IsActive = true;
                    DownloadProgressRing.Visibility = Visibility.Visible;
                    DownloadTextBlock.Text = "下载中";
                    break;
                case DownloadState.Error:
                    DownloadButton.IsEnabled = true;
                    DownloadSymbolIcon.Visibility = Visibility.Visible;
                    DownloadProgressRing.IsActive = false;
                    DownloadProgressRing.Visibility = Visibility.Collapsed;
                    DownloadTextBlock.Text = "下载";
                    break;
                default:
                    DownloadButton.IsEnabled = true;
                    DownloadSymbolIcon.Visibility = Visibility.Visible;
                    DownloadProgressRing.IsActive = false;
                    DownloadProgressRing.Visibility = Visibility.Collapsed;
                    DownloadTextBlock.Text = "下载";
                    break;
            }
        }

        

        private void AppTypeHyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
