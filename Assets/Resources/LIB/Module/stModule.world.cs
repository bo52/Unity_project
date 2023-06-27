using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace stModule.world {
    static public class Class
    {
        static public List<string> ИнформацияМиров = new List<string>();
        //Массив строк, которые хотим видеть в выпадающем списке
        static private GameObject _go;
        static public GameObject ОбъектМира
        {
            get
            {
                if (_go == null) _go = GameObject.Find("Directional Light");
                return _go;
            }
        }
        static public MonoBehaviour Моно
        {
            get
            {
                var mb = ОбъектМира.GetComponent("LIB.cs2305161108.Mono");
                if (mb == null) mb = ОбъектМира.AddComponent(System.Type.GetType("LIB.cs2305161108.Mono", false, true));
                return mb as MonoBehaviour;
            }
        }
        //static public void РекурсияФормированияМира

        static public string[] СформироватьСписокМиров
        {
            get
            {
                ИнформацияМиров.Clear();
                var ws = new List<string>();
                
                string[] dirs = Directory.GetDirectories(path.Class.КореньМира);
                foreach (string s in dirs)
                {
                    if (join.Class.ТолькоЦифры(s) == "")
                    {
                        continue;
                    }
                    ws.Add(Path.GetFileName(s));
                    var text = "";
                    if (File.Exists(s + "/info.txt"))
                    {
                        var sr = new StreamReader(s + "/info.txt");

                        var line = sr.ReadLine();
                        while (line != null)
                        {
                            text = line + "\n" + text;
                            line = sr.ReadLine();
                        }
                    }
                    ИнформацияМиров.Add(text);

                }
                return ws.ToArray();
            }
        }
    }
}
