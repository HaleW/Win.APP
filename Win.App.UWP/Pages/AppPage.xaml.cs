using System.Collections.ObjectModel;
using Win.App.Client.Model;
using Win.App.Client.Msg;
using Win.App.UWP.Model;
using Windows.UI.Xaml.Controls;

// https://go.microsoft.com/fwlink/?LinkId=234238 上介绍了“空白页”项模板

namespace Win.App.UWP.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class AppPage : Page
    {
        ObservableCollection<AppInfoModel> AppInfos;
        public AppPage()
        {
            this.InitializeComponent();
            //AppInfos = ReceiveMsg.AppInfos;

            //AppInfo.Add(new AppInfo
            //{
            //    Name = "Gimp",
            //    Img = "https://www.gimp.org/images/frontpage/wilber-big.png",
            //    Describe= "The Free & Open Source Image Editor'\n\t\t\tThis is the official website of the GNU Image Manipulation Program \n\t\t\t(GIMP).\n'      '\n'          GIMP is a cross-platform image editor available for GNU/Linux, \n\t\t\tOS\xa0X, Windows and more operating systems. It is \n\t\t\t'free \n\t\t\tsoftware you can change its \n\t\t\t'source code' \n\t\t\tand 'distribute' \n\t\t\tyour changes.    '\n'          Whether you are a graphic designer, photographer, illustrator, or \n\t\t\tscientist, GIMP provides you with sophisticated tools to get your job \n\t\t\tdone. You can further enhance your productivity with GIMP thanks to \n\t\t\tmany customization options and 3rd party plugins.\n'",
            //    //Describe = "This is the official website of the GNU Image Manipulation Program (GIMP)." +
            //    //"GIMP is a cross - platform image editor available for GNU / Linux, OS X, Windows and more operating systems.It is free software, you can change its source code and distribute your changes.  " +
            //    //"Whether you are a graphic designer, photographer, illustrator, or scientist, GIMP provides you with sophisticated tools to get your job done.You can further enhance your productivity with GIMP thanks to many customization options and 3rd party plugins.",
            //    Version = "2.10.8",
            //    Score = 123545,
            //    Type="Picture Tool",
            //    DownloadUrl = "https://download.gimp.org/mirror/pub/gimp/v2.10/windows/gimp-2.10.10-setup.exe"
            //});

            //AppInfo.Add(new AppInfo
            //{
            //    Name = "Visual Studio Code",
            //    Img = "https://github.com/HaleW/Wallpaper/blob/master/Logo/visual-studio-code-icon.png?raw=true",
            //    Describe = "Visual Studio Code is a lightweight but powerful source code editor which runs on your desktop and is available for Windows, macOS and Linux. It comes with built -in support for JavaScript, TypeScript and Node.js and has a rich ecosystem of extensions for other languages (such as C++, C#, Java, Python, PHP, Go) and runtimes(such as .NET and Unity). ",
            //    Version = "2.10.8",
            //    Type="Develop Tool Tool Tool Tool",
            //    DownloadUrl = "https://vscode.cdn.azure.cn/stable/51b0b28134d51361cf996d2f0a1c698247aeabd8/VSCodeSetup-x64-1.33.1.exe"
            //});
        }
        

        private void AppGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Frame.Navigate(typeof(AppInfoPage), (AppInfo)e.ClickedItem);
        }
    }
}
