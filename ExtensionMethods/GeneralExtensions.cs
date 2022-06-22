using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpUtilities.ExtensionMethods
{
    public static  class GeneralExtensions
    {
        public static T Clone<T>(this T obj)
        {
            var inst = obj.GetType().GetMethod("MemberwiseClone", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);

            return (T)inst?.Invoke(obj, null);
        }

        /// <summary>
        ///     Adds new value to the dictionary.
        /// </summary>
        public static IDictionary<T1, T2> MergeDic<T1, T2>(this IDictionary<T1, T2> instance,
            T1 key, T2 value, bool replaceExisting = true)
        {
            if (instance == null)
                instance = new Dictionary<T1, T2>();

            if (replaceExisting || !instance.ContainsKey(key))
                instance[key] = value;
            return instance;
        }

        /// <summary>
        ///     Adds new values to the dictionary.
        /// </summary>
        public static IDictionary<T1, T2> MergeDic<T1, T2>(this IDictionary<T1, T2> instance,
            IDictionary<T1, T2> from, bool replaceExisting = true)
        {
            if (instance == null)
                return from ?? new Dictionary<T1, T2>();

            foreach (var keyValuePair in from)
            {
                if (!replaceExisting && instance.ContainsKey(keyValuePair.Key))
                    continue;
                instance[keyValuePair.Key] = keyValuePair.Value;
            }
            return instance;
        }

        
        /// <summary>
        ///     Transforms dictionary keys according to the 'transformFunc'.
        /// </summary>
        /// <example>dic.TransformKey(x => $"Data[{x}]").TransformKey(x => "Global." + x)</example>
        public static IDictionary<T1, T2> TransformKey<T1, T2>(this IDictionary<T1, T2> instance,
            Func<T1, T1> transformFunc)
        {
            if (instance == null)
                return new Dictionary<T1, T2>();

            var instanceData = instance.ToList();
            instance.Clear();

            foreach (var keyValuePair in instanceData)
            {
                instance.Add(transformFunc(keyValuePair.Key), keyValuePair.Value);
            }

            return instance;
        }

        private static T AppendInValue<T>(this T instance, string key, string separator, object value)
            where T : class, IDictionary<string, object>
        {
            instance[key] = instance.ContainsKey(key) ? $"{instance[key]}{separator}{value}" : value;
            return instance;
        }


        /// <summary> Returns Task.Result synchronously. </summary>
        public static T GetResult<T>(this Task<T> task)
        {
            var res = task.GetAwaiter().GetResult();
            return res;
        }

        public static int GetIntValue(this Enum enumValue)
        {
            int res = (int)Enum.ToObject(enumValue.GetType(), enumValue);
            return res;
        }


    }
}
