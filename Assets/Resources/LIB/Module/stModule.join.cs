using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using System.Text.RegularExpressions;
namespace stModule.join
{
    static public class Class
    {
        static public void ОбъединитьВсеФайлы(this StreamWriter sw, string dir)
        {
            foreach (string f in Directory.GetFiles(dir)) sw.ОбъединитьМодульВОбщий(f);
            foreach (string d in Directory.GetDirectories(dir)) sw.ОбъединитьВсеФайлы(d);
        }
        static public void ОбъединитьМодульВОбщий(this StreamWriter sw, string file)
        {
            //Не существует?
            if (!File.Exists(file)) return;
            if (РасширениеФайла(file) != "cs") return;
            var sr = new StreamReader(file);
            var line = sr.ReadLine();
            while (line != null)
            {
                if (line.IndexOf("using ") == -1)
                    sw.WriteLine(line);
                line = sr.ReadLine();
            }
            sr.Close();
        }
        static public List<ulong> Добавлен = new List<ulong>();
        static public string ТолькоЦифры(this string s) => Regex.Replace(s, "[^0-9]", "");
        static public bool ЭтоНеЦифры(this string s) => ТолькоЦифры(s.Substring(s.LastIndexOf('.') + 1)) =="";
        static public string ТолькоТекст(this string s) => Regex.Replace(s, "[0-9]", "");
        static public string РасширениеФайла(this string s) => s.Substring(s.LastIndexOf(".")+1);
        static public string ЭтоЦифра(int i) => i < 10 ? "0" : "";
        static public void ДобавитьСтроки(StreamWriter sw,path.Class.Body b)
        {
            foreach (var line in b.lines) sw.WriteLine(line);
            ДобавитьЗависимости(sw, b);
        }
        static public void ДобавитьЗависимости(StreamWriter sw, path.Class.Body b)
        {
            foreach (var num in b.numbers)
            {
                ОбъединениеФайлов(sw, num.M, num.ИндексСтатики);
            }
        }
        static public bool Добавить(uint M, int i = -1)
        {
            var m_i = System.Convert.ToUInt64(M.ToString() + (i == -1 ? "" : (ЭтоЦифра(i)+i.ToString())));
            if (i == -1)
            {
                if (Добавлен.IndexOf(m_i) != -1) return false;
                Добавлен.Add(m_i);
                return true;
            }
            if (СтатикаДобавлена.IndexOf(m_i) != -1) return false;
            СтатикаДобавлена.Add(m_i);
            return true;
        }
        static public path.Class.Body ВытащитьСтрокиСтатическогоОбъекта(uint m, int ID)
        {
            var arr = (from f in path.Class.Библиотеки[m].fs where f.i == ID select f).ToArray();
            if (arr.Length == 0) Debug.Log(m+"."+ID);
            return arr[0];
        }

        static public void ОбъединениеФайлов(StreamWriter sw, uint M, int i=-1)
        {
            if (!Добавить(M, i)) return;
            if (path.Class.Библиотеки.ContainsKey(M) == false) return;
            //не статические модули
            if (i == -1) foreach (var b in path.Class.Библиотеки[M].fs) ДобавитьСтроки(sw, b);
            //статические модули
            else ДобавитьЗависимости(sw, ВытащитьСтрокиСтатическогоОбъекта(M,i));
        }
        static public List<ulong> СтатикаДобавлена = new List<ulong>();
        static public void ОбъединениеСтатики(StreamWriter sw)
        {
            sw.WriteLine("namespace LIB.st");
            sw.WriteLine("{");
            sw.WriteLine("static public class Class");
            sw.WriteLine("{");
            foreach (var st in СтатикаДобавлена)
            {
                var m_i = st.ToString();
                var m = System.Convert.ToUInt32(m_i.Substring(0, m_i.Length-2));
                var i = System.Convert.ToInt32(m_i.Substring(m_i.Length - 2));
                var body = ВытащитьСтрокиСтатическогоОбъекта(m, i);
                foreach (var line in body.lines)
                    sw.WriteLine(line);
            }
            sw.WriteLine("}");
            sw.WriteLine("}");
        }
        static public void ОбщийМодуль(uint M)
        {
            //File.WriteAllText(@"C:\file.txt", File.ReadAllText(@"C:\file.txt"), System.Text.Encoding.UTF8);
            StreamWriter sw = new StreamWriter(path.Class.ОбщийМодульМира);
            file.Class.Библиотеки(sw);
            ОбъединениеФайлов(sw, M);
            ОбъединениеСтатики(sw);
            sw.Close();
        }
    }
}
