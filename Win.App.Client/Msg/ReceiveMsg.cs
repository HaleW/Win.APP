using Google.Protobuf.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Win.App.Client.Model;
using Win.App.Client.SQLite;
using Win.App.Model;
using Win.App.Protobuf.Msg;

namespace Win.App.Client.Msg
{
    public class ReceiveMsg<P, M, K> where M : new()
    {
        public void SaveData(MapField<K, P> data, string tableName)
        {
            MsgTools<P, M, K> msgTools = new MsgTools<P, M, K>();
            Dictionary<K, M> dictinonary = msgTools.MapFieldToList(data);

            SqliteExecute<M> execute = new SqliteExecute<M>();

            foreach (KeyValuePair<K, M> pair in dictinonary)
            {
                if (execute.InsertData(tableName, pair.Value) == 0)
                {
                    //execute.UpdateData
                }
            }
        }
    }
}
