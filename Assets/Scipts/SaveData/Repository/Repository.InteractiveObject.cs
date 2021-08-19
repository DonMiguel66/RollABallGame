using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace RollaBallGame
{
    public sealed partial class Repository : ISaveInteractiveObject
    {
        private readonly string _path;

        private readonly IData<SavedData> _data;
        private const string _folderName = "dataSave";
        private const string _fileName = "objectsData.bat";


        public Repository()
        {
            _data = new JsonData<SavedData>();
            _path = Path.Combine(Application.dataPath, _folderName);
        }
        public void SaveIO(ListExecuteObject iOList)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }
            var _iOSavedData = new List<SavedData>();

            foreach (var item in iOList)
            {
                if (item is SpeedBuff speedBuff && speedBuff.enabled)
                {
                    var position = speedBuff.transform.position;
                    var name = speedBuff.name;
                    var isEnabled = speedBuff.isActiveAndEnabled;
                    _iOSavedData.Add(new SavedData { Position = position, Name = name, IsEnabled = isEnabled});

                }
                if (item is SpeedDebuff speedDebuff && speedDebuff.enabled)
                {
                    var position = speedDebuff.transform.position;
                    var name = speedDebuff.name;
                    var isEnabled = speedDebuff.isActiveAndEnabled;

                    _iOSavedData.Add(new SavedData { Position = position, Name = name, IsEnabled = isEnabled });
                }
            }
            _data.SaveList(_iOSavedData, Path.Combine(_path, _fileName));
        }

        public void LoadIO(ListExecuteObject iOList)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
            {
                Debug.Log($"File not found - {file}");
                return;
            } 
            var _iOLoadedData = _data.LoadList(file);
            foreach (var item in _iOLoadedData)
            {
                Debug.Log(item);
            }
            for (int i=0; i < _iOLoadedData.Count; i++)
            {
                SavedData interactiveObject = _iOLoadedData[i];
                if (iOList[i] is SpeedBuff speedBuff && speedBuff != null)
                {
                    speedBuff.transform.position = interactiveObject.Position;
                    speedBuff.name = interactiveObject.Name;
                    speedBuff.enabled = true;
                }
                if (iOList[i] is SpeedDebuff speedDebuff && speedDebuff != null)
                {
                    speedDebuff.transform.position = interactiveObject.Position;
                    speedDebuff.name = interactiveObject.Name;
                    speedDebuff.enabled = true;
                }
            }
        }
    }

}
