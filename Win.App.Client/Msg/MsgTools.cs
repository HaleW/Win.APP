using Google.Protobuf.Collections;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Win.App.Client.Msg
{
    public class MsgTools<P, M, K> where M : new()
    {
        public M ProtoToModel(P proto)
        {
            M res = new M();
            PropertyInfo[] protos = proto.GetType().GetProperties();
            PropertyInfo[] models = res.GetType().GetProperties();

            foreach (PropertyInfo p in protos)
            {
                foreach (PropertyInfo m in models)
                {
                    if (p.Name.ToLower().Equals(m.Name.ToLower()))
                    {
                        var value = p.GetValue(proto);
                        switch (m.PropertyType.Name)
                        {
                            case "DateTime":
                                DateTime temp;
                                value = DateTime.TryParse(value.ToString(), out temp) == true ? temp : value = null;
                                break;
                            default:
                                break;
                        }
                        m.SetValue(res, value);
                        break;
                    }
                }
            }

            return res;
        }

        public Dictionary<K, M> MapFieldToList(MapField<K, P> mapField)
        {
            Dictionary<K, M> dictionary = new Dictionary<K, M>();

            foreach (KeyValuePair<K, P> pair in mapField)
            {
                M m = ProtoToModel(pair.Value);
                dictionary.Add(pair.Key, m);
            }

            return dictionary;
        }
    }
}
