using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.Networking.BackgroundTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Win.App.UWP.Tools;
using Win.App.Model;

namespace Win.App.UWP.Pages
{
    public sealed partial class DownloadPage : Page
    {
        List<AppInfo> AppInfoList;
        private List<DownloadOperation> ActiveDownloads;
        private ObservableCollection<DownloadModel> Downloads = new ObservableCollection<DownloadModel>();
        private CancellationTokenSource CancellationToken = new CancellationTokenSource();

        public DownloadPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //StorageFolder storageFolder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("share", CreationCollisionOption.OpenIfExists);

            AppInfoList = AppInfoPage.AppDownloadingList;
            await DiscoverActiveDownloadsAsync();
        }

        private async Task DiscoverActiveDownloadsAsync()
        {
            ActiveDownloads = new List<DownloadOperation>();
            IReadOnlyList<DownloadOperation> downloads;
            try
            {
                downloads = await BackgroundDownloader.GetCurrentDownloadsAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return;
            }

            if (downloads.Count > 0)
            {
                List<Task> tasks = new List<Task>();

                foreach (DownloadOperation download in downloads)
                {
                    Debug.WriteLine(
                        String.Format(
                            CultureInfo.CurrentCulture,
                            "Discovered background download: {0}, Status: {1}",
                            download.Guid,
                            download.Progress.Status));

                    tasks.Add(HandleDownloadAsync(download, false));
                }
            }
        }

        private async Task HandleDownloadAsync(DownloadOperation downloadOperation, bool start)
        {
            try
            {
                DownloadModel download = new DownloadModel
                {
                    DownloadOperation = downloadOperation,
                    Source = downloadOperation.RequestedUri.ToString(),
                    Destination = downloadOperation.ResultFile.Path,
                    BytesReceived = downloadOperation.Progress.BytesReceived / 1048576,
                    TotalBytesToReceive = downloadOperation.Progress.TotalBytesToReceive / 1048576,
                    Guid = downloadOperation.Guid,
                    Progress = 0,
                    CancellationToken = new CancellationTokenSource()
                };

                foreach (AppInfo appInfo in AppInfoList)
                {
                    if (download.Source.Equals(appInfo.DownloadUrl64))
                    {
                        download.AppInfo = appInfo;
                    }
                }
                Downloads.Add(download);

                Progress<DownloadOperation> progress = new Progress<DownloadOperation>(DownloadProgress);
                await downloadOperation.AttachAsync().AsTask(download.CancellationToken.Token, progress);

                ResponseInformation response = downloadOperation.GetResponseInformation();
                Debug.WriteLine(
                    String.Format(
                        CultureInfo.CurrentCulture,
                        "Completed: {0}, Status Code: {1}",
                        downloadOperation.Guid,
                        response.StatusCode));
            }
            catch (TaskCanceledException)
            {
                Debug.WriteLine("Canceled: " + downloadOperation.Guid);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
            finally
            {
                Downloads.Remove(Downloads.First(p => p.DownloadOperation == downloadOperation));
                ActiveDownloads.Remove(downloadOperation);
            }
        }

        private void DownloadProgress(DownloadOperation downloadOperation)
        {
            try
            {
                DownloadModel download = Downloads.First(p => p.DownloadOperation == downloadOperation);

                ulong bytesReceived = downloadOperation.Progress.BytesReceived;
                ulong totalBytesToReceive = downloadOperation.Progress.TotalBytesToReceive;

                download.Progress = Math.Round(bytesReceived * 100.0 / totalBytesToReceive, 2);
                download.BytesReceived = bytesReceived / 1048576;
                download.TotalBytesToReceive = totalBytesToReceive / 1048576;

                Debug.WriteLine(String.Format(
                    CultureInfo.CurrentCulture,
                    "Download Progress: {0}, TotalBytesToReceive: {1}, BytesReceived: {2}",
                    download.Progress, download.TotalBytesToReceive, download.BytesReceived));


            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (DownloadModel download in Downloads)
            {
                Guid guid = (Guid)(sender as Button).Tag;
                if (guid.Equals(download.DownloadOperation.Guid) &&
                    download.DownloadOperation.Progress.Status == BackgroundTransferStatus.Running)
                {
                    download.DownloadOperation.Pause();
                }
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (DownloadModel download in Downloads)
            {
                Guid guid = (Guid)(sender as Button).Tag;
                if (guid.Equals(download.DownloadOperation.Guid))
                {
                    download.CancellationToken.Cancel();
                    download.CancellationToken.Dispose();
                    download.CancellationToken = new CancellationTokenSource();
                }
            }
        }

        private void ResumeButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (DownloadModel download in Downloads)
            {
                Guid guid = (Guid)(sender as Button).Tag;
                if (guid.Equals(download.DownloadOperation.Guid) &&
                    download.DownloadOperation.Progress.Status == BackgroundTransferStatus.PausedByApplication)
                {
                    download.DownloadOperation.Resume();
                }
            }
        }

        private void DownloadListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(AppInfoPage), ((DownloadModel)e.ClickedItem).AppInfo);
        }
    }
}
