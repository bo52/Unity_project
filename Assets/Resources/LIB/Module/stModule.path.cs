using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine;
namespace stModule.path
{
    public class Class
    {
        public enum Разделы {
            PROG,
            GO,
            FUNS,
            CLASS,
            STRUCT,
            SHADER,
        };
        public static string МусорСкриптов => КореньМодулей + "temp/";
        public static string ПереносимыеСкрипты => КореньМодулей + "backup/";
        public static string КореньМодулей => Application.dataPath + "/../../Unity_LIB/Assets/";
        public static string КореньСисМира => КореньМодулей + "SYS/";
        public static string КореньПустой(string раздел) => КореньМодулей + раздел + "/EMPTY/";
        public static string РазделРесурсов => Application.dataPath + "/Resources/";
        public static string РазделСкриптов => РазделРесурсов + "LIB/";
        public static string ОбщийМодульМира => РазделСкриптов + "Mono.cs";
        #region раздел
        public static bool Создать(bool noproject,string path, Rect rect) => file.Class.Создать(ОпределитьРаздел(path), path, rect, noproject);
        public static string КореньМира => КореньМодулей + "PROJECT/";
        public static string КореньОбъектМира => КореньМодулей + "GO/";
        public static string КореньКласс => КореньМодулей + "CLASS/";
        public static string КореньСтрукт => КореньМодулей + "STRUCT/";
        public static string КореньФунМира => КореньМодулей + "FUNS/";
        public static string КореньШейдеров => РазделРесурсов + "SHADERS/";
        public static byte ОпределитьРаздел(string path)
        {
            if (path.IndexOf(КореньМира) != -1) return (byte)Разделы.PROG;
            if (path.IndexOf(КореньОбъектМира) != -1) return (byte)Разделы.GO;
            if (path.IndexOf(КореньФунМира) != -1) return (byte)Разделы.FUNS;
            if (path.IndexOf(КореньКласс) != -1) return (byte)Разделы.CLASS;
            if (path.IndexOf(КореньСтрукт) != -1) return (byte)Разделы.STRUCT;
            if (path.IndexOf(КореньШейдеров) != -1) return (byte)Разделы.SHADER;
            return byte.MaxValue;
        }
        public static string ОпределитьКореньРаздела(byte x)
        {
            switch ((Разделы)x)
            {
                case Разделы.PROG:return КореньМира;
                case Разделы.GO: return КореньОбъектМира;
                case Разделы.FUNS: return КореньФунМира;
                case Разделы.CLASS: return КореньКласс;
                case Разделы.STRUCT: return КореньСтрукт;
                case Разделы.SHADER: return КореньШейдеров;
            }
            return null;
        }
        #endregion
        public static bool ЭтоНеПодключениеБиблиотеки(string line) => line.IndexOf("using ") == -1;

        public struct Библиотека
        {
            public string t;
            public Body[] fs;
            public Библиотека(string t, List<Body> fs)
            {
                this.t = t;
                this.fs = fs.ToArray();
            }
            public Библиотека(string t, Body[] fs)
            {
                this.t = t;
                this.fs = fs;
            }
        }
        public struct Body
        {
            public int i;
            public string[] lines;
            public link.Class.Ссылка[] numbers;
            public Body(List<string> lines, List<link.Class.Ссылка> numbers, int i = -1)
            {
                this.i = i;
                this.lines = lines.ToArray();
                this.numbers = numbers.ToArray();
            }
            public Body(List<string> lines, link.Class.Ссылка[] numbers, int i = -1)
            {
                this.i = i;
                this.lines = lines.ToArray();
                this.numbers = numbers;
            }
        }
        static public Dictionary<uint, Библиотека> Библиотеки = new Dictionary<uint, Библиотека>();
        public static Body[] ОбработкаМодуля_go(uint M, string f)
        {
            var path = Path.GetDirectoryName(f);
            var bs = new List<Body>();
            cs_go.Class.ОбработкаФайла(ref bs, M, path + "/Event" + M + ".cs");
            cs_go.Class.ОбработкаФайла(ref bs, M, path + "/Inspector" + M + ".cs");
            cs_go.Class.ОбработкаФайла(ref bs, M, path + "/Scene" + M + ".cs");
            return bs.ToArray();
        }
        public static Body[] ОбработкаМодуля_cs(uint M, string f)
        {
            var bs = new List<Body>();
            cs_go.Class.ОбработкаФайла(ref bs, M, f);
            return bs.ToArray();
        }
        public static Body[] ОбработкаМодуля_st(uint M, string f) => stat.Class.РаботаСФайлом(M, f);
        public static void ОбновитьВсеМодули(string D)
        {
            foreach (string f in Directory.GetFiles(D))
            {
                if (join.Class.РасширениеФайла(f) != "cs") continue;

                #region Получить M
                var m = Path.GetFileName(f);
                m = m.Substring(0, m.LastIndexOf("."));
                m = m.Substring(m.LastIndexOf(".") + 1);
                m = Regex.Replace(Path.GetFileName(m), "[^0-9]", "");
                if (m == "") continue;
                var M = System.Convert.ToUInt32(m); 
                #endregion

                if (Библиотеки.ContainsKey(M)) continue;

                string t = Path.GetFileName(f).Substring(0, 3);
                System.Func<uint, string, Body[]> act;
                switch (t)
                {
                    case "st.":
                        t = "st";
                        act = ОбработкаМодуля_st;
                        break;
                    case "cs.":
                        act = ОбработкаМодуля_cs;
                        t = "cs";
                        break;
                    default:
                        act = ОбработкаМодуля_go;
                        t = "go";
                        break;
                }

                Библиотеки.Add(M, new Библиотека(t, act(M, f)));
            }
            foreach (string d in Directory.GetDirectories(D))
                ОбновитьВсеМодули(d);
        }
        public static void СобратьБиблиотеки()
        {
            Библиотеки.Clear();
            ОбновитьВсеМодули(КореньСисМира);
            ОбновитьВсеМодули(КореньМира);
            ОбновитьВсеМодули(КореньОбъектМира);
            ОбновитьВсеМодули(КореньКласс);
            ОбновитьВсеМодули(КореньСтрукт);
            ОбновитьВсеМодули(КореньФунМира);
        }
        public static void Обновить(uint M)
        {
            СобратьБиблиотеки();
            join.Class.ОбщийМодуль(M);
        }
    }
}
