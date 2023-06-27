using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace stModule.world {
    static public class Class
    {
        static public List<string> ��������������� = new List<string>();
        //������ �����, ������� ����� ������ � ���������� ������
        static private GameObject _go;
        static public GameObject ����������
        {
            get
            {
                if (_go == null) _go = GameObject.Find("Directional Light");
                return _go;
            }
        }
        static public MonoBehaviour ����
        {
            get
            {
                var mb = ����������.GetComponent("LIB.cs2305161108.Mono");
                if (mb == null) mb = ����������.AddComponent(System.Type.GetType("LIB.cs2305161108.Mono", false, true));
                return mb as MonoBehaviour;
            }
        }
        //static public void ������������������������

        static public string[] �����������������������
        {
            get
            {
                ���������������.Clear();
                var ws = new List<string>();
                
                string[] dirs = Directory.GetDirectories(path.Class.����������);
                foreach (string s in dirs)
                {
                    if (join.Class.�����������(s) == "")
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
                    ���������������.Add(text);

                }
                return ws.ToArray();
            }
        }
    }
}
