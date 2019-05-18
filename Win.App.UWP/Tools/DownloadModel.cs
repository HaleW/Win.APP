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
                return _Guid;
            }
            set
            {
                _Guid = value;
                RaisePropertyChanged("Guid");
            }
        }
        private Guid _Guid;

        public double Progress
        {
            get
            {
                return _Progress;
            }
            set
            {
                _Progress = value;
                RaisePropertyChanged("Progress");
            }
        }
        private double _Progress;

        public ulong TotalBytesToReceive
        {
            get
            {
                return _TotalBytesToReceive;
            }
            set
            {
                _TotalBytesToReceive = value;
                RaisePropertyChanged("TotalBytesToReceive");
            }
        }
        private ulong _TotalBytesToReceive;

        public ulong BytesReceived
        {
            get
            {
                return _BytesReceived;
            }
            set
            {
                _BytesReceived = value;
                RaisePropertyChanged("BytesReceived");
            }
        }
        private ulong _BytesReceived;
    }
}
