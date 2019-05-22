using System;
using System.ComponentModel;
using System.Threading;
using Win.App.UWP.Model;
using Windows.Networking.BackgroundTransfer;

namespace Win.App.UWP.Tools
{
    public class DownloadModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public AppInfo AppInfo { get; set; }
        public DownloadOperation DownloadOperation { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public CancellationTokenSource CancellationToken { get; set; }
        public Guid Guid
        {
            get
            {
                return guid;
            }
            set
            {
                guid = value;
                RaisePropertyChanged("Guid");
            }
        }
        private Guid guid;

        public double Progress
        {
            get
            {
                return progress;
            }
            set
            {
                progress = value;
                RaisePropertyChanged("Progress");
            }
        }
        private double progress;

        public ulong TotalBytesToReceive
        {
            get
            {
                return totalBytesToReceive;
            }
            set
            {
                totalBytesToReceive = value;
                RaisePropertyChanged("TotalBytesToReceive");
            }
        }
        private ulong totalBytesToReceive;

        public ulong BytesReceived
        {
            get
            {
                return bytesReceived;
            }
            set
            {
                bytesReceived = value;
                RaisePropertyChanged("BytesReceived");
            }
        }
        private ulong bytesReceived;
    }
}
