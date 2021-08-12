using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Json;
using System;

namespace RollaBallGame
{
    public sealed class JsonData<T> : IData<T>
    {
        public void Save(T data, string path = null)
        {
            var str = JsonUtility.ToJson(data);
            File.WriteAllText(path, Crypto.CryptoXOR(str));
        }

        public void SaveList(List<T> saveAll, string path)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(List<T>));

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                jsonSerializer.WriteObject(fileStream, saveAll);
            }
        }
        public T Load(string path = null)
        {
            var str = File.ReadAllText(path);
            return JsonUtility.FromJson<T>(Crypto.CryptoXOR(str));
        }


        public List<T> LoadList(string path = null)
        {
            var jsonSerializer = new DataContractJsonSerializer(typeof(List<T>));

            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                var newList = jsonSerializer.ReadObject(fileStream) as List<T>;
                return newList;
            }
        }

    }
}
