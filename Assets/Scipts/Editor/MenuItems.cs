using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace Assets.Scipts.Editor
{
    public class MenuItems
    {
        [MenuItem("Roll A Ball/Создать объект ")]
        private static void MenuOption()
        {
            EditorWindow.GetWindow(typeof(MyWindow), false, "Geekbrains");
        }

        [MenuItem("Assets/Create/Roll A Ball")]
        private static void AddConfig()
        {
        }
    }
}
