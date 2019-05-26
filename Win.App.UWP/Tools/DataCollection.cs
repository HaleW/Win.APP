using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Win.App.Client.Msg;
using Win.App.Model;
using Win.App.Protobuf.Msg;
using Windows.Foundation;
using Windows.UI.Xaml.Data;

namespace Win.App.UWP.Tools
{
    public class DataCollection : ObservableCollection<AppInfo>, ISupportIncrementalLoading
    {
        bool IsLoading = false;
        uint LoadedCount;
        List<AppInfo> ts;

        public bool HasMoreItems
        {   
            get
            {
                if (Count >= LoadedCount)
                {
                    return false;
                }
                return true;
            }
        }

        public IAsyncOperation<LoadMoreItemsResult> LoadMoreItemsAsync(uint count)
        {
            if (IsLoading)
            {
                throw new InvalidOperationException("正在加载");
            }
            uint temp = LoadedCount - (uint)Count;
            uint itemCountToLoaded = 0;

            if (temp < count)
            {
                itemCountToLoaded = temp;
            }
            else
            {
                itemCountToLoaded = count;
            }


            return AsyncInfo.Run(c => LoadMoreItemsPrivate(c, itemCountToLoaded));
        }

        private async Task<LoadMoreItemsResult> LoadMoreItemsPrivate(CancellationToken ct, uint n)
        {
            IsLoading = true;

            if (LoadItemsStarted != null)
            {
                LoadItemsStarted(this, EventArgs.Empty);
            }

            uint hadLoaded = 0;
            //ts= ReceiveMsg<AppInfoProto, AppInfo, string>.appInfos;
            LoadedCount = (uint)ts.Count;

            //await Task.Run(() =>
            // {
                 for (int i = 0; i < n; i++)
                 {
                     this.Add(ts[i]);
                     hadLoaded++;
                 }
             //});
            IsLoading = false;

            if (LoadItemsCompleted != null)
            {
                LoadItemsCompleted(this, EventArgs.Empty);
            }

            return new LoadMoreItemsResult { Count = hadLoaded };
        }

        public event EventHandler LoadItemsStarted;

        public event EventHandler LoadItemsCompleted;
    }
}
