using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace GalaxyCreator.Util
{
    class CloneUtil
    {
        public static T CloneJson<T>(T source)
        {
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source));
        }

        public static void CopyProperties<T>(T source, T target)
        {
            foreach (PropertyInfo property in typeof(T).GetProperties())
            {
                if (property.CanWrite)
                {
                    property.SetValue(target, property.GetValue(source, null), null);
                }
            }
        }
    }
}
