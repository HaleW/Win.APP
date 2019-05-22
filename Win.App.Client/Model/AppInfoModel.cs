using System.ComponentModel;
using Win.App.Model;
using Win.App.Protobuf.Msg;

namespace Win.App.Client.Model
{
    public class AppInfoModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private AppInfoProto appInfo;

        public AppInfoProto AppInfo
        {
            get
            {
                return appInfo;
            }
            set
            {
                appInfo = value;
                RaisePropertyChanged("AppInfo");
            }
        }
    }
}
