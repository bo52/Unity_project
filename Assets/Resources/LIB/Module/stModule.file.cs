using System.IO;
using UnityEditor;
using UnityEngine;

namespace stModule.file
{
    public static class Class
    {
        public static string Год => System.Convert.ToDateTime(System.DateTime.Now.ToString()).ToString("yyyy");
        public static string НовыйИд => System.Convert.ToDateTime(System.DateTime.Now.ToString()).ToString("yyMMddHHmm");

        static public bool Создать(string name, string PATH, System.Func<string, string> Новый, ref Rect rect)
        {
            rect.x = rect.x + rect.width + 5f;
            rect.width = name.Length * 8.7f;
            var Обновить = EditorGUI.LinkButton(rect, name);
            if (Обновить)
            {
                Обновить = EditorUtility.DisplayDialog(name, PATH, "Добавить", "Отмена");
                if (Обновить)
                    Новый(PATH);
            }
            return Обновить;
        }
        static public bool Создать(byte Номер, string PATH = "", Rect rect = new Rect(), bool noproject = false)
        {
            bool Обновить = false;
            if (noproject)
                switch (Номер)
                {
                    case (byte)path.Class.Разделы.PROG:
                        Обновить = Создать("Мир", PATH, НовыйМир, ref rect);
                        break;
                    case (byte)path.Class.Разделы.GO:
                    case (byte)path.Class.Разделы.CLASS:
                        Обновить = Создать("Объект", PATH, НовыйОбъектМира, ref rect);
                        break;
                }
            var Обновить_f = Создать("Фун", PATH, НовыйФункционал, ref rect);
            if ((byte)path.Class.Разделы.FUNS != Номер)
            {
                var Обновить_s = Создать("Структура", PATH, НоваяСтруктура, ref rect);
                if ((byte)path.Class.Разделы.STRUCT != Номер)
                {
                    Обновить = Обновить || Создать("Класс", PATH, НовыйКласс, ref rect);
                }
                Обновить = Обновить || Обновить_s;
            }
            Обновить = Обновить || Обновить_f;
            return Обновить;
        }
        static public void Открыть()
        {
            GUILayout.BeginHorizontal();
            var style = "miniButton";
            //if (GUILayout.Button("Обновить", style))
            //_options = stModule.world.Class.СформироватьСписокМиров;
            if (GUILayout.Button("temp", style))
                ОткрытьФайл(path.Class.МусорСкриптов);
            if (GUILayout.Button("backup", style))
                ОткрытьФайл(path.Class.ПереносимыеСкрипты);
            if (GUILayout.Button("LIB", style))
                ОткрытьФайл(path.Class.КореньМодулей);
            if (GUILayout.Button("PROJ", style))
                ОткрытьФайл(path.Class.РазделСкриптов);
            if (GUILayout.Button("Mono", style))
                ОткрытьФайл(path.Class.ОбщийМодульМира);
            //if (GUILayout.Button("Text", style))
            //stModule.file.Class.ОткрытьФайл(stModule.path.Class.КореньМира + _options[index] + "/info.txt");
            GUILayout.EndHorizontal();
        }
        static public void Очистить()
        {
            StreamWriter sw = new StreamWriter(path.Class.ОбщийМодульМира, false);
            sw.WriteLine("//empty");
            sw.Close();
        }
        static public void ОткрытьФайл(this string commandText, bool create = false)
        {
            if (create) if (!File.Exists(commandText)) File.Create(commandText).Close();
            var proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = commandText;
            proc.StartInfo.UseShellExecute = true;
            proc.Start();
        }
        #region Новый
        static public string НовыйМир(string PATH = "")
        {
            if (PATH == "") PATH = path.Class.КореньМира;
            var ID = НовыйИд;
            var d = "empty." + ID + "/";
            Directory.CreateDirectory(PATH + d);
            File.Create(PATH + d + "info.txt");
            НовыйИнспектор(PATH, ID, "go");
            НоваяСцена(PATH, ID, "go");
            return PATH + d;
            //EditorGUILayoutPopup.ОбновитьСписокМиров();
            //НовыйМодуль(path.Class.КореньМира, ID).ОткрытьФайл();
        }
        #region НовыйИгровойОбъект
        static public void НоваяСцена(string DIR, string ID, string раздел)
        {
            Библиотеки(ID, DIR + "empty." + ID + "/Scene" + ID + ".cs", (sw) =>
            {
                sw.WriteLine("public interface IScene:go2305081120.IScene");
                sw.WriteLine("{");
                //sw.WriteLine("new IMono ОбъктМира { get;}");
                sw.WriteLine("}");
                sw.WriteLine("public class Scene : go2305081120.Scene, IScene");
                sw.WriteLine("{");
                //sw.WriteLine("new public IMono ОбъктМира => (this as go2305081120.IEvent).ОбъктМира as IMono;");
                sw.WriteLine("override public bool Выполнить()");
                sw.WriteLine("{");
                sw.WriteLine("return base.Выполнить();");
                sw.WriteLine("}");
                sw.WriteLine("}");
            }, раздел);
        }
        static public void НовыйИнспектор(string DIR, string ID, string раздел)
        {
            Библиотеки(ID, DIR + "empty." + ID + "/Inspector" + ID + ".cs", (sw) =>
            {
                sw.WriteLine("public interface IInspector: go2305081120.IInspector");
                sw.WriteLine("{");
                //sw.WriteLine("new IMono ОбъктМира { get;}");
                sw.WriteLine("new IScene СЦЕНА { get; }");
                sw.WriteLine("}");
                sw.WriteLine("public class Inspector: go2305081120.Inspector, IInspector");
                sw.WriteLine("{");
                //sw.WriteLine("new public IMono ОбъктМира => (this as go2305081120.IEvent).ОбъктМира as IMono;");
                sw.WriteLine("new public IScene СЦЕНА => объектСЦЕНА as IScene;");
                sw.WriteLine("override public bool Выполнить()");
                sw.WriteLine("{");
                sw.WriteLine("return base.Выполнить();");
                sw.WriteLine("}");
                sw.WriteLine("}");
            }, раздел);
        }
        #endregion
        static public string НовыйОбъектМира(string PATH = "")
        {
            if (PATH == "") PATH = path.Class.КореньОбъектМира;
            var ID = НовыйИд;
            var d = "empty." + ID + "/";
            Directory.CreateDirectory(PATH + d);
            НовыйИнспектор(PATH, ID, "go");
            НоваяСцена(PATH, ID, "go");
            return PATH + d;
            //НовыйМодуль(path.Class.КореньОбъектМира, ID, true).ОткрытьФайл();
        }
        static public string НовыйФункционал(string PATH = "")
        {
            var ID = НовыйИд;
            if (PATH == "") PATH = path.Class.КореньПустой("FUNS");
            var f = PATH + "st.empty." + ID + ".cs";
            Библиотеки(ID, f, (sw) =>
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
            f.ОткрытьФайл();
            return f;
        }
        static public string НоваяСтруктура(string PATH = "")
        {
            var ID = НовыйИд;
            if (PATH == "") PATH = path.Class.КореньПустой("STRUCT");
            var f = PATH + "cs.empty." + ID + ".cs";
            Библиотеки(ID, f, (sw) =>
            {
                sw.WriteLine("/// <summary>");
                sw.WriteLine("///");
                sw.WriteLine("/// </summary>");
                sw.WriteLine("public struct Class");
                sw.WriteLine("{");
                sw.WriteLine("static public string INFO = \"INFO\";");
                sw.WriteLine("}");
            });
            f.ОткрытьФайл();
            return f;
        }
        static public string НовыйКласс(string PATH = "")
        {
            var ID = НовыйИд;
            if (PATH == "") PATH = path.Class.КореньПустой("CLASS");
            var f = PATH + "cs.empty." + ID + ".cs";
            Библиотеки(ID, f, (sw) =>
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
            f.ОткрытьФайл();
            return f;
        }
        #endregion
        #region Библиотека
        static public void Библиотеки(StreamWriter sw)
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
        static public void Библиотеки(string ID, string f, System.Action<StreamWriter> fun, string раздел = "cs")
        {
            using (var stream = new FileStream(f, FileMode.Create))
            {
                StreamWriter sw = new StreamWriter(stream, new System.Text.UTF8Encoding(true));
                Библиотеки(sw);
                sw.WriteLine("namespace LIB." + раздел + ID);
                sw.WriteLine("{");
                fun(sw);
                sw.WriteLine("}");
                sw.Close();
            }
        }
        #endregion
        static public string НовыйМодуль(string DIR, string ID, string раздел)
        {
            var f = DIR + "empty." + ID + "/Mono" + ID + ".cs";
            Библиотеки(ID, f, (sw) =>
            {
                sw.WriteLine("public interface IMono : go2305081120.IMono");
                sw.WriteLine("{");
                sw.WriteLine("new IInspector ИНСПЕКТОР { get; }");
                sw.WriteLine("new IScene СЦЕНА { get; }");
                sw.WriteLine("}");
                sw.WriteLine("public class Mono : go2305081120.Mono, go2305081120.IMono");
                sw.WriteLine("{");
                sw.WriteLine("new public IScene СЦЕНА => объектСЦЕНА as IScene;");
                sw.WriteLine("new public IInspector ИНСПЕКТОР => объектИНСПЕКТОР as IInspector;");
                sw.WriteLine("}");
            }, раздел);
            return f;
        }
    }
}
