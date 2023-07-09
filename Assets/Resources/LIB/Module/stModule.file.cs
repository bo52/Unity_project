using System.IO;
using UnityEditor;
using UnityEngine;

namespace stModule.file
{
    public static class Class
    {
        public static string ��� => System.Convert.ToDateTime(System.DateTime.Now.ToString()).ToString("yyyy");
        public static string ������� => System.Convert.ToDateTime(System.DateTime.Now.ToString()).ToString("yyMMddHHmm");

        static public bool �������(string name, string PATH, System.Func<string, string> �����, ref Rect rect)
        {
            rect.x = rect.x + rect.width + 5f;
            rect.width = name.Length * 8.7f;
            var �������� = EditorGUI.LinkButton(rect, name);
            if (��������)
            {
                �������� = EditorUtility.DisplayDialog(name, PATH, "��������", "������");
                if (��������)
                    �����(PATH);
            }
            return ��������;
        }
        static public bool �������(byte �����, string PATH = "", Rect rect = new Rect(), bool noproject = false)
        {
            bool �������� = false;
            if (noproject)
                switch (�����)
                {
                    case (byte)path.Class.�������.PROG:
                        �������� = �������("���", PATH, ��������, ref rect);
                        break;
                    case (byte)path.Class.�������.GO:
                    case (byte)path.Class.�������.CLASS:
                        �������� = �������("������", PATH, ���������������, ref rect);
                        break;
                }
            var ��������_f = �������("���", PATH, ���������������, ref rect);
            if ((byte)path.Class.�������.FUNS != �����)
            {
                var ��������_s = �������("���������", PATH, ��������������, ref rect);
                if ((byte)path.Class.�������.STRUCT != �����)
                {
                    �������� = �������� || �������("�����", PATH, ����������, ref rect);
                }
                �������� = �������� || ��������_s;
            }
            �������� = �������� || ��������_f;
            return ��������;
        }
        static public void �������()
        {
            GUILayout.BeginHorizontal();
            var style = "miniButton";
            //if (GUILayout.Button("��������", style))
            //_options = stModule.world.Class.�����������������������;
            if (GUILayout.Button("temp", style))
                �����������(path.Class.�������������);
            if (GUILayout.Button("backup", style))
                �����������(path.Class.������������������);
            if (GUILayout.Button("LIB", style))
                �����������(path.Class.�������������);
            if (GUILayout.Button("PROJ", style))
                �����������(path.Class.��������������);
            if (GUILayout.Button("Mono", style))
                �����������(path.Class.���������������);
            //if (GUILayout.Button("Text", style))
            //stModule.file.Class.�����������(stModule.path.Class.���������� + _options[index] + "/info.txt");
            GUILayout.EndHorizontal();
        }
        static public void ��������()
        {
            StreamWriter sw = new StreamWriter(path.Class.���������������, false);
            sw.WriteLine("//empty");
            sw.Close();
        }
        static public void �����������(this string commandText, bool create = false)
        {
            if (create) if (!File.Exists(commandText)) File.Create(commandText).Close();
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = commandText;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }
        #region �����
        static public string ��������(string PATH = "")
        {
            if (PATH == "") PATH = path.Class.����������;
            var ID = �������;
            var d = "empty." + ID + "/";
            Directory.CreateDirectory(PATH + d);
            File.Create(PATH + d + "info.txt");
            ��������������(PATH, ID, "go");
            ����������(PATH, ID, "go");
            return PATH + d;
            //EditorGUILayoutPopup.�������������������();
            //�����������(path.Class.����������, ID).�����������();
        }
        #region ������������������
        static public void ����������(string DIR, string ID, string ������)
        {
            ����������(ID, DIR + "empty." + ID + "/Scene" + ID + ".cs", (sw) =>
            {
                sw.WriteLine("public interface IScene:go2305081120.IScene");
                sw.WriteLine("{");
                //sw.WriteLine("new IMono ��������� { get;}");
                sw.WriteLine("}");
                sw.WriteLine("public class Scene : go2305081120.Scene, IScene");
                sw.WriteLine("{");
                //sw.WriteLine("new public IMono ��������� => (this as go2305081120.IEvent).��������� as IMono;");
                sw.WriteLine("override public bool ���������()");
                sw.WriteLine("{");
                sw.WriteLine("return base.���������();");
                sw.WriteLine("}");
                sw.WriteLine("}");
            }, ������);
        }
        static public void ��������������(string DIR, string ID, string ������)
        {
            ����������(ID, DIR + "empty." + ID + "/Inspector" + ID + ".cs", (sw) =>
            {
                sw.WriteLine("public interface IInspector: go2305081120.IInspector");
                sw.WriteLine("{");
                //sw.WriteLine("new IMono ��������� { get;}");
                sw.WriteLine("new IScene ����� { get; }");
                sw.WriteLine("}");
                sw.WriteLine("public class Inspector: go2305081120.Inspector, IInspector");
                sw.WriteLine("{");
                //sw.WriteLine("new public IMono ��������� => (this as go2305081120.IEvent).��������� as IMono;");
                sw.WriteLine("new public IScene ����� => ����������� as IScene;");
                sw.WriteLine("override public bool ���������()");
                sw.WriteLine("{");
                sw.WriteLine("return base.���������();");
                sw.WriteLine("}");
                sw.WriteLine("}");
            }, ������);
        }
        #endregion
        static public string ���������������(string PATH = "")
        {
            if (PATH == "") PATH = path.Class.����������������;
            var ID = �������;
            var d = "empty." + ID + "/";
            Directory.CreateDirectory(PATH + d);
            ��������������(PATH, ID, "go");
            ����������(PATH, ID, "go");
            return PATH + d;
            //�����������(path.Class.����������������, ID, true).�����������();
        }
        static public string ���������������(string PATH = "")
        {
            var ID = �������;
            if (PATH == "") PATH = path.Class.������������("FUNS");
            var f = PATH + "st.empty." + ID + ".cs";
            ����������(ID, f, (sw) =>
            {
                sw.WriteLine("/// <summary>");
                sw.WriteLine("///");
                sw.WriteLine("/// </summary>");
                sw.WriteLine("static public class Class");
                sw.WriteLine("{");
                sw.WriteLine("static public string INFO = \"INFO\";");
                sw.WriteLine("/// <summary>");
                sw.WriteLine("///");
                sw.WriteLine("/// </summary>");
                sw.WriteLine("static public void fun" + ID + "00()");
                sw.WriteLine("{");
                sw.WriteLine("//");
                sw.WriteLine("}");
                sw.WriteLine("///exit");
                sw.WriteLine("}");
            }, "st");
            f.�����������();
            return f;
        }
        static public string ��������������(string PATH = "")
        {
            var ID = �������;
            if (PATH == "") PATH = path.Class.������������("STRUCT");
            var f = PATH + "cs.empty." + ID + ".cs";
            ����������(ID, f, (sw) =>
            {
                sw.WriteLine("/// <summary>");
                sw.WriteLine("///");
                sw.WriteLine("/// </summary>");
                sw.WriteLine("public struct Class");
                sw.WriteLine("{");
                sw.WriteLine("static public string INFO = \"INFO\";");
                sw.WriteLine("}");
            });
            f.�����������();
            return f;
        }
        static public string ����������(string PATH = "")
        {
            var ID = �������;
            if (PATH == "") PATH = path.Class.������������("CLASS");
            var f = PATH + "cs.empty." + ID + ".cs";
            ����������(ID, f, (sw) =>
            {
                sw.WriteLine("/// <summary>");
                sw.WriteLine("///");
                sw.WriteLine("/// </summary>");
                sw.WriteLine("public interface IClass:cs2307031414_Default.IClass");
                sw.WriteLine("{");
                sw.WriteLine("}");
                sw.WriteLine("/// <summary>");
                sw.WriteLine("///");
                sw.WriteLine("/// </summary>");
                sw.WriteLine("public class Class:cs2307031414_Default.Class,IClass");
                sw.WriteLine("{");
                sw.WriteLine("static public string INFO = \"INFO\";");
                sw.WriteLine("}");
            });
            f.�����������();
            return f;
        }
        #endregion
        #region ����������
        static public void ����������(StreamWriter sw)
        {
            sw.WriteLine("//empty");
            sw.WriteLine("//empty");
            sw.WriteLine("//empty");
            sw.WriteLine("using System.Collections;");
            sw.WriteLine("using System.Collections.Generic;");
            sw.WriteLine("using UnityEditor;");
            sw.WriteLine("using UnityEngine;");
            sw.WriteLine("using System.IO;");
            sw.WriteLine("using System.Linq;");
        }
        static public void ����������(string ID, string f, System.Action<StreamWriter> fun, string ������ = "cs")
        {
            using (var stream = new FileStream(f, FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(stream, new System.Text.UTF8Encoding(true));
                ����������(sw);
                sw.WriteLine("namespace LIB." + ������ + ID);
                sw.WriteLine("{");
                fun(sw);
                sw.WriteLine("}");
                sw.Close();
            }
        }
        #endregion
        static public string �����������(string DIR, string ID, string ������)
        {
            var f = DIR + "empty." + ID + "/Mono" + ID + ".cs";
            ����������(ID, f, (sw) =>
            {
                sw.WriteLine("public interface IMono : go2305081120.IMono");
                sw.WriteLine("{");
                sw.WriteLine("new IInspector ��������� { get; }");
                sw.WriteLine("new IScene ����� { get; }");
                sw.WriteLine("}");
                sw.WriteLine("public class Mono : go2305081120.Mono, go2305081120.IMono");
                sw.WriteLine("{");
                sw.WriteLine("new public IScene ����� => ����������� as IScene;");
                sw.WriteLine("new public IInspector ��������� => ��������������� as IInspector;");
                sw.WriteLine("}");
            }, ������);
            return f;
        }
    }
}
