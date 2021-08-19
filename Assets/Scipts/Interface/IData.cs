using System.Collections.Generic;

namespace RollaBallGame
{
    public interface IData<T>
    {
        void Save(T data, string path = null);
        T Load(string path = null);

        void SaveList(List<T> saveAll, string path);

        List<T> LoadList(string path = null);
    }
}
