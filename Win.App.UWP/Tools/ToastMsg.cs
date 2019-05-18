using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;

namespace Win.App.UWP.Tools
{
    public class ToastMsg
    {
        public static void Toast(string msg)
        {
            ToastTemplateType type = ToastTemplateType.ToastText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(type);
            XmlNodeList nodes = toastXml.GetElementsByTagName("text");
            nodes[0].AppendChild(toastXml.CreateTextNode(msg));
            ToastNotification toast = new ToastNotification(toastXml);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }
    }
}
