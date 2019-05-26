using Google.Protobuf.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Win.App.Client.SQLite;

namespace Win.App.Client.Msg
{
    public class ReceiveMsg<P, M, K> where M : new()
    {
        public static ObservableCollection<M> appInfos = new ObservableCollection<M>();
        public static void SaveData(MapField<K, P> data, string tableName)
        {
            MsgTools<P, M, K> msgTools = new MsgTools<P, M, K>();
            appInfos = msgTools.MapFieldToObservableCollection(data);

            //Dictionary<K, M> dictinonary = msgTools.MapFieldToList(data);

            //SqliteExecute<M,K> execute = new SqliteExecute<M,K>();

            //foreach (KeyValuePair<K, M> pair in dictinonary)
            //{
            //    appInfos.Add(pair.Value);
            //    //if (execute.InsertData(tableName, pair.Value) == 0)
            //    //{
            //    //    execute.UpdateData("AppInfo", pair.Key, pair.Value);
            //    //}
            //}
        }
    }
}
